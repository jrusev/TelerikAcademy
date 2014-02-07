using System;
using System.Linq;

internal class DivisibleBySevenAndThree
{
    // Write a program that prints from given array of integers all numbers that are divisible by 7 and 3.
    // Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.
    private static void Main()
    {
        int[] nums = { 1, 2, 3, 7, 21, 25, 42, 43 };
        Console.WriteLine("Integers: {0}", String.Join(", ", nums));

        // With extension methods
        var divisible = nums.Where(num => num % 21 == 0).Select(num => num);
        Console.WriteLine("Divisible by 3 and 7: {0}", String.Join(", ", divisible));

        // With LINQ query
        var numsQuery = from num in nums
                        where num % 21 == 0
                        select num;
        Console.WriteLine("Divisible by 3 and 7: {0}", String.Join(", ", numsQuery));
    }
}