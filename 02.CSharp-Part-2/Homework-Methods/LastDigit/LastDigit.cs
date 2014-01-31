using System;

class LastDigit
{
    static void Main()
    {
        // Write a method that returns the last digit of given integer as an English word.
        // Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine".

        Console.Write("Please enter an integer: ");
        int number = int.Parse(Console.ReadLine());

        int lastDigit = Math.Abs(number) % 10;
        Console.WriteLine("The last digit is {0}.", DigitToText(lastDigit));
    }

    static string DigitToText(int digit)
    {
        int index = Math.Abs(digit) % 10; // an extra check, to make sure index is always in the range [0;9]
        string[] digitWords = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        return digitWords[index];
    }
}
