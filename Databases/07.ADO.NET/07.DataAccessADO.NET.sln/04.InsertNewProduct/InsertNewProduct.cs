using System;
using System.Data.SqlClient;
using AccessingNorthwind;

// Write a method that adds a new product in the products table in the Northwind database.
class InsertNewProduct
{
    static void Main()
    {
        int insertedID = InsertProduct();
        SelectProduct(insertedID);
        DeleteProduct(insertedID);
    }

    private static int InsertProduct()
    {
        var dbCon = new SqlConnection(Settings.Default.ConnectionsString);
        dbCon.Open();
        using (dbCon)
        {
            var cmdInsert = new SqlCommand(
                "INSERT INTO Products(ProductName, UnitPrice) VALUES(@productName, @unitPrice)",
                dbCon);

            cmdInsert.Parameters.AddWithValue("@productName", "Diuner");
            cmdInsert.Parameters.AddWithValue("@unitPrice", 3.50);

            // Execute INSERT
            Console.WriteLine("Inserting product...");
            int queryResult = cmdInsert.ExecuteNonQuery();

            // Get the ID of the inserted product
            var cmdIdentity = new SqlCommand("SELECT @@Identity", dbCon);
            int insertedID = (int)(decimal)cmdIdentity.ExecuteScalar();

            Console.WriteLine("{0} row(s) affected", queryResult);
            Console.WriteLine("Inserted ProductID = {0}", insertedID);

            return insertedID;
        }
    }

    private static void SelectProduct(int id)
    {
        var dbCon = new SqlConnection(Settings.Default.ConnectionsString);
        dbCon.Open();
        using (dbCon)
        {
            var cmdSelect = new SqlCommand(
                "SELECT ProductName, UnitPrice FROM Products WHERE ProductID = " + id,
                dbCon);

            var reader = cmdSelect.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Product: {0}, Price: {1:#.00}", reader["ProductName"], reader["UnitPrice"]);
            }
        }
    }

    private static void DeleteProduct(int id)
    {
        var dbCon = new SqlConnection(Settings.Default.ConnectionsString);
        dbCon.Open();
        using (dbCon)
        {
            var cmdDel = new SqlCommand("DELETE FROM Products WHERE ProductID = " + id, dbCon);
            Console.WriteLine("\nDeleting product with ProductID = {0}...", id);
            int queryResult = cmdDel.ExecuteNonQuery();
            Console.WriteLine("{0} row(s) affected", queryResult);
        }
    }
}
