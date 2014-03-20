using System;

class SquareRoot
{
    static void Main()
    {
        // Write a program that reads an integer number and calculates and prints its square root.
        // If the number is invalid or negative, print "Invalid number".
        // In all cases finally print "Good bye". Use try-catch-finally.

        try
        {
            Console.Write("Please enter an integer: ");
            uint num = uint.Parse(Console.ReadLine());
            Console.WriteLine("SQRT({0}) = {1}", num, Math.Sqrt(num));
        }

        catch (ArgumentNullException)
        {
            Console.Error.WriteLine("Invalid number");
        }

        catch (FormatException)
        {
            Console.Error.WriteLine("Invalid number");
        }

        catch (OverflowException)
        {
            Console.Error.WriteLine("Invalid number");
        }

        finally
        {
            Console.WriteLine("Good bye!");
        }
    }
}