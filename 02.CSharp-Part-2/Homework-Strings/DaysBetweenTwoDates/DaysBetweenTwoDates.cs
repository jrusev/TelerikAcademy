using System;

class DaysBetweenTwoDates
{
    static void Main()
    {
        // Write a program that reads two dates in the format: day.month.year and calculates the number of days between them.
        // Example:
        // Enter the first date: 27.02.2006
        // Enter the second date: 3.03.2006
        // Distance: 4 days

        Console.WriteLine("Please enter two dates in the folloing format day.month.year: ");

        DateTime date1, date2;
        try
        {
            Console.Write("First date: ");
            date1 = ParseDateTime(Console.ReadLine());

            try
            {
                Console.Write("Second date: ");
                date2 = ParseDateTime(Console.ReadLine());

                TimeSpan span = date1 - date2;
                Console.WriteLine("There are {0} days between these two dates.",Math.Abs(span.Days));
            }
            catch (FormatException)
            {

                Console.WriteLine("The date you entered was not in the correct format!");
            }
        }
        catch (FormatException)
        {
            
            Console.WriteLine("The date you entered was not in the correct format!");
        }
    }

    static DateTime ParseDateTime(string dateString)
    {
        string[] dateTokens = dateString.Split('.');
        return new DateTime(int.Parse(dateTokens[2]), int.Parse(dateTokens[1]), int.Parse(dateTokens[0]));
    }
}
