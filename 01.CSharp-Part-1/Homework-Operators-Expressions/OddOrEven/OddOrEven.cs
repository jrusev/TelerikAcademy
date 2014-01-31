using System;

class OddOrEven
{
    static void Main()
    {
        // Write an expression that checks if given integer is odd or even.
        ConsoleKeyInfo choice;
        do
        {
            Console.Write("Please enter an integer: ");
            int number = Int32.Parse(Console.ReadLine());
            bool isEven = (number % 2 == 0);

            Console.WriteLine();
            Console.WriteLine(isEven ? "The number is even." : "The number is odd.");

            Console.Write("Do you wish to enter another number (Y/N)?");
            
            do
            {
                choice = Console.ReadKey(true);
            } while (choice.Key != ConsoleKey.Y && choice.Key != ConsoleKey.N);
            Console.Clear();

        } while (choice.Key == ConsoleKey.Y);
    }
}