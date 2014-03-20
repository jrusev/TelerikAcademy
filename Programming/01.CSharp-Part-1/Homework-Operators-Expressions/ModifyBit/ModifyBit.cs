using System;

class ModifyBit
{
    static void Main()
    {
        // We are given integer number n, value v (v=0 or 1) and a position p.
        // Write a sequence of operators that modifies n to hold the value v at the position p from the binary representation of n.
        // Example: n = 5 (00000101), p=3, v=1 -> 13 (00001101)
        // n = 5 (00000101), p=2, v=0 -> 1 (00000001)

        Console.Write("Please enter an integer: ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("Enter position of bit: ");
        byte position = byte.Parse(Console.ReadLine());
        Console.Write("Value of the bit (0 or 1): ");
        byte value = byte.Parse(Console.ReadLine());

        int newNumber;
        if(value == 0)
        {
            newNumber = number & ~(1 << position); // clear the bit to 0
        }
        else
        {
            newNumber = number | (1 << position); // set the bit to 1
        }
        Console.WriteLine("The new number is {0}.",newNumber);
    }
}