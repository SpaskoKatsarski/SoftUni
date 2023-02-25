using Microsoft.Data.SqlClient;
using System.Globalization;

SqlConnection connection = new SqlConnection("Server=.\\SQLEXPRESS;Database=SoftUni;Integrated Security=true;Trust Server Certificate = true");
connection.Open();

using (connection)
{
    //SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Employees", connection);
    //int? employeesCount = (int?) await command.ExecuteScalarAsync();
    //Console.WriteLine($"Count of employees: {employeesCount}");

    SqlCommand command = new SqlCommand("SELECT FirstName, LastName FROM Employees WHERE DepartmentId = 7", connection);
    //SqlDataReader reader = await command.ExecuteReaderAsync();
    using (var reader = await command.ExecuteReaderAsync())
    {
        while (reader.Read())
        {
            string firstName = (string)reader["FirstName"];
            string lastName = (string)reader["LastName"];
            Console.WriteLine("{0} {1}", firstName, lastName);
        }
    }
}

////    //reader.Close();
////}
//SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS;Database=SoftUni;Integrated Security=true;Trust Server Certificate = true");

//dbCon.Open();

//using (dbCon)
//{
//    List<string> projectNames = new List<string>();

//    string startDateString = "11/12/2009";
//    IFormatProvider culture = new CultureInfo("en-US", true);
//    DateTime startVal = DateTime.ParseExact(startDateString, "yyyy-MM-dd", culture);

//    string endDateString = "11/12/2020";
//    DateTime endVal = DateTime.ParseExact(endDateString, "yyyy-MM-dd", culture);

//    InsertIntoProjects("Diablo Characters", "Characters", startVal, endVal);

//    SqlCommand cmd = new SqlCommand("SELECT * FROM Projects", dbCon);
//    SqlDataReader reader = await cmd.ExecuteReaderAsync();

//    while (reader.Read())
//    {
//        string projectName = (string)reader["Name"];

//        projectNames.Add(projectName);
//    }

//    Console.WriteLine(String.Join("\n", projectNames));

//    void InsertIntoProjects(string name, string description, DateTime startDate, DateTime endDate)
//    {
//        SqlCommand command = new SqlCommand("INSERT INTO Projects VALUES (@name, @desc, @start, @end)", dbCon);

//        command.Parameters.AddWithValue("@name", name);
//        command.Parameters.AddWithValue("@desc", description);
//        command.Parameters.AddWithValue("@start", startDate);
//        command.Parameters.AddWithValue("@end", endDate);

//        command.ExecuteNonQuery();
//    }
//}

//using System;

//class DonutAnimation
//{
//    static void Main()
//    {
//        const double A = 1.0;
//        const double B = 2.0;
//        const char CHAR = 'O';

//        int cols = Console.WindowWidth;
//        int rows = Console.WindowHeight;

//        double phi = 0.0;
//        double theta = 0.0;

//        while (true)
//        {
//            char[,] output = new char[rows, cols];

//            double sinPhi = Math.Sin(phi);
//            double cosPhi = Math.Cos(phi);
//            double sinTheta = Math.Sin(theta);
//            double cosTheta = Math.Cos(theta);

//            for (double y = -1.5; y <= 1.5; y += 0.1)
//            {
//                for (double x = -1.5; x <= 1.5; x += 0.05)
//                {
//                    double z1 = Math.Sin(Math.Sqrt(x * x + y * y));
//                    double r = Math.Sqrt(x * x + y * y + z1 * z1);
//                    double z2 = A * Math.Sin(B * Math.Atan2(z1, Math.Sqrt(x * x + y * y)));
//                    double cosAlpha = x / Math.Sqrt(x * x + y * y);
//                    double sinAlpha = y / Math.Sqrt(x * x + y * y);
//                    double x0 = r * cosAlpha * cosTheta - z2 * sinAlpha * sinTheta;
//                    double y0 = r * sinAlpha * cosTheta + z2 * cosAlpha * sinTheta;
//                    double z0 = z2 * cosTheta + r * sinTheta;

//                    int col = (int)Math.Round(cols / 2 + x0 * cols / 3 / z0);
//                    int row = (int)Math.Round(rows / 2 - y0 * rows / 2 / z0);

//                    if (col >= 0 && col < cols && row >= 0 && row < rows && z0 > 0)
//                    {
//                        output[row, col] = CHAR;
//                    }
//                }
//            }

//            Console.Clear();

//            for (int i = 0; i < rows; i++)
//            {
//                for (int j = 0; j < cols; j++)
//                {
//                    Console.Write(output[i, j]);
//                }
//                Console.WriteLine();
//            }

//            phi += 0.1;
//            theta += 0.05;
//        }
//    }
//}
