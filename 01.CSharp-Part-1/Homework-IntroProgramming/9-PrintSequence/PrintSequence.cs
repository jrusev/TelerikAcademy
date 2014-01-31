//Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...

using System;

class PrintSequence
{
    static void Main()
    {
        Console.WriteLine("First ten members of the sequence are:");

        for (int i = 2; i < 12; i++)
        {
            if (i % 2 == 0)
            {
                Console.Write(i + ", ");
            }
            else
            {
                Console.Write(-i + ", ");
            }
        }

        Console.WriteLine("\nDifferent algorithm:");

        // less code, but calls the power method to change the sign
        for (int i = 1; i <= 10; i++)
        {
            Console.Write((i + 1) * Math.Pow(-1, ((i + 1) % 2)) + ", ");
        }
    }
}