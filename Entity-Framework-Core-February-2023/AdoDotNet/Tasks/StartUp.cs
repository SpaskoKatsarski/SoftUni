using Microsoft.Data.SqlClient;
using System.Text;

namespace Tasks
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection connection = new SqlConnection("Server=.\\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true");

            await connection.OpenAsync();
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
    }
}