using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

// Write a program that reads a string from the console and finds all products that contain this string.
// Ensure you handle correctly characters like ', %, ", \ and _.
class FindProducts
{
    static void Main()
    {
        Console.Write("Enter your product search: ");
        string pattern = Console.ReadLine();

        using (var dbCon = new SqlConnection(@"Server=.\SQLEXPRESS;Database=Northwind;Integrated Security=true"))
        {
            dbCon.Open();

            var cmdSearch = new SqlCommand("SELECT ProductName FROM Products WHERE ProductName LIKE @Pattern", dbCon);

            // Use square brackets [] to escape the special characters, e.g. 50% -> [50%]
            pattern = pattern
                .Replace("%", "[%]")
                .Replace("'", "[']")
                .Replace("\"", "[\"]")
                .Replace("_", "[_]")
                .ToLower();

            cmdSearch.Parameters.AddWithValue("@Pattern", "%" + pattern + "%");

            var reader = cmdSearch.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0}", reader["ProductName"]);
            }
        }
    }
}
