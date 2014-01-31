using System;
using System.Collections.Generic;

// Write a method that adds two positive integer numbers represented as arrays of digits
// Each array element arr[i] contains a digit; the last digit is kept in arr[0].
// Each of the numbers that will be added could have up to 10 000 digits.

/// <summary>Class HugeNumber represents positive integers with up to 10,000 digits.</summary>
class HugeNumber
{
    // The digits of the number are stored in a byte array
    private byte[] number;

    // The number of digits in the number
    private int Length
    {
        get { return number.Length; }
    }

    // Indexer accessor
    private byte this[int i]
    {
        // If index is out of range, the array will throw an exception.   
        get { return number[i]; }
    }

    // Constructor (from string)
    public HugeNumber(string s)
    {
        List<byte> num = new List<byte>(s.Length);
        bool firstNonZeroFround = (s.Length == 1); // Checks for leading zeros

        for (int i = 0; i < s.Length; i++)
        {
            int digit = s[i] - '0';

            if (digit < 0 || digit > 9)
            {
                // Throw an exception if the char is not a digit
                throw new Exception("Unable to parse number!");
            }

            if (firstNonZeroFround == false && digit > 0) firstNonZeroFround = true;

            if (firstNonZeroFround)
            {
                num.Add((byte)digit);
            }
        }
        num.Reverse();
        number = num.ToArray();
    }

    // Constructor (from array)
    public HugeNumber(byte[] array)
    {
        number = new byte[array.Length];
        Array.Copy(array, number, array.Length);
    }

    // Addition
    public static HugeNumber operator +(HugeNumber big, HugeNumber small)
    {
        // Determine which number has more digits
        if (big.Length < small.Length) return small + big;

        List<byte> result = new List<byte>(big.Length);

        // Sum the digits starting from the units
        byte rem = 0; // The remainder from the addition of the digits
        for (int i = 0; i < big.Length; i++)
        {
            if (i < small.Length) // both digits
            {
                result.Add((byte)((big[i] + small[i] + rem) % 10));
                rem = (byte)((big[i] + small[i] + rem) / 10);
            }
            else
            {
                result.Add((byte)((big[i] + rem) % 10));
                rem = (byte)((big[i] + rem) / 10);
            }
        }

        if (rem > 0) result.Add(rem);

        return new HugeNumber(result.ToArray());
    }

    // Allows printing of the number
    public override string ToString()
    {
        char[] result = new char[this.Length];
        for (int i = 0; i < this.Length; i++)
        {
            result[result.Length - 1 - i] = (char)(this[i] + '0');
        }
        return new String(result);
    }
}

class AddIntegersAsArrays
{
    static void Main()
    {
        Console.WriteLine("Enter some big positive integers:");

        Console.Write("a = ");
        HugeNumber a = new HugeNumber(Console.ReadLine());

        Console.Write("b = ");
        HugeNumber b = new HugeNumber(Console.ReadLine());

        HugeNumber c = a + b;
        Console.WriteLine("{0} + {1} = {2}", a, b, c);

        Console.WriteLine("\nWorks with arrays as well:");
        a = new HugeNumber(new byte[] { 3, 2, 1 });
        b = new HugeNumber(new byte[] { 6, 5, 4 });
        Console.WriteLine("{0} + {1} = {2}", a, b, a + b);

        //Test();
    }

    static void Test()
    {        
        HugeNumber a, b, c;
        Random rand = new Random();
        while (true)
        {
            Console.ReadKey(true);
            long num1 = rand.Next(1000);
            long num2 = rand.Next(20);
            long sum = num1 + num2;            

            a = new HugeNumber(num1.ToString());
            b = new HugeNumber(num2.ToString());
            c = a + b;
            Console.WriteLine("{0} + {1} = {2}", a, b, c);

            long result = long.Parse(c.ToString());
            if (result != sum)
            {
                Console.Write("Wrong! This is the correct result: ");
                Console.WriteLine("{0} + {1} = {2}", num1, num2, sum);
            }
        }
    }
}