// Create a console application that calculates and prints the square of the number 12345.

using System;

class SquareOf12345
{
    static void Main()
    {
        int num = 12345;
        double square = Math.Pow(num, 2);
        double squareRoot = Math.Sqrt(num); // let's calculate the square root too

        Console.WriteLine("The square of {0} is {1} and the square root is {2}.", num, square, squareRoot);
    }
}