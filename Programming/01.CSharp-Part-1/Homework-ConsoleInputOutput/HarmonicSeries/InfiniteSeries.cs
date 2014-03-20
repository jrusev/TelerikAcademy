using System;

class InfiniteSeries
{
    static void Main()
    {
        // Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...

        double sum = 1;
        for (int i = 2, sign = 1; i <= 1000 ; i++) // if i > 1000, the difference between two consecutive values of the sum will be less than 1/1000 or 0.001
        {
            sum = sum + sign * (1d / i);
            sign = -1 * sign; 
        }
        Console.WriteLine("1 + 1/2 - 1/3 + 1/4 - 1/5 + ... = {0}",sum );
    }
}