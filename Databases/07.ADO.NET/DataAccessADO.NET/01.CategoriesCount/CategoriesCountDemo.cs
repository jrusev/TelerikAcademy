namespace AccessingNorthwind
{
    using System;
    using System.Data.SqlClient;

    // Write a program that retrieves from the Northwind sample database in MS SQL Server
    // the number of rows in the Categories table.
    class CategoriesCountDemo
    {
        static void Main()
        {
            //var dbCon = new SqlConnection(@"Server=.\SQLEXPRESS; Database=Northwind; Integrated Security=true;");
            var dbCon = new SqlConnection(Settings.Default.ConnectionString);

            dbCon.Open();

            using (dbCon)
            {
                var command = new SqlCommand("SELECT COUNT(*) FROM Categories", dbCon);

                int rows = (int)command.ExecuteScalar();

                Console.WriteLine("Number of categories: {0}", rows);
            }
        }
    }
}
