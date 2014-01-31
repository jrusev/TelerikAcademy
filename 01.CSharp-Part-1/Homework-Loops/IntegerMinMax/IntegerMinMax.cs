using System;

class IntegerMinMax
{
    static void Main()
    {
        // Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.

        Console.Write("How many numbers do you want to input? ");
        int numbersLength = int.Parse(Console.ReadLine());
        int numberMax = int.MinValue;
        int numberMin = int.MaxValue;
        int[] number = new int[numbersLength];
        for (int i = 0; i < numbersLength; i++)
        {
            Console.Write("N{0} = ",i+1);
            number[i] = int.Parse(Console.ReadLine());
            if (number[i] > numberMax)
            {
                numberMax = number[i];
            }
            if (number[i] < numberMin)
            {
                numberMin = number[i];
            }
        }
        Console.WriteLine("The greatest number is {0}.",numberMax);
        Console.WriteLine("The smallest number is {0}.", numberMin);
    }
}