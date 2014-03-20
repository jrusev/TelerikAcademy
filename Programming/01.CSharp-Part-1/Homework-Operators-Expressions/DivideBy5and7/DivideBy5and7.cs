using System;

class DivideBy5and7
{
    static void Main()
    {
        // Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.

        Console.Write("Please enter an integer: ");
        int number = Int32.Parse(Console.ReadLine());
        bool dividesBy5n7 = (number % 5 == 0) && (number % 7 == 0); // you can also check (number % 35 == 0)

        Console.WriteLine();

        if (dividesBy5n7)
        {
            Console.WriteLine("The number {0} can be divided (without remainder) by 5 and 7.", number);
        }
        else
        {
            Console.WriteLine("The number {0} cannot be divided (without remainder) by 5 and 7.", number);
        }
    }
}