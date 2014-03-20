using System;
using System.Collections.Generic;
using System.Diagnostics;

class SieveEratosthenes
{
    static void Main()
    {
        // Write a program that finds all prime numbers in the range [1...10 000 000].
        // Use the sieve of Eratosthenes algorithm:
        // http://en.wikipedia.org/wiki/Sieve_of_Eratosthenes#Algorithm_description

        int n = 10000000; // 10000000

        // use a stopwatch to measure how long it takes to find the numbers
        Stopwatch sw = Stopwatch.StartNew();
        List<int> primes = FastPrimes(n); // the list of primes
        sw.Stop(); // stop the watch

        Console.WriteLine("There are {0} primes in the range [1...{1}].", primes.Count, n);
        Console.WriteLine("Numbers found in {0} milliseconds", sw.ElapsedMilliseconds);
        Console.Write("Do you want to print all numbers (takes 30 seconds)? (Y/N)");
        if (Console.ReadKey(true).Key == ConsoleKey.Y)
        {
            // print the numbers
            Console.WriteLine();
            for (int i = 0; i < primes.Count; i++)
            {
                Console.Write("{0,5} ", primes[i]);
                if ((i + 1) % 10 == 0)
                    Console.WriteLine(); // print 10 numbers per line
            }
        }
        Console.WriteLine();
    }

    static List<int> FastPrimes(int limit)
    {
        // generates a list of all primes from 1 to <limit>
        bool[] sieve = new bool[(limit - 1) / 2]; // create a sieve for the odd numbers
        int pMax = (int)Math.Sqrt(limit);
        for (int p = 3, index = 0; p <= pMax; p += 2, index++)
        {
            if (sieve[index] == false) // skip allready marked numbers
            {
                int step = p + p;
                for (int multiple = p * p; multiple <= limit; multiple += step)
                    sieve[(multiple - 3) / 2] = true; // is composite
            }
        }
        List<int> primes = new List<int>(); // the approx size is = limit / ln(limit)
        primes.Add(2); // add the first prime (2) manually
        for (int i = 0; i < sieve.Length; i++)
        {
            if (sieve[i] == false)
                primes.Add(2 * i + 3);
        }
        return primes;
    }
}
