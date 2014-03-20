using System;

class ExchangeBits345
{
    static void Main()
    {
        // Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.

        Console.Write("Please enter a positive integer: ");
        uint number = UInt32.Parse(Console.ReadLine());
        Console.WriteLine("\nThe program will exchange bits 3, 4 and 5 with bits 24, 25 and 26 of the number.\n");

        uint newNumber = number; // this will be the new number, with the exchnaged bits
        for (byte positionP = 3, positionQ = 24; positionP <= 5; positionP++, positionQ++) // the cycle will run 3 times
        {
            // check the values of bits 3, 4 and 5 and and write them on position 24, 25 and 26
            if ((number & (1 << positionP)) != 0)
            {
                newNumber = newNumber | (1u << positionQ); // set the bit to 1
            }
            else
            {
                newNumber = newNumber & ~(1u << positionQ); // set the bit to 0
            }
            // check the values of bits 24, 25 and 26 and write them on position 3, 4 and 5
            if ((number & (1 << positionQ)) != 0)
            {
                newNumber = newNumber | (1u << positionP); // set the bit to 1
            }
            else
            {
                newNumber = newNumber & ~(1u << positionP); // clear the bit to 0
            }
        }

        Console.WriteLine("Old number = {0}", number);
        Console.WriteLine("New number = {0}", newNumber);

        Console.WriteLine("\nIn binary format...");
        Console.WriteLine("Old number = {0}", Convert.ToString(number, 2).PadLeft(32,'0'));
        Console.WriteLine("New number = {0}", Convert.ToString(newNumber, 2).PadLeft(32, '0'));
    }
}