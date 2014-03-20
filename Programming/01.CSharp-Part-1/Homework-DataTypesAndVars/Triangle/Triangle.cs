using System;

class Triangle
{
    static void Main()
    {
        // Write a program that prints an isosceles triangle of 9 copyright symbols ©.
        // Note: the © symbol may be displayed incorrectly.

        Console.Write("Enter total number of \"©\" elements: "); // enter 9; try 1600 for a big triangle :)
        int totalBricks = int.Parse(Console.ReadLine());
        char copyRight = '\u00A9';
        int height = (int)Math.Sqrt(totalBricks); // calculate the height of the triangle from the number of bricks (building blocks)

        for (int i = 1; i <= height; i++)
        {
            Console.Write(new string(' ', height - i)); // prints blank space repeated (height - i) number of times
            Console.WriteLine(new string(copyRight, 2 * i - 1)); // prints © repeated (2 * i - 1) number of times
        }

        //Console.WriteLine();
        //Console.Write("Press any key to continue... ");
        //Console.ReadKey(true);
    }
}