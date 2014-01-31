using System;

class FindBit3
{
    static void Main()
    {
        // Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.
        Console.Write("Please enter an integer number: ");
        int number = Int32.Parse(Console.ReadLine());
        int mask = 1 << 3;
        int result = number & mask;
        bool bit3Is1 = (result != 0);

        Console.WriteLine();
        Console.WriteLine("{0,32} binary", Convert.ToString(number, 2));
        Console.WriteLine("{0,32} mask", Convert.ToString(mask, 2));
        Console.WriteLine("{0,32} result", Convert.ToString(result, 2));
        Console.WriteLine(bit3Is1 ? "Bit 3 (counting from 0) is 1." : "Bit 3 (counting from 0) is 0.");
    }
}