using System;

class GCD
{
    static void Main()
    {
        // Write a program that calculates the greatest common divisor (GCD) of given two numbers. Use the Euclidean algorithm.

        /* Formal description of the Euclidean algorithm
         * Input two positive integers, a and b.
         * If a<b, exchange a and b.
         * Divide a by b and get the remainder, r. If r=0, report b as the GCD of a and b.
         * Replace a by b and replace b by r. Return to the previous step.
         */

        Console.Write("First integer: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Second integer: ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("The greatest common divisor of {0} and {1} is ", a, b);
        if (a<b) // exchange a and b
        {
            int temp = a;
            a = b;
            b = temp;
        }
        int r;
        do
        {
            r = a % b;
            a = b;
            b = r;           
        } while (r!=0);
        Console.Write(a); // original values of a and b are lost with this implementation; a will return the GCD
        Console.WriteLine();
    }
}
