using System;

public class Program
{
    public static void Main()
    {
        double[] arr = { 1, 2, 3, 4, 5 };
        Console.WriteLine(string.Join(", ", arr));
        PrintStatistics(arr);
    }

    public static void PrintStatistics(params double[] arr)
    {
        var max = GetMax(arr);
        var min = GetMin(arr);
        var avg = GetAvg(arr);

        Console.WriteLine("Max = {0}", max);
        Console.WriteLine("Min = {0}", min);
        Console.WriteLine("Avg = {0}", avg);
    }

    private static double GetAvg(double[] arr)
    {
        double sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        double average = sum / arr.Length;
        return average;
    }

    private static double GetMin(double[] arr)
    {
        double min = arr[0];
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }

        return min;
    }

    private static double GetMax(double[] arr)
    {
        double max = arr[0];
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }

        return max;
    }
}
