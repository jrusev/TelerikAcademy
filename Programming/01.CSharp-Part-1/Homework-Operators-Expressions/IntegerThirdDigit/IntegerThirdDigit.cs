using System;

class IntegerThirdDigit
{
    static void Main()
    {
        // Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732 -> true.
        Console.WriteLine("Please enter an integer number: ");
        int number = Int32.Parse(Console.ReadLine()); // let's say the number is 1732
        int number100 = Math.Abs(number / 100); // the result will be 17 (integer division); use Abs to remove a minus sign
        int thirdDigit = number100 % 10; // the remainder of dividing 17 by 10 is 7 
        Console.WriteLine("The thrid digit is {0}.",thirdDigit);
    }
}
