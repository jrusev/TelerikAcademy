using System;

class Numbers1toN37
{
    static void Main()
    {
        // Write a program that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time.

		Console.Write("Please an integer N: ");
		int n = int.Parse(Console.ReadLine());

		for (int i = 1; i <= n; i++)
		{
            if (i % (3*7) != 0 ) // the condition will skip 21, 42, 63, 84....
            {
                Console.Write("{0} ",i);
            }
		}
        Console.WriteLine();
    }
}
