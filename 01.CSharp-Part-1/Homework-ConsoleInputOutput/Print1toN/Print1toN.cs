using System;

class Print1toN
{
    static void Main()
    {
        // Write a program that reads an integer number n from the console and prints all the numbers in the interval [1..n], each on a single line.

        Console.Write("Please enter a positive integer: ");
        int nMax = int.Parse(Console.ReadLine());

        for (int i = 1; i <= nMax; i++)
        {
            Console.WriteLine(i);
        }
    }
}