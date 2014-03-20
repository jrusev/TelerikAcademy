using System;
using System.Globalization;

class HourMinuteSecond
{
    static void Main()
    {
        // Write a program that reads a date and time given in the format: day.month.year hour:minute:second
        // and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.

        DateTime date;
        try
        {
            Console.WriteLine("Please enter a date in the format [day.month.year hour:minute:second]");
            Console.Write(">");
            date = ParseDateTime(Console.ReadLine());

            DateTime laterDate = date.AddHours(6.5);
            string dayOfWeekBG = laterDate.ToString("dddd", new CultureInfo("bg-BG"));

            Console.WriteLine("After 6.5 hours it will be: {0:dd.MM.yyyy HH:mm:ss}, {1}", laterDate, dayOfWeekBG);
        }
        catch (FormatException)
        {
            Console.WriteLine("The date you entered was not in the correct format!");
        }
    }

    // Parse a date enetered as a string in the format dd.MM.yyyy HH:mm:ss
    static DateTime ParseDateTime(string dateString)
    {
        string[] dateTokens = dateString.Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);

        string[] datePart = dateTokens[0].Split('.');
        string[] hourPart = dateTokens[1].Split(':');

        return new DateTime(
            int.Parse(datePart[2]), // year
            int.Parse(datePart[1]), // month
            int.Parse(datePart[0]), // day
            int.Parse(hourPart[0]), // hour
            int.Parse(hourPart[1]), // minute
            int.Parse(hourPart[2])  // second
            );
    }
}