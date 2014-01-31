using System;

class BinaryToDecimal
{
    static void Main()
    {
        // Write a program to convert binary numbers to their decimal representation.

        Console.Write("Number in binary = 0x");
        string bin = Console.ReadLine();

        int dec = 0;
        int power = 1;
        int fromBase = 2;
        for (int i = bin.Length - 1; i >= 0; i--)
        {
            int digit = bin[i] - '0';
            dec += digit * power;
            power *= fromBase;
        }

        Console.Write("Decimal: ");
        Console.WriteLine(dec);

        // Check if the conversion was correct
        bool isCorrect = Convert.ToInt32(bin, 2) == dec;
        if (!isCorrect) Console.WriteLine("Error!");
    }
}