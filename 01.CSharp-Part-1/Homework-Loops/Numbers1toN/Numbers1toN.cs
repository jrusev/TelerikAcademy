// Write a program that prints all the numbers from 1 to N.
using System;

class Numbers1toN
{
    static void Main()
	{
		Console.Write("Please an integer N: ");
		int n = int.Parse(Console.ReadLine());
		for (int i = 1; i < n; i++)
		{
			Console.Write("{0}, ",i);
		}
        Console.WriteLine("{0}", n); // print this separately so there is no comma after the number
	}
}