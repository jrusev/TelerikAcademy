using System;
using System.Numerics;

class ExpressionNKNK
{
    static void Main()
    {
        // Write a program that calculates N!*K! / (N-K)! for given N and K (1<K<N).

        Console.Write("Please enter integer N: ");
        int n = int.Parse(Console.ReadLine());
        int k;
        while (true)
        {
            Console.Write("Please enter integer K (K<N): ");
            k = int.Parse(Console.ReadLine());
            if (k < n) { break; }
        }
        BigInteger result = 1; // BigInteger type represents an arbitrarily large integer
        for (int i = 1; i <= n; i++)
        {
            if ((k < (n - k))) // we will use if() statements to cancel the devision
            {
                if ((i <= k) || (i > (n - k)))
                {
                    result = result * i;
                }
            }
            else
            {
                result = result * i;
                if ((i > n - k) && (i <= k))
                {
                    result = result * i;
                }
            }
        }
        Console.WriteLine("{0}! * {1}! / ({0}-{1})! = {2}", n, k, result);
    }
}
