using System;
using System.Collections.Generic;

class BigFactorials
{
    static void Main()
    {
        // Write a program to calculate n! for each n in the range [1..100].
        // Implement first a method that multiplies a number represented as array of digits by given integer number.
        
        int n = 100;
        // We will use the class HugeNumber we created in Problem 8
        HugeNumber factorial = new HugeNumber(new byte[] { 1 });
        for (int i = 1; i <= n; i++)
        {
            factorial = factorial * i;
            Console.WriteLine("{0}! = {1}", i, factorial);

            if (i != n)
            {
                Console.Write("Press any key to see the next factorial...");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
    }
}

/// <summary>Represents a positive integer with up to 10,000 digits.</summary>
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

    // Multiplication (HugeNumber * int)
    public static HugeNumber operator *(HugeNumber big, int small)
    {
        HugeNumber result = new HugeNumber(new byte[] { 0 });
        for (int i = 0; i < small; i++)
        {
            result = result + big;
        }
        return result;
    }

    // Multiplication (int * HugeNumber)
    public static HugeNumber operator *(int small, HugeNumber big)
    {
        HugeNumber result = new HugeNumber(new byte[] { 0 });
        for (int i = 0; i < small; i++)
        {
            result = result + big;
        }
        return result;
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