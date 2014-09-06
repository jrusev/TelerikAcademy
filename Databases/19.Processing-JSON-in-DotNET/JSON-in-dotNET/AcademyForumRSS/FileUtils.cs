using System.IO;
using System.Text;

public static class FileUtils
{
    public static string ReadFile(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("File does not exist: " + path);
        }

        string textContent = string.Empty;

        using (var reader = new StreamReader(path))
        {
            textContent = reader.ReadToEnd();
        }

        return textContent;
    }

    public static void CreateFile(string path, string text)
    {
        using (var fileStream = new FileStream(path, FileMode.Create))
        {
            using (var streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
            {
                streamWriter.WriteLine(text);
            }
        }
    }
}
