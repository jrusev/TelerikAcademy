using System;

class DecimalToHex
{
    static void Main()
    {
        // Write a program to convert decimal numbers to their hexadecimal representation.

        Console.Write("Number = ");
        int num = int.Parse(Console.ReadLine());

        string hex = "";
        int toBase = 16;
        int n = num;
        char[] digitsHex = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        while (n > 0)
        {
            hex = digitsHex[n % toBase] + hex;
            n /= toBase;
        }
        Console.Write("Hex: 0x");
        Console.WriteLine(hex);


        // Check if the conversion was correct by converting the hex back to decimal
        bool isCorrect = num.Equals(Convert.ToInt32(hex, 16));
        if (!isCorrect) Console.WriteLine("Error!");
    }
}
