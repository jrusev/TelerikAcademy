using System;

class MultipleTasksIntegers
{
    static void Main()
    {
        // Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. Use variable number of arguments.

        PrintOperations(31, 52, 19, 43, 20);
    }

    static void PrintOperations(params int[] numbers)
    {
        Console.WriteLine("Numbers: " + String.Join(", ", numbers));
        Console.WriteLine("Minimum: " + Min(numbers));
        Console.WriteLine("Maximum: " + Max(numbers));
        Console.WriteLine("Sum: " + Sum(numbers));
        Console.WriteLine("Average: " + Average(numbers));
        Console.WriteLine("Product: " + Product(numbers));
        Console.WriteLine();
    }

    static int Min(params int[] numbers)
    {
        int min = numbers[0];
        foreach (var item in numbers)
            if (item < min) min = item;

        return min;
    }

    static int Max(params int[] numbers)
    {
        int max = numbers[0];
        foreach (var item in numbers)
            if (item > max) max = item;

        return max;
    }

    static long Sum(params int[] numbers)
    {
        long result = 0;
        foreach (var item in numbers) result += item;
        return result;
    }

    static double Average(params int[] numbers)
    {
        return (double)Sum(numbers) / numbers.Length;
    }

    static long Product(params int[] numbers)
    {
        long result = 1;
        foreach (var item in numbers) result *= item;
        return result;
    }
}
