using System;
using System.Globalization;

class WorkdaysToGivenDate
{
    static void Main()
    {
        // Write a method that calculates the number of workdays between today and given date, passed as parameter.
        // Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.

        Console.WriteLine("This program calculates the workdays between today and a given date.");
        Console.Write("Please enter a date in format dd/MM/yyyy: ");

        string dateString = Console.ReadLine();
        DateTime lastDay;
        try
        {
            lastDay = DateTime.ParseExact(dateString, "dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
        }
        catch (FormatException)
        {
            Console.WriteLine("{0} is not in the correct format.", dateString);
            return;
        }

        DateTime firstDay = DateTime.Today;

        // Let's add some public holidays
        DateTime[] publicHolidays =
        {
            // For 2014
            new DateTime(2013, 3, 3), // 3 март (понеделник) - Ден на Освобождението на България от османско иго – национален празник
            new DateTime(2013, 4, 18), // 18 април (петък)- Велики петък
            new DateTime(2013, 5, 6) // 6 май (вторник)- Гергьовден, Ден на храбростта и Българската армия
            // etc...
        };

        Console.WriteLine("There are {0} workdays from now to that date.", GetWorkDays(firstDay, lastDay, publicHolidays));
    }

    static int GetWorkDays(DateTime firstDay, DateTime lastDay, params DateTime[] publicHolidays)
    {
        if (firstDay > lastDay)
            throw new ArgumentException("Incorrect last day " + lastDay);

        int workDays = 0;
        for (DateTime date = firstDay; date <= lastDay; date = date.AddDays(1))
        {
            if (date.DayOfWeek != DayOfWeek.Saturday
                && date.DayOfWeek != DayOfWeek.Sunday)
                workDays++;
        }

        // Subtract the number of public holidays within the time interval
        foreach (DateTime publicHoliday in publicHolidays)
        {
            DateTime ph = publicHoliday.Date;
            if (firstDay <= ph && ph <= lastDay)
                workDays--;
        }

        return workDays;
    }
}