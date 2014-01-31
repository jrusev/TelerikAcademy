using System;

class CheckLeapYear
{
    static void Main()
    {
        // Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.

        while (true)
        {
            Console.Write("Please enter a year: ");
            uint year = uint.Parse(Console.ReadLine()); // e.g. 2012 is a leap year

            bool isLeap = DateTime.IsLeapYear((int)year);
            string answer = String.Format("{0} is {1}a leap year.", year, isLeap ? "" : "not ");

            Console.WriteLine(answer);
            Console.WriteLine();
        }
    }
}