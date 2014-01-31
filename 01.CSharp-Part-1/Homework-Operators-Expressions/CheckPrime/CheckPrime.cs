using System;

class CheckPrime
{
    static void Main()
    {
        // Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.

        Console.Write("Please enter a positive integer less than 100: ");
        byte number;
        while (true)
        {
            bool isByte = byte.TryParse(Console.ReadLine(), out number); // if isByte is true, then the number is an integer from 0 to 255;
            if(isByte && number <=100)
            {
                break;
            }
            Console.Write("Please enter a valid number: "); // this will be repeated until the user enters a positive integer less than 100
        }

        bool isPrime = number > 1; // 0 and 1 are not prime numbers (but they are also not composite numbers)

        for (int i = 2; i <= (int)Math.Sqrt(number); i++) // this cycle will not run if the number is 0 or 1
        {
            if(number % i == 0)
            {
                isPrime = false;
                break;
            }            
        }

        Console.WriteLine(isPrime ? "The number {0} is prime." : "The number {0} is not prime.",number);

        //// Print all prime numbers from 1 to 100
        //Console.Write("Primes: ");
        //for (int integer = 2; integer < 100; integer++)
        //{
        //    isPrime = true;
        //    for (int divisor = 2; divisor <= (int)Math.Sqrt(integer); divisor++)
        //    {
        //        if (integer % divisor == 0)
        //        {
        //            isPrime = false;
        //            break;
        //        }
        //    }
        //    Console.Write(isPrime ? "{0} " : "", integer);
        //}
        //Console.WriteLine();
    }
}