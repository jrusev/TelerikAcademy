using System;

class BinaryRepresentationOfShort
{
    static void Main()
    {
        // Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).

        short num = -29;

        int size = sizeof(short) * 8; // 16

        // Read and show every bit going from left to right
        for (int i = size - 1; i >= 0; i--) Console.Write((num >> i) & 1);
        Console.WriteLine();

        //Console.WriteLine(Convert.ToString(num, 2).PadLeft(16, '0'));
    }
}