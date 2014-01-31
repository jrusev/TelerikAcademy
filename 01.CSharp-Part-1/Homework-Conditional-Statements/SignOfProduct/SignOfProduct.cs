using System;

class SignOfProduct
{
    static void Main()
    {
        // Write a program that shows the sign (+ or -) of the product of three real numbers without calculating it. Use a sequence of if statements.

        Console.Write("a = ");
        float a = float.Parse(Console.ReadLine());
        Console.Write("b = ");
        float b = float.Parse(Console.ReadLine());
        Console.Write("c = ");
        float c = float.Parse(Console.ReadLine());

        byte countNegative = 0; // count how many negative numbers; if the number is even, the sign is positive;

        if (a==0 || b==0 || c==0)
        {
            Console.WriteLine("The product is 0."); // if any of the numbers is 0, the product is 0 and has no sign
        }
        else
        {
            if (a<0)
            {
                countNegative++;
            }
            if (b < 0)
            {
                countNegative++;
            }
            if (c < 0)
            {
                countNegative++;
            }
            Console.WriteLine("The sign of the product is  ({0}).", (countNegative % 2 == 0) ? "+" : "-");
        }
    }
}
