﻿using System;

public class MethodsTest
{
    public static void Main()
    {
        Console.WriteLine(Methods.CalcTriangleArea(3, 4, 5));

        Console.WriteLine(Methods.DigitToText(5));

        Console.WriteLine(Methods.FindMax(5, -1, 3, 2, 14, 2, 3));

        Console.WriteLine(Methods.FormatAsFloat(1.3));
        Console.WriteLine(Methods.FormatAsPercent(0.75));
        Console.WriteLine(Methods.FormatWithPadding(2.30, 8));

        Console.WriteLine(Methods.CalcDistance(3, -1, 3, 2.5));
        Console.WriteLine("Horizontal? " + Methods.IsHorizontal(3, -1, 3, 2.5));
        Console.WriteLine("Vertical? " + Methods.IsVertical(3, -1, 3, 2.5));

        var peter = new Student("Peter", "Ivanov", new DateTime(1992, 03, 17));
        peter.Town = "Sofia";

        var stella = new Student("Stella", "Markova", new DateTime(1993, 11, 03));
        stella.Town = "Vidin";
        stella.OtherInfo = "gamer, high results";

        Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
    }
}
