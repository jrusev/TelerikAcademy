using System;

class SomeRandomValues
{
    static void Main()
    {
        // Write a program that generates and prints to the console 10 random values in the range [100, 200].

        Console.WriteLine("Ten random values in the range [100, 200]:");

        Random rand = new Random();
        int minValue = 100;
        int maxValue = 200;
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(rand.Next(minValue, maxValue + 1));
        }
    }
}