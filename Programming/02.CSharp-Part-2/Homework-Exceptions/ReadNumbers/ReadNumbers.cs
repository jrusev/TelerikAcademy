using System;

class ReadNumbers
{
    static void Main()
    {
        // Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end].
        // If an invalid number or non-number text is entered, the method should throw an exception.
        // Using this method write a program that enters 10 numbers:
        // a1, a2, … a10, such that 1 < a1 < … < a10 < 100

        int start = 1;
        int end = 100;

        for (int i = 0; i < 10; i++)
        {            
            try
            {
                // The new number becomes the low limit of the range
                start = ReadNumber(start, end);
            }

            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("The number is outside the range!");
            }

            catch (ArgumentNullException)
            {
                Console.Error.WriteLine("You entered a null string!");
            }

            catch (OverflowException)
            {
                Console.Error.WriteLine("The number is too big for a 32-bit signed integer!");
            }

            catch (FormatException)
            {
                Console.Error.WriteLine("That's not a number!");
            }
        }
    }

    static int ReadNumber(int start, int end)
    {
        Console.Write("Enter a number between {0} and {1}: ", start, end);

        string str = Console.ReadLine();
        int num = int.Parse(str);
        if (num <= start || num >= end )
            throw new ArgumentOutOfRangeException();
        return num;
    }
}