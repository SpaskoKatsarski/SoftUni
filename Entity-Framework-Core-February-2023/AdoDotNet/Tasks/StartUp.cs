using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace Tasks
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection connection = new SqlConnection("Server=.\\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true");

            await connection.OpenAsync();

            await CreateProcedureAsync(connection);
        }

        // Problem 2

        static async Task<string> GetVilliansWithTheirMinionsAsync(SqlConnection connection)
        {
            StringBuilder sb = new StringBuilder();

            SqlCommand printVillianNamesCmd = new SqlCommand(@"
                                  SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                    FROM Villains AS v 
                                    JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                GROUP BY v.Id, v.Name 
                                  HAVING COUNT(mv.VillainId) > 3 
                                ORDER BY COUNT(mv.VillainId)", connection);

            SqlDataReader reader = await printVillianNamesCmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                string name = (string)reader["Name"];
                int count = (int)reader["MinionsCount"];

                sb.AppendLine($"{name} - {count}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 3
        static async Task<string> GetVillianWithTheirMinionsByIdAsync(SqlConnection connection, int villainId)
        {
            StringBuilder sb = new StringBuilder();

            SqlCommand getVillainNameCmd = new SqlCommand("SELECT Name FROM Villains WHERE Id = @Id", connection);
            getVillainNameCmd.Parameters.AddWithValue("@Id", villainId);

            object? villainNameObj = await getVillainNameCmd.ExecuteScalarAsync();

            if (villainNameObj == null)
            {
                return $"No villain with ID {villainId} exists in the database.";
            }

            string villainName = (string)villainNameObj;
            sb.AppendLine($"Villain: {villainName}");

            await AppendMinionsOfVillain(connection, sb, villainId);

            return sb.ToString().TrimEnd();

            static async Task AppendMinionsOfVillain(SqlConnection connection, StringBuilder sb, int villainId)
            {
                SqlCommand getVillainsMinionsCmd = new SqlCommand(@"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name", connection);

                getVillainsMinionsCmd.Parameters.AddWithValue("@Id", villainId);

                SqlDataReader reader = await getVillainsMinionsCmd.ExecuteReaderAsync();

                if (!reader.HasRows)
                {
                    sb.AppendLine("(no minions)");
                }
                else
                {
                    while (reader.Read())
                    {
                        long rowNum = (long)reader["RowNum"];
                        string name = (string)reader["Name"];
                        int age = (int)reader["Age"];

                        sb.AppendLine($"{rowNum}. {name} {age}");
                    }
                }
            }
        }

        //Problem 4
        static async Task AddMinionAsync(SqlConnection connection, string minionInfoArr, string villainInfoArr)
        {
            SqlTransaction sqlTran = connection.BeginTransaction();

            try
            {
                string minionInfo = minionInfoArr.Split("Minion: ",
                StringSplitOptions.RemoveEmptyEntries)[0];

                string minionName = minionInfo.Split(" ",
                    StringSplitOptions.RemoveEmptyEntries)[0];

                int minionAge = int.Parse(minionInfo.Split(" ",
                    StringSplitOptions.RemoveEmptyEntries)[1]);

                string minionTown = minionInfo.Split(" ",
                    StringSplitOptions.RemoveEmptyEntries)[2];

                SqlCommand getTownIdCmd = new SqlCommand("SELECT Id FROM Towns WHERE Name = @townName", connection, sqlTran);
                getTownIdCmd.Parameters.AddWithValue("@townName", minionTown);

                object? townIdObj = await getTownIdCmd.ExecuteScalarAsync();

                if (townIdObj == null)
                {
                    SqlCommand addTownCmd = new SqlCommand("INSERT INTO Towns(Name) VALUES(@townName)", connection, sqlTran);
                    addTownCmd.Parameters.AddWithValue("townName", minionTown);
                    await addTownCmd.ExecuteNonQueryAsync();

                    Console.WriteLine($"Town {minionTown} was added to the database.");
                }

                string villainName = villainInfoArr.Split("Villain: ",
                    StringSplitOptions.RemoveEmptyEntries)[0];

                SqlCommand getVillainIdCmd = new SqlCommand("SELECT Id FROM Villains WHERE Name = @Name", connection, sqlTran);
                getVillainIdCmd.Parameters.AddWithValue("@Name", villainName);

                object? villainIdObj = await getVillainIdCmd.ExecuteScalarAsync();

                if (villainIdObj == null)
                {
                    SqlCommand addVilainCmd = new SqlCommand("INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)", connection, sqlTran);
                    addVilainCmd.Parameters.AddWithValue("@villainName", villainName);

                    await addVilainCmd.ExecuteNonQueryAsync();

                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }

                int townId = (int)await getTownIdCmd.ExecuteScalarAsync();

                SqlCommand addMinionCmd = new SqlCommand("INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)", connection, sqlTran);
                addMinionCmd.Parameters.AddWithValue("@name", minionName);
                addMinionCmd.Parameters.AddWithValue("@age", minionAge);
                addMinionCmd.Parameters.AddWithValue("@townId", townId);

                await addMinionCmd.ExecuteNonQueryAsync();

                SqlCommand getMinionIdCmd = new SqlCommand("SELECT Id FROM Minions WHERE Name = @Name", connection, sqlTran);
                getMinionIdCmd.Parameters.AddWithValue("@Name", minionName);
                int minionId = (int)await getMinionIdCmd.ExecuteScalarAsync();

                int villainId = (int)await getVillainIdCmd.ExecuteScalarAsync();

                SqlCommand addMinionToVillainCmd = new SqlCommand("INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)", connection, sqlTran);
                addMinionToVillainCmd.Parameters.AddWithValue("@minionId", minionId);
                addMinionToVillainCmd.Parameters.AddWithValue("@villainId", villainId);

                await addMinionToVillainCmd.ExecuteNonQueryAsync();
                await sqlTran.CommitAsync();
                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
            catch (Exception)
            {
                await sqlTran.CommitAsync();
            }

        }

        //Problem 5
        static async Task<string> ChangeTownNamesCasingAsync(SqlConnection connection, string country)
        {
            SqlCommand changeNamesToUppercaseCmd = new SqlCommand("UPDATE Towns SET Name = UPPER(Name) WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)", connection);
            changeNamesToUppercaseCmd.Parameters.AddWithValue("@countryName", country);
            //Check if ANY were affected
            int affectedRows = await changeNamesToUppercaseCmd.ExecuteNonQueryAsync();

            if (affectedRows == 0)
            {
                return "No town names were affected.";
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{affectedRows} town names were affected.");

            SqlCommand getTownsFromCountryCmd = new SqlCommand("SELECT t.Name FROM Towns as t JOIN Countries AS c ON c.Id = t.CountryCode WHERE c.Name = @countryName", connection);
            getTownsFromCountryCmd.Parameters.AddWithValue("@countryName", country);

            SqlDataReader reader = await getTownsFromCountryCmd.ExecuteReaderAsync();
            List<string> towns = new List<string>();

            while (reader.Read())
            {
                string town = (string)reader["Name"];
                towns.Add(town);
            }

            sb.AppendLine($"[{String.Join(", ", towns)}]");

            return sb.ToString().TrimEnd();
        }

        //Problem 6
        static async Task<string> DeleteVillainWithTheirMinions(SqlConnection connection, int villainId)
        {
            SqlTransaction sqlTran = connection.BeginTransaction();

            try
            {
                SqlCommand getVillainNameCmd = new SqlCommand("SELECT Name FROM Villains WHERE Id = @villainId", connection, sqlTran);

                getVillainNameCmd.Parameters.AddWithValue("@villainId", villainId);

                string? villainName = (string?)await getVillainNameCmd.ExecuteScalarAsync();

                if (villainName == null)
                {
                    return "No such villain was found.";
                }

                StringBuilder sb = new StringBuilder();

                SqlCommand removeVillainFromMappingTableWithItsMinions = new SqlCommand("DELETE FROM MinionsVillains WHERE VillainId = @villainId", connection, sqlTran);
                removeVillainFromMappingTableWithItsMinions.Parameters.AddWithValue("@villainId", villainId);

                int affectedRows = await removeVillainFromMappingTableWithItsMinions.ExecuteNonQueryAsync();

                SqlCommand removeVillain = new SqlCommand("DELETE FROM Villains WHERE Id = @villainId", connection, sqlTran);
                removeVillain.Parameters.AddWithValue("@villainId", villainId);

                await removeVillain.ExecuteNonQueryAsync();

                sqlTran.Commit();

                sb.AppendLine($"{villainName} was deleted.");
                sb.AppendLine($"{affectedRows} minions were released.");

                return sb.ToString().TrimEnd();
            }
            catch (Exception e)
            {
                sqlTran.Rollback();
                return e.Message;
            }
        }

        //Problem 7
        static async Task<string> GetMinionsNamesInSpecialOrderAsync(SqlConnection connection)
        {
            List<string> minionNames = new List<string>();

            SqlCommand getAllNamesCmd = new SqlCommand("SELECT Name FROM Minions", connection);

            SqlDataReader reader = await getAllNamesCmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                minionNames.Add((string)reader["Name"]);
            }

            List<string> outputNames = new List<string>();

            for (int i = 0; i < minionNames.Count; i++)
            {
                if (i % 2 == 0)
                {
                    outputNames.Add(minionNames[i]);
                }
                else
                {
                    outputNames.Add(minionNames[minionNames.Count - i]);
                }  
            }



            return String.Join("\n", outputNames);
        }

        //Problem 9
        static async Task CreateProcedureAsync(SqlConnection connection)
        {
            SqlCommand createProcCmd = new SqlCommand("GO CREATE PROC usp_GetOlder @id INT AS UPDATE Minions  SET Age += 1 WHERE Id = @id", connection);

            createProcCmd.CommandType = CommandType.StoredProcedure;

            await createProcCmd.ExecuteNonQueryAsync();
        }
    }
}