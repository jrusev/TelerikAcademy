using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

internal class BooksSQLite
{
    private static void Main()
    {
        Console.WriteLine("All books in the library:");

        DataSet booksDataSet = GetAllBooks();
        PrintData(booksDataSet);

        Console.Write("Search book titles for: ");
        string searchString = Console.ReadLine();

        booksDataSet = FindBooks(searchString);
        PrintData(booksDataSet);
    }

    private static void PrintData(DataSet booksDataSet)
    {
        foreach (DataRow row in booksDataSet.Tables[0].Rows)
        {
            Console.WriteLine("{0, -25}{1, -20}", row["Title"], row["Author"]);
        }
    }

    private static DataSet FindBooks(string searchString)
    {
        searchString = searchString
            .Replace("%", "!%")
            .Replace("'", "!'")
            .Replace("\"", "!\"")
            .Replace("_", "!_")
            .ToLower();

        var dbCon = GetDbConnection();
        dbCon.Open();
        using (dbCon)
        {
            DataSet dataSet = new DataSet();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(
                string.Format(
                @"SELECT Title, Author FROM Books
                  WHERE LOWER(Title) LIKE '%{0}%' ESCAPE '!'", searchString),
                dbCon);

            adapter.Fill(dataSet);
            return dataSet;
        }
    }

    private static DataSet GetAllBooks()
    {
        var dbCon = GetDbConnection();
        dbCon.Open();
        using (dbCon)
        {
            var dataSet = new DataSet();
            var adapter = new SQLiteDataAdapter("SELECT Title, Author FROM Books", dbCon);

            adapter.Fill(dataSet);
            return dataSet;
        }
    }

    private static int InsertNewBook(string filePath, string title, string author, DateTime pubDate, string isbn)
    {
        var dbCon = GetDbConnection();
        dbCon.Open();
        using (dbCon)
        {
            var cmdInsrt = new SQLiteCommand(
                @"INSERT INTO Books (Title, Author, PubDate, ISBN)
                  VALUES (@Title, @Author, @PubDate, @isbn)", dbCon);

            cmdInsrt.Parameters.AddWithValue("@Title", title);
            cmdInsrt.Parameters.AddWithValue("@Author", author);
            cmdInsrt.Parameters.AddWithValue("@PubDate", pubDate);
            cmdInsrt.Parameters.AddWithValue("@isbn", isbn);

            int rowsAffected = cmdInsrt.ExecuteNonQuery();
            return rowsAffected;
        }
    }

    private static SQLiteConnection GetDbConnection()
    {
        return new SQLiteConnection("Data Source=" + @"..\..\Database\BookLibrary.sqlite" + ";Version=3;");
    }
}
