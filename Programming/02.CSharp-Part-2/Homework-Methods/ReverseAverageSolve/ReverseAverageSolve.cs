using System;
using System.Linq;

class ReverseAverageSolve
{
    static void Main()
    {
        /*
         * Write a program that can solve these tasks:
         *      Reverses the digits of a number
         *      Calculates the average of a sequence of integers
         *      Solves a linear equation a * x + b = 0
		 * Create appropriate methods.
		 * Provide a simple text-based menu for the user to choose which task to solve.
		 * Validate the input data:
         *     The decimal number should be non-negative
         *     The sequence should not be empty
         *     a should not be equal to 0
         */

        Console.WriteLine("This program can solve the following tasks:");
        Console.WriteLine("1) Reverse the digits of a number");
        Console.WriteLine("2) Calculate the average of a sequence of integers");
        Console.WriteLine("3) Solve a linear equation a * x + b = 0");
        Console.WriteLine("Please make your choice (press 1, 2 or 3): ");

        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.D1:
            case ConsoleKey.NumPad1:
                Task1();
                break;
            case ConsoleKey.D2:
            case ConsoleKey.NumPad2:
                Task2();
                break;
            case ConsoleKey.D3:
            case ConsoleKey.NumPad3:
                Task3();
                break;
            default:
                Console.WriteLine("Thank you!");
                return;
        }
    }

    static void Task1()
    {
        Console.Clear();
        Console.WriteLine("1) Reverse the digits of a number.");
        Console.Write("Please enter a positive number: ");
        decimal number;
        while (!decimal.TryParse(Console.ReadLine(), out number) || number < 0)
        {
            if (number < 0) Console.WriteLine("The number must be positive!"); // The number should be non-negative
            else Console.WriteLine("Invalid input!"); // Not a number
        }
        Console.WriteLine("Reversed: {0}", ReverseDecimal(number));
    }

    static void Task2()
    {
        Console.Clear();
        Console.WriteLine("2) Calculate the average of a sequence of integers.");
        Console.Write("Please enter some numbers separated by space: ");

        string input = Console.ReadLine();
        // The sequence should not be empty
        while (input == "")
        {
            Console.WriteLine("There must be at least one number");
            input = Console.ReadLine();
        }

        string[] numberStrings = input.Split(' ');

        int[] numbers = new int[numberStrings.Length];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(numberStrings[i]);
        }
        Console.WriteLine("Average: {0}", AverageIntegers(numbers));
    }

    static void Task3()
    {
        Console.Clear();
        Console.WriteLine("3) Solve a linear equation a * x + b = 0.");

        int a;
        do
        {
            Console.Write("a = ");
            a = int.Parse(Console.ReadLine());
            if (a == 0) Console.WriteLine("a should not be equal to 0");
        } while (a == 0); // 'a' should not be equal to 0

        Console.Write("b = ");
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine("{0} * x + {1} = 0", a, b);
        Console.WriteLine("Soluton: x={0}", SolveEquation(a,b));
    }

    /// <summary>Reverses the digits of given decimal number.</summary>
    static decimal ReverseDecimal(decimal number)
    {
        // Convert the number to string
        string numStr = number.ToString();

        // Reverse the string
        char[] numArr = numStr.ToCharArray();
        Array.Reverse(numArr);

        // Parse back to decimal
        decimal reversedNumber = decimal.Parse(new String(numArr));

        return reversedNumber;
    }

    /// <summary>Calculates the average of a sequence of integers.</summary>
    static double AverageIntegers(params int[] numbers)
    {
        return numbers.Average(); // Uses LINQ
    }

    /// <summary> Solves a linear equation a * x + b = 0</summary>
    static double SolveEquation(double a, double b)
    {
        return -b / a;
    }
}