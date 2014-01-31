using System;

class MultipleTasksGeneric
{
    static void Main()
    {
        // Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers.
        // Use variable number of arguments.
        // Make the program work for any number type, not just integer (e.g. decimal, float, byte, etc.).

        int[] numbersInt32 = { 31, 52, 19, 43, 20 };
        double[] numbersDouble = { 3.1, 5.2, 1.9, 4.3, 2d };
        decimal[] numbersDecim = { 3.1m , 5.2m, 1.9m, 4.3m , 2m };
        float[] numbersFloat = { 3.1f, 5.2f, 1.9f, 4.3f, 2f };

        PrintOperations(numbersInt32);
        PrintOperations(numbersDouble);
        PrintOperations(numbersDecim);
        PrintOperations(numbersFloat);
    }

    static void PrintOperations<T>(params T[] numbers) where T : IComparable<T>
    {
        Console.WriteLine("Type: {0}", numbers[0].GetType());
        Console.WriteLine("Numbers: " + String.Join(", ", numbers));
        Console.WriteLine("Minimum: " + Min(numbers));
        Console.WriteLine("Maximum: " + Max(numbers));
        Console.WriteLine("Sum: " + Sum(numbers));
        Console.WriteLine("Average: " + Average(numbers));
        Console.WriteLine("Product: " + Product(numbers));
        Console.WriteLine();
    }

    static T Min<T>(params T[] numbers) where T : IComparable<T>
    {
        T min = numbers[0];
        foreach (var item in numbers)
            if (item.CompareTo(min) == -1) min = item;

        return min;
    }

    static T Max<T>(params T[] numbers) where T : IComparable<T>
    {
        T max = numbers[0];
        foreach (var item in numbers)
            if (item.CompareTo(max) == 1) max = item;

        return max;
    }

    static T Sum<T>(params T[] numbers)
    {
        dynamic result = 0;
        foreach (var item in numbers) result += item;            
        return result;
    }

    static double Average<T>(params T[] numbers)
    {
        double ave = Convert.ToDouble(Sum(numbers)) / numbers.Length;
        return ave;
    }

    static T Product<T>(params T[] numbers)
    {
        dynamic result = 1;
        foreach (var item in numbers) result *= item;
        return result;
    }
}
