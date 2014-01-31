using System;

class SumNumbersN
{
    static void Main()
    {
        // Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum. 

        Console.Write("Please enter how many number you want to input: ");
        int totalNumbers = int.Parse(Console.ReadLine());
        float sum = 0;

        if (totalNumbers > 0)
        {
            for (int i = 0; i < totalNumbers; i++)
            {
                Console.Write("Number {0}: ", i + 1);
                float nextNumber = float.Parse(Console.ReadLine());
                sum += nextNumber;
            }
            Console.WriteLine("The sum of the numbers is {0}.",sum);            
        }
    }
}