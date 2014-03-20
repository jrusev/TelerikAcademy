using System;

class MaxFiveVars
{
    static void Main()
    {
        // Write a program that finds the greatest of given 5 variables.
        Console.WriteLine("Please enter five numbers (press Enter after each number)...");
        double maxNumber = double.Parse(Console.ReadLine()); // maxNumber will hold the biggest number; we initialize it with the first number
        //... and we have 4 more numbers to read
        for (int i = 0; i < 4; i++)
        {
            // Math.Max() compares the input from the console with maxValue, and returns the bigger number; we assign it to maxNumber
            maxNumber = Math.Max(double.Parse(Console.ReadLine()),maxNumber);
        }
        Console.WriteLine("The greatest of the five numbers is {0}.", maxNumber);
    }
}