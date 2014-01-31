using System;

class ConvertBetweenNumeralSystems
{
    static void Main()
    {
        // Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).

        Console.Write("Enter numeral system s = ");
        int fromBase = int.Parse(Console.ReadLine());
        while (fromBase > 36)
        {
            Console.WriteLine("The base must be less than 36 (maximum of 10 digits and 26 letters).");
            fromBase = int.Parse(Console.ReadLine());
        }

        Console.Write("OK, hit me with the number: ");
        string numString = Console.ReadLine();

        while (!ValidateNumber(numString, fromBase))
        {
            Console.WriteLine("This is not a valid number in this base!");
            numString = Console.ReadLine();
        }

        int toBase;
        do
        {
            Console.Write("What numeral system do you want to convert it to [2;16]: ");
            toBase = int.Parse(Console.ReadLine());

        } while (toBase < 2 || toBase >16);

        string converted = ConvertFromAnyBase(numString, fromBase, toBase);
        Console.WriteLine("This is the number in base ({0}) : {1}", toBase, converted);
    }

    // Validates if the string contains only symbols within its base
    // For example: 7 is not a valid symbol in base 6
    static bool ValidateNumber(string numString, int fromBase)
    {
        bool result = true;
        foreach (char symbol in numString)
        {
            int digit;
            if (symbol <= '9')
                digit = symbol - '0';
            else
                digit = char.ToUpper(symbol) - 'A' + 10;

            if (digit < 0 || digit >= fromBase) return false;
        }
        return result;
    }

    // Converts from any base to any other base, by making an intermediate conversion to decimal
    static string ConvertFromAnyBase(string numString, int fromBase, int toBase)
    {
        int numInDecimal = ConvertAnyToDecimal(numString, fromBase);
        string result = ConvertDecToAny(numInDecimal, toBase);
        return result;
    }

    // Converts a number in any base to its decimal representation.
    static int ConvertAnyToDecimal(string numString, int fromBase)
    {
        int num = 0;
        int power = 1;
        for (int i = numString.Length - 1; i >= 0; i--)
        {
            int digit;
            if (numString[i] <= '9')
                digit = numString[i] - '0';
            else
                digit = char.ToUpper(numString[i]) - 'A' + 10;
            num += digit * power;
            power *= fromBase;
        }
        return num;
    }

    // Converts a decimal number to any base from 2 to 16
    static string ConvertDecToAny(int num, int toBase)
    {
        string result = "";
        char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        while (num > 0)
        {
            result = digits[num % toBase] + result;
            num /= toBase;
        }
        return result;
    }
}