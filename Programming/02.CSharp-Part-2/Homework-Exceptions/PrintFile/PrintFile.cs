using System;
using System.IO;

class PrintFile
{
    static void Main()
    {
        // Write a program that enters file name along with its full file path
        // (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console.
        // Find in MSDN how to use System.IO.File.ReadAllText(…).
        // Be sure to catch all possible exceptions and print user-friendly error messages.

        Console.WriteLine(@"Enter the file path (for example: ...\...\PrintFile.cs ): ");
        Console.Write(">");

        try
        {
            string filePath = Console.ReadLine();
            string fileContent = File.ReadAllText(filePath);
            Console.WriteLine(fileContent);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("The path contains invalid characters.");
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("The specified path is too long.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("The specified path is invalid or the directory cannot be found.");
        }
        catch (IOException)
        {
            Console.WriteLine("An Input/Output error occured.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access denied because of an I/O error or a specific type of security error.");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("The path is in an invalid format.");
        }
    }
}