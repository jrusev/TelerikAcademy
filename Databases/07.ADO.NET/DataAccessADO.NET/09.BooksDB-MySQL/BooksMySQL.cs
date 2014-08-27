using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

// Create a MySQL database to store Books (title, author, publish date and ISBN).
// Write methods for listing all books, finding a book by name and adding a book.
class BooksMySQL
{
    // Please, run the script in "CreateLibraryDB-MySQL.sql" in MySQL
    static void Main()
    {
        var dbCon = ConnectToDatabase();

        int bookCount = 3;
        IList<object[]> booksProperties = CreateBooks(bookCount);

        AddNewBooks(booksProperties, dbCon);
        Console.WriteLine(">{0} books added to the database", bookCount);

        IList<string> books = ListAllBooks(dbCon);
        Console.WriteLine(">All books in the database are: ");
        foreach (string book in books)
        {
            Console.WriteLine(book);
        }

        string bookTitle = "Title_2";
        string bookInfo = GetBookByTitle(bookTitle, dbCon);
        if (bookInfo != null)
        {
            Console.WriteLine(">Seach for book with title '{0}': \n{1}", bookTitle, bookInfo);
        }
        else
        {
            Console.WriteLine(">There is no book with title {0}", bookTitle);
        }
    }

    private static MySqlConnection ConnectToDatabase()
    {
        Console.Write("Enter your password for MySQL server: ");
        string pass = Console.ReadLine();

        var connStr = "Server=localhost;Database=Library;Uid=root;Pwd=" + pass + ";";
        var dbCon = new MySqlConnection(connStr);
        return dbCon;
    }

    static string GetBookByTitle(string bookTitle, MySqlConnection dbConnection)
    {
        dbConnection.Open();
        using (dbConnection)
        {
            var cmdFind = new MySqlCommand(
                "SELECT Title, Author, PublishDate, ISBN FROM Books WHERE Title = @title",
                dbConnection);

            cmdFind.Parameters.AddWithValue("@title", bookTitle);
            var reader = cmdFind.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                string bookInfo = ReadBookInfo(reader);
                return bookInfo;
            }
            else
            {
                return null;
            }
        }
    }

    static IList<string> ListAllBooks(MySqlConnection dbConnection)
    {
        dbConnection.Open();
        using (dbConnection)
        {
            var books = new List<string>();

            var cmdSelect = new MySqlCommand("SELECT Title, Author, PublishDate, ISBN FROM Books", dbConnection);

            var reader = cmdSelect.ExecuteReader();
            while (reader.Read())
            {
                string bookInfo = ReadBookInfo(reader);
                books.Add(bookInfo);
            }

            return books;
        }
    }

    static void AddNewBooks(IList<object[]> booksDetails, MySqlConnection dbConnection)
    {
        dbConnection.Open();
        using (dbConnection)
        {
            var cmdInsert = new MySqlCommand(
                @"INSERT INTO Books (Title, Author, PublishDate, ISBN)
                    VALUES (@title, @author, @publishDate, @isbn)", dbConnection);

            for (int i = 0; i < booksDetails.Count; i++)
            {
                cmdInsert.Parameters.AddWithValue("@title", booksDetails[i][0] as string);
                cmdInsert.Parameters.AddWithValue("@author", booksDetails[i][1] as string);
                var publishDate = new MySqlParameter("@publishDate", booksDetails[i][2] as DateTime?);
                if (booksDetails[i][2] == null)
                {
                    publishDate.Value = DBNull.Value;
                }

                cmdInsert.Parameters.Add(publishDate);
                cmdInsert.Parameters.AddWithValue("@isbn", booksDetails[i][3] as string);

                int rowsAffected = cmdInsert.ExecuteNonQuery();
                Console.WriteLine("{0} row(s) affected", rowsAffected);
                cmdInsert.Parameters.Clear();
            }
        }
    }

    static IList<object[]> CreateBooks(int bookCount)
    {
        IList<object[]> books = new List<object[]>(bookCount);
        for (int i = 0; i < bookCount; i++)
        {
            object[] bookProperties = new object[4];
            bookProperties[0] = string.Format("Title_{0}", i);
            bookProperties[1] = string.Format("Author_{0}", i);
            bookProperties[2] = DateTime.Now.Subtract(new TimeSpan(i, 0, 0, 0));
            bookProperties[3] = (1000000000000 + i).ToString();

            books.Add(bookProperties);
        }

        return books;
    }

    private static string ReadBookInfo(MySqlDataReader reader)
    {
        StringBuilder buffer = new StringBuilder();
        buffer.AppendFormat("Title: {0}{1}", (string)reader["Title"], Environment.NewLine);
        buffer.AppendFormat("Author: {0}{1}", (string)reader["Author"], Environment.NewLine);
        buffer.AppendFormat("Publish date: {0}{1}", reader["PublishDate"] == DBNull.Value ?
            "Unknown" : ((DateTime)reader["PublishDate"]).ToShortDateString(), Environment.NewLine);
        buffer.AppendFormat("ISBN: {0}{1}", (string)reader["ISBN"], Environment.NewLine);
        return buffer.ToString();
    }
}
