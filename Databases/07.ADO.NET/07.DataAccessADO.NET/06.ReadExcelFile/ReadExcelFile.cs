using System;
using System.Data.OleDb;
using ConnectToExcelFile;

// Create an Excel file with 2 columns: name and score.
// Write a program that reads your MS Excel file through the OLE DB data provider
// and displays the name and score row by row.
class ReadExcelFile
{    
    static void Main()
    {
        var dbCon = new OleDbConnection(Settings.Default.ConnectionString);
        dbCon.Open();
        using (dbCon)
        {
            var cmdGetTable = new OleDbCommand("SELECT * FROM [Sheet1$]", dbCon);

            var reader = cmdGetTable.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0,-15} | {1,5}", reader["Name"], reader["Score"]);
                }
            }
        }
    }
}
