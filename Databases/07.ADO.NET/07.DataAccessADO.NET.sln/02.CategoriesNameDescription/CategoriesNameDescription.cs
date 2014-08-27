namespace AccessingNorthwind
{
    using System;
    using System.Data.SqlClient;

    // Write a program that retrieves the name and description of all categories in the Northwind DB.
    class CategoriesNameDescription
    {
        static void Main()
        {
            //var dbCon = new SqlConnection(@"Server=.\SQLEXPRESS; Database=Northwind; Integrated Security=true;");
            var dbCon = new SqlConnection(Settings.Default.ConnectionString);

            dbCon.Open();

            using (dbCon)
            {
                var command = new SqlCommand("SELECT CategoryName, Description FROM Categories", dbCon);

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0}: {1}", reader["CategoryName"], reader["Description"]);
                }
            }
        }
    }
}
