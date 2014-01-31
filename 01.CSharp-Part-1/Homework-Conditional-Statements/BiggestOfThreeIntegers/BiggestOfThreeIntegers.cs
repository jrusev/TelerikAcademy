using System;

class BiggestOfThreeIntegers
{
    static void Main()
    {
        // Write a program that finds the biggest of three integers using nested if statements.
        Console.Write("integer a = ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("integer b = ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("integer c = ");
        int c = int.Parse(Console.ReadLine());

        int maxNum;
        if (a > b)
        {
            if (a>c)
            {
                maxNum = a; // a>b, a>c
            } 
            else
            {
                maxNum = c; // a>b, c>a
            }
        }
        else
        {
            if (b > c)
            {
                maxNum = b; // b>a, b>c
            }
            else
            {
                maxNum = c; // b>a, c>b
            }
        }
        Console.WriteLine("The biggest number is {0}.",maxNum);
    }
}