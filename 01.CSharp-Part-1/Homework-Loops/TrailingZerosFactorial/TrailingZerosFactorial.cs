using System;
using System.Numerics;

class TrailingZerosFactorial
{
    static void Main()
    {
        // Write a program that calculates for given N how many trailing zeros present at the end of the number N!. Examples:
	    // N = 10 -> N! = 3628800 -> 2
	    // N = 20 -> N! = 2432902008176640000 -> 4
        // Does your program work for N = 50 000?
        // Hint: The trailing zeros in N! are equal to the number of its prime divisors of value 5.

        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());

        int temp = n - (n % 5); // get the biggest number smaller than N that divides by 5 (without remainder)
        int countZeros = 0;
        while (temp >= 5)
        {
            countZeros++; // we know that 'temp' divides by 5 at least once
            int result = temp / 5; // ...so we divide it by 5
            while (result % 5 == 0) // ...and check again the resulting number
            {
                countZeros++;
                result = result / 5;
            }
            temp = temp - 5; // we can skip 5 numbers to get the next number that divides by 5
        }
        Console.WriteLine("{0}! has {1} zero{2}", n, countZeros, countZeros != 1 ? "s" : ""); // 50000! has 12499 zeros

        // let's calculate the factorial and print it to see if we got the zeros right
        BigInteger factorial = 1;
        int num = n;
        while (num > 1)
        {
            factorial *= num;
            num--;
        }
        Console.WriteLine("{0}! = {1} ({2} zero{3})", n, factorial, countZeros, countZeros != 1 ? "s" : ""); // print the factorial and number of zeros
    }
}