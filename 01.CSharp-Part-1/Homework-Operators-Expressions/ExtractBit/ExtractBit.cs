using System;

class ExtractBit
{
    static void Main()
    {
        // Write an expression that extracts from a given integer i the value of a given bit number b. Example: i=5; b=2 -> value=1.

        Console.Write("Please enter an integer: ");
        int i = Int32.Parse(Console.ReadLine());
        Console.Write("Bit number: ");
        byte b = byte.Parse(Console.ReadLine());

        int mask = 1 << b;
        int result = i & mask;
        byte bit_b = (byte)( (result != 0) ? 1 : 0 );

        Console.WriteLine("The value of bit {0} in number {1} is {2}.",b,i, bit_b);
        //Console.WriteLine("Number {0} in bynary format is 0x{1}.", i, Convert.ToString(i, 2));
    }
}