using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class Program
{
    static void Main()
    {
        var occurances = Console.ReadLine()
            .ToCharArray()
            .GroupBy(ch => ch)
            .Select(gr => gr.Count())
            .ToArray();
        Console.WriteLine(Multinominal(occurances));
    }

    public static BigInteger Multinominal(int[] numbers)
    {
        int numbersSum = 0;
        foreach (var number in numbers)
            numbersSum += number;

        BigInteger nominator = Factorial(numbersSum);

        BigInteger denominator = 1;
        foreach (var number in numbers)
            denominator *= Factorial(number);

        return nominator / denominator;
    }

    public static BigInteger Factorial(int n)
    {
        BigInteger result = 1;
        for (int i = 1; i <= n; i++)
            result = result * i;
        return result;
    }
}