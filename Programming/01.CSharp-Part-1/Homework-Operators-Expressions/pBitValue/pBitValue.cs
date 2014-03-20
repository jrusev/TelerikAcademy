using System;

class pBitValue
{
    static void Main()
    {
        // Write a boolean expression that returns if the bit at position p (counting from 0) in a given integer number v has value of 1.
        // Example: v=5; p=1 -> false.

        Console.Write("Please enter an integer: ");
        int number = Int32.Parse(Console.ReadLine());
        Console.Write("Position of the bit (counting from 0): ");
        byte position = byte.Parse(Console.ReadLine());

        int mask = 1 << position;
        int result = number & mask;

        bool bit_p_is1 = (result != 0); // if the bit has a value of 1, this will be true

        Console.WriteLine("Bit {0} in number {1} is {2}.",position,number, bit_p_is1 ? 1 : 0);
        //Console.WriteLine("Number {0} in bynary format is 0x{1}.", number, Convert.ToString(number, 2));
    }
}