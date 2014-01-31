using System;
using System.Text;

class ReverseDigits
{
    static void Main()
    {
        // Write a method that reverses the digits of given decimal number. Example: 256 -> 652

        while (true) // Let's test many numbers
        {
            Console.Write("Please enter a decimal number: ");
            string numStr = Console.ReadLine();

            decimal number;
            if (!decimal.TryParse(numStr, out number))
                Console.WriteLine("This is not a decimal number!");
            else
                Console.WriteLine("This is the reversed number:   {0}\n", ReverseDecimal(number));
            Console.WriteLine();
        }
    }

    /// <summary>Reverses the digits of given decimal number.</summary>
    /// <param name="number">The number to reverse.</param>
    /// <returns>Returns the reversed number as decimal.</returns>
    static decimal ReverseDecimal(decimal number)
    {
        // Convert the number to string
        string numStr = number.ToString();

        // Reverse the string
        string numStrReversed = ReverseString(numStr);

        // Parse the string to decimal and return
        decimal reversedNumber = decimal.Parse(numStrReversed);
        return reversedNumber;
    }

    static string ReverseString(string text)
    {
        char[] array = text.ToCharArray();
        Array.Reverse(array);
        return new String(array);
    }
}