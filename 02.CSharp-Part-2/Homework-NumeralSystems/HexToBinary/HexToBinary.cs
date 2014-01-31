using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class HexToBinary
{
    static void Main()
    {
        // Write a program to convert hexadecimal numbers to binary numbers (directly).

        Console.Write("Number in hex = 0x");
        string hex = Console.ReadLine();

        Console.Write("Binary: ");
        Console.WriteLine(HexStringToBinary(hex));
    }

    //Convert hexadecimal numbers to binary numbers
    static string HexStringToBinary(string hex)
    {
        Dictionary<char, string> hexCharToBinary = new Dictionary<char, string>
        {
            // Contains the binary representation of each hexadecimal symbol
            { '0', "0000" },
            { '1', "0001" },
            { '2', "0010" },
            { '3', "0011" },
            { '4', "0100" },
            { '5', "0101" },
            { '6', "0110" },
            { '7', "0111" },
            { '8', "1000" },
            { '9', "1001" },
            { 'A', "1010" },
            { 'B', "1011" },
            { 'C', "1100" },
            { 'D', "1101" },
            { 'E', "1110" },
            { 'F', "1111" }
        };

        StringBuilder binary = new StringBuilder();
        foreach (char symbol in hex)
        {
            binary.Append(hexCharToBinary[char.ToUpper(symbol)]);
        }

        return binary.ToString();
    }

    // This method uses a single array instead of a dictionary
    static string HexStringToBinaryWithArray(string hex)
    {
        string[] digitsBin = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };

        string bin = string.Empty; ;
        foreach (char symbol in hex)
        {
            int digit;
            if (symbol <= '9')
                digit = symbol - '0';
            else
                digit = char.ToUpper(symbol) - 'A' + 10;

            bin += digitsBin[digit];
        }
        return bin;
    }
}
