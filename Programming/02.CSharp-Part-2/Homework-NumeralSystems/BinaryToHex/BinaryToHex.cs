using System;
using System.Collections.Generic;
using System.Text;

class BinaryToHex
{
    static void Main()
    {
        // Write a program to convert binary numbers to hexadecimal numbers (directly).

        Console.Write("Number in binary = 0x");
        string binary = Console.ReadLine();

        Console.Write("HEX: ");
        Console.WriteLine(BinaryStringToHex(binary));
    }

    //Convert hexadecimal numbers to binary numbers
    static string BinaryStringToHex(string bin)
    {
        Dictionary<string, char> BinarySnippetToHex = new Dictionary<string, char>
        {
            // Contains the binary representation of each hexadecimal symbol
            { "0000", '0' },
            { "0001", '1' },
            { "0010", '2' },
            { "0011", '3' },
            { "0100", '4' },
            { "0101", '5' },
            { "0110", '6' },
            { "0111", '7' },
            { "1000", '8' },
            { "1001", '9' },
            { "1010", 'A' },
            { "1011", 'B' },
            { "1100", 'C' },
            { "1101", 'D' },
            { "1110", 'E' },
            { "1111", 'F' }
        };

        // Add leading zeros
        int rest = bin.Length % 4;
        if (rest > 0)
            bin = new string('0', 4- rest) + bin;

        StringBuilder hex = new StringBuilder();
        for (int i = 0; i < bin.Length; i = i + 4)
        {
            string snippet = bin.Substring(i, 4); // Take 4 symbols (e.g. "1010")
            hex.Append(BinarySnippetToHex[snippet]); // ... and find their hex match ('A')
        }
        return hex.ToString();
    }
}
