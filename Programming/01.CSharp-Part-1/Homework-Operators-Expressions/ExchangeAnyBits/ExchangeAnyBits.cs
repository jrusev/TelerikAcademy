using System;

class ExchangeAnyBits
{
    static void Main()
    {
        // Write a program that exchanges bits {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.

        Console.WriteLine("Please enter the following parameters...");
        Console.Write("number i = ");
        uint number = UInt32.Parse(Console.ReadLine());
        Console.Write("position p = ");
        byte p = byte.Parse(Console.ReadLine());
        Console.Write("position q = ");
        byte q = byte.Parse(Console.ReadLine());
        Console.Write("number of bits k = ");
        byte k = byte.Parse(Console.ReadLine());
        // NOTE: All kinds of checks should be made on the input numbers for the program to work correctly, which will skip for simplicity

        Console.WriteLine("\nThe program will exchange bits [{0} to {1}] with bits [{2} to {3}] of the number.\n",p,p+k-1,q,q+k-1);

        // Very clever solution from Bit Twiddling Hacks: http://goo.gl/ynXX1z
        uint temp = ((number >> p) ^ (number >> q)) & ((1u << k) - 1);
        uint newNumber = number ^ ((temp << p) | (temp << q));
        // Done, the bits are swapped! For exaplanation see the example at the end of this method.

        Console.WriteLine("Old number = {0}", number);
        Console.WriteLine("New number = {0}", newNumber);

        // To check for correctness we may want to print the numbers in binary format, 
        // but we want to insert some spearation around the exchanged bits to make them stand out

        // First we read all 32 bits and store them in an array of type bool (true = 1, false = 0)
        bool[] oldNumBits = new bool[32];
        bool[] newNumBits = new bool[32];

        for (int i = 0; i <32 ; i++)
        {
            oldNumBits[i] = ((number & (1 << i)) != 0);
            newNumBits[i] = ((newNumber & (1 << i)) != 0);
        }
        // now oldNumBits and newNumBits contain all 32 bits of our numbers as a series of true and false values

        Console.WriteLine("\nIn binary format with separation...");
        // print the old number
        Console.Write("Old number: ");
        for (int i = 31; i >= 0; i--)
        {
            if (i == p + k - 1 || i == q + k - 1)
            {
                Console.Write(" [");
            }
            Console.Write(Convert.ToInt32(oldNumBits[i])); // converts bool to int
            if (i == p || i == q)
            {
                Console.Write("] ");
            }
        }
        // print the new number
        Console.WriteLine();
        Console.Write("New number: ");
        for (int i = 31; i >= 0; i--)
        {
            if (i == p + k - 1 || i == q + k - 1)
            {
                Console.Write(" [");
            }
            Console.Write(Convert.ToInt32(newNumBits[i])); // converts bool to int
            if (i == p || i == q)
            {
                Console.Write("] ");
            }
        }
        Console.WriteLine();

        /*
        Example for Bit Twiddling Hacks method:
        In the number 47 we want to swap 3 bits starting from bit 5 with 3 bits starting from bit 1
        number = 47
        p = 5
        q = 1
        k = 3

        00101111 number 47
        00000001 number >> 5
        00010111 number >> 1
        00010110 (number >> 5) ^ (number >> 1)
        00001000 (1 << 3)
        00000111 (1 << 3) - 1
        00000110 ((number >> 5) ^ (number >> 1)) & ((1 << 3) - 1)
        11000000 temp << 5
        00001100 temp << 1
        11001100 ((temp << 5) | (temp << 1))
        11100010 number ^ ((temp << 5) | (temp << 1))  ... bits are now swapped
		
		Here is what happens:
		We use two XOR operations. The first XOR's the bits we need to swap. The result is '1' where the bits are different and '0' where they are the same.
		So with the first XOR operation we obtain a mask that tells us which bits need to be reversed.
		Then we do a second XOR with each group of bits and the mask.
		The result is that the mask reverses the different bits in each group,
		so the bits in the first group become the same as the bits in the second group and vica versa.
		There is one extra hack - the expression ((1 << k) - 1)), creates a mask with zeros and 1 at position 'k'.
		If you subtract 1 from this number, the 1 bit becomes zero and all bits right of that bit become 1's.
		For example, for k=3, we have 1 << 3 = 0x1000, then 8 - 1 = 0x0111.
        If we AND this mask with a number, it will clear all bits but the last three.
        */
    }
}