using System;
using System.Text;

class EncodeDecode
{
    static void Main()
    {
        // Write a program that encodes and decodes a string using given encryption key (cipher).
        // The key consists of a sequence of characters.
        // The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with the first of the key,
        // the second – with the second, etc. When the last key character is reached, the next is the first.

        string key = "whatisthematrix";
        string str = "Some message to encode/decode";
        StringBuilder encripted = new StringBuilder();

        int i = 0;
        foreach (char letter in str)
        {
            encripted.Append((char)(letter ^ key[i]));
            if (i == key.Length - 1) i = 0;
            else i++;
        }

        Console.WriteLine(encripted.ToString());
    }
}