using System;

class HexToDecimal
{
    static void Main()
    {
        // Write a program to convert hexadecimal numbers to their decimal representation.

        Console.Write("Number in hex = 0x");
        string hex = Console.ReadLine();

        int dec = 0;
        int power = 1;
        int toBase = 16;
        for (int i = hex.Length - 1; i >= 0; i--)
        {
            int digit;
            if (hex[i] <= '9')
                digit = hex[i] - '0';
            else
                digit = char.ToUpper(hex[i]) - 'A' + 10;
            dec += digit * power;
            power *= toBase;
        }

        Console.Write("Decimal: ");
        Console.WriteLine(dec);

        // Check if the conversion was correct by converting the decimal back to hex
        bool isCorrect = hex.Equals(dec.ToString("X"), StringComparison.InvariantCultureIgnoreCase);
        if (!isCorrect) Console.WriteLine("Error!");
    }
}