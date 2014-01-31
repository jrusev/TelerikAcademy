using System;

class StringFormats
{
    static void Main()
    {
        // Write a program that reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation.
        // Format the output aligned right in 15 symbols.

        int num;
        do
        {
            Console.Write("Please enter an integer number: ");
        } while (!int.TryParse(Console.ReadLine(), out num));

        // The format specifier takes the form Axx, where A is an alphabetic character called the format specifier,
        // and xx is an optional integer called the precision specifier.
        Console.WriteLine("Decimal: {0,15:F}", num);
        Console.WriteLine("Hexadecimal: {0,15:X}", num);
        Console.WriteLine("Percent: {0,15:P}", num);
        Console.WriteLine("Exponential: {0,15:E}", num);
    }
}