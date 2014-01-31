using System;
using System.Numerics;

class IntegerNumbersNX
{
    static void Main()
    {
        // Write a program that, for a given two integer numbers N and X, calculates the sumS = 1 + 1!/X + 2!/X2 + … + N!/XN

        Console.Write("Enter integer N: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter integer X: ");
        int x = int.Parse(Console.ReadLine());
        double sum = 1;
        for (int i = 1; i <= n; i++)
        {
            sum = sum + ((double)Factorial(i) / (Math.Pow(x, i))); // calling the Factorial method declared below
        }
        Console.WriteLine("S = {0}",sum);
    }

    static BigInteger Factorial(int num) // calculate factorial in a separate method
    {
        BigInteger result = 1; // we need BigInteger type as the result can quickly overflow even for small numbers (num>20)
        while (num > 1)
        {
            result *= num;
            num--;
        }
        return result;
    }
}