using System;

class Unicode72
{
    static void Main()
    {
        // Declare a character variable and assign it with the symbol that has Unicode code 72.

        char symb = '\u0048'; // hexadecimal format of 72 is 0x48
        char symb2 = (char)72; // alternative method

        Console.WriteLine("The character with Unicode code 72 is \'{0}\'.", symb);
    }
}