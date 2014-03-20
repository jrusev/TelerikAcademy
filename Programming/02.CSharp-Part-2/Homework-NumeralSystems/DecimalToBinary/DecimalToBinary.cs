using System;

class DecimalToBinary
{
    static void Main()
    {
        // Write a program to convert decimal numbers to their binary representation.

        Console.Write("Number = ");
        int n = int.Parse(Console.ReadLine());

        string bits = "";
        while (n > 0)
        {
            bits = (n % 2) + bits;
            n /= 2;
        }
        Console.Write("Binary: ");
        Console.WriteLine(bits);
    }
}