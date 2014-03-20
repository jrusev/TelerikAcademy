using System;

class IntDoubleString
{
    static void Main()
    {
        /* Write a program that, depending on the user's choice inputs int, double or string variable.
         * If the variable is integer or double, increases it with 1. If the variable is string, appends "*" at its end.
         * The program must show the value of that variable as a console output. Use switch statement.
         */

        Console.Write("Press <I> for int, <D> for double or <S>  for string: ");
        string choice = Console.ReadKey().Key.ToString(); // we read just one key (no need to press Enter), and convert it to string
        Console.WriteLine();
        switch (choice)
        {
            case "D":
                Console.Write("Enter a number of type double: ");
                double numDouble = double.Parse(Console.ReadLine());
                Console.WriteLine("{0} + 1 = {1}", numDouble, numDouble + 1);
                break;
            case "I":
                Console.Write("Enter a number of type integer: ");
                int numInt = int.Parse(Console.ReadLine());
                Console.WriteLine("{0} + 1 = {1}", numInt, numInt + 1);
                break;
            case "S":
                Console.Write("Enter a string: ");
                string numString = Console.ReadLine();
                Console.WriteLine("Your string plus '*' = {0}", numString + "*");
                break;
            default:
                Console.WriteLine("Choice not recognized.");
                break;
        }
    }
}