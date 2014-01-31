using System;
using System.Net;

class DownloadFile
{
    static void Main()
    {
        // Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg)
        // and stores it the current directory. Find in Google how to download files in C#.
        // Be sure to catch all exceptions and to free any used resources in the finally block.

        using (WebClient webClient = new WebClient())
        {
            try
            {
                string address = "http://www.telerik.com/assets/img/telerik-navigation/telerik-logo.png";
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fileName = "logo.png";

                webClient.DownloadFile(address, desktop + "\\" + fileName);

                Console.WriteLine("{0} downloaded to your desktop.", fileName);                
            }

            catch (WebException)
            {
                Console.Error.WriteLine("The file does not exist or an error occurred while downloading data.");
            }

            catch (NotSupportedException)
            {
                Console.Error.WriteLine("The method has been called simultaneously on multiple threads.");
            }
        }
    }
}