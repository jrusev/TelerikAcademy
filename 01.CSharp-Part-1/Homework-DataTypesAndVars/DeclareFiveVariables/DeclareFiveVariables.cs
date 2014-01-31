using System;

class DeclareFiveVariables
{
    static void Main()
    {
        // Declare five variables choosing for each of them the most appropriate of the types byte, sbyte, short, ushort, int, uint, long, ulong
        // Values are: 52130, -115, 4825932, 97, -10000.
        ushort a = 52130;   // 0 to 65535
        sbyte b = -115;     // -128 to 127
        int c = 4825932;    // -2,147,483,648 to 2,147,483,647
        byte d = 97;        // 0 to 255
        short e = -10000;   // -32,768 to 32,767
        long f = a + b + c + d + e; // unknown value, so better use the biggest integer data type - signed, 64-bit
        Console.WriteLine("The sum of the numbers is {0}.",f); //
    }
}