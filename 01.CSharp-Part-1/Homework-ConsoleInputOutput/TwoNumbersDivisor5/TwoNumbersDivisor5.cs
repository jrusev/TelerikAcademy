using System;
using System.Text;

class TwoNumbersDivisor5
{
    static void Main()
    {
        /* Write a program that reads two positive integer numbers
         * and prints how many numbers p exist between them such that the reminder of the division by 5 is 0 (inclusive).
         * Example: p(17,25) = 2.
         */

        Console.Write("Enter the first positive integer: ");
        uint num1 = uint.Parse(Console.ReadLine());
        Console.Write("Enter the second positive integer: ");
        uint num2 = uint.Parse(Console.ReadLine());

        uint lowLimit = Math.Min(num1, num2);
        uint highLimit = Math.Max(num1, num2);
        int p = 0;

        StringBuilder numbers = new StringBuilder();

        for (int i = (int)lowLimit; i <= highLimit; i++)
        {
            if (i % 5 == 0)
            {
                p++;
            }
        }

        if (p==1)
        {
            Console.WriteLine("There is one number between {0} and {1}, whose reminder of the division by 5 is 0.", lowLimit,highLimit);
        }
        else if (p>1)
        {
            Console.WriteLine("There are {0} numbers between {1} and {2}, whose reminder of the division by 5 is 0.", p,lowLimit,highLimit);
        }
        else
        {
            Console.WriteLine("There are no numbers between {0} and {1}, whose reminder of the division by 5 is 0.",lowLimit,highLimit);
        }
    }
}