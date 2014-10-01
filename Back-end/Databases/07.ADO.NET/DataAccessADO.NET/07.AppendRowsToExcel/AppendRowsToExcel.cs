using System;
using System.Data.OleDb;
using ConnectToExcelFile;

// Implement appending new rows to the Excel file.
class AppendRowsToExcel
{
    static void Main()
    {
        var dbCon = new OleDbConnection(Settings.Default.ConnectionString);
        dbCon.Open();
        using (dbCon)
        {
            var cmdInsert = new OleDbCommand(
                @"INSERT INTO [Sheet1$] (Name, Score) VALUES (@name, @score)",
                dbCon);
            cmdInsert.Parameters.AddWithValue("@name", "Todor Stoyanov");
            cmdInsert.Parameters.AddWithValue("@score", 100);

            int result = cmdInsert.ExecuteNonQuery();
            Console.WriteLine("{0} row(s) affected", result);
        }
    }
}
