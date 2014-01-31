using System;

class BonusScores
{
    static void Main()
    {
        // Write a program that applies bonus scores to given scores in the range [1..9].
        // The program reads a digit as an input. If the digit is between 1 and 3, the program multiplies it by 10;
        // if it is between 4 and 6, multiplies it by 100; if it is between 7 and 9, multiplies it by 1000.
        // If it is zero or if the value is not a digit, the program must report an error.
        // Use a switch statement and at the end print the calculated new value in the console.
        Console.Write("Please enter a digit: ");
        int digit;
        int score = -1; // initialize score with -1
        if (!int.TryParse(Console.ReadLine(), out digit))
        {
            Console.WriteLine("Error!"); // the user did not enter an integer number
        }
        else
        {
            switch (digit)
            {
                case 1:
                case 2:
                case 3:
                    score = digit * 10;
                    break;
                case 4:
                case 5:
                case 6:
                    score = digit * 100;
                    break;
                case 7:
                case 8:
                case 9:
                    score = digit * 1000;
                    break;
            }
            // if the number was not a digit, <score> will remain -1, otherwise it will be positive
            Console.WriteLine((score > 0) ? "New score: {0}." : "Error!", score);
        }
    }
}