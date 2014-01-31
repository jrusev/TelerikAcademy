using System;

class NullableTypes
{
    static void Main()
    {
        // Create a program that assigns null values to an integer and to double variables.
        // Try to print them on the console, try to add some values or the null literal to them and see the result.
        int? numInteger = null;
        double? numDouble = null;
        Console.WriteLine("null integer = {0}",numInteger);
        Console.WriteLine("null double = {0}", numDouble);

        Console.WriteLine("null integer + 5 = {0}", numInteger + 5);
        Console.WriteLine("null integer + null = {0}", numInteger + null);

        Console.WriteLine("null integer + null double = {0}", numInteger + numDouble);

        numInteger = 1024;
        Console.WriteLine("null integer = {0}", numInteger);
    }
}