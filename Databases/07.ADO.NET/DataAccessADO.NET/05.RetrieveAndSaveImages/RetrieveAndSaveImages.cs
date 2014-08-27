using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

// Write a program that retrieves the images for all categories in the Northwind database
// and stores them as JPG files in the file system.
class RetrieveAndSaveImages
{
    static void Main()
    {
        var dbCon = new SqlConnection(@"Server=.\SQLEXPRESS; Database=Northwind; Integrated Security=true;");

        dbCon.Open();
        using (dbCon)
        {
            var command = new SqlCommand("SELECT CategoryName, Picture FROM Categories", dbCon);

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var name = reader["CategoryName"].ToString().Replace('/', '_');

                const int PICT_START_POSITION = 78;

                // The files will go to "\bin\Debug" directory
                using (var fs = File.OpenWrite(name + ".bmp"))
                using (var stream = reader.GetStream(1))
                {
                    stream.Seek(PICT_START_POSITION, SeekOrigin.Begin);
                    stream.CopyTo(fs);
                }
            }
        }
    }
}
