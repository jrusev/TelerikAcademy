using System;

class AssignHEX
{
    static void Main()
    {
        // Declare an integer variable and assign it with the value 254 in hexadecimal format.
        int hex = 0xFE ; // 254 in decimal format
        string hexString = "0xFE";
        Console.WriteLine("{0} in hexadecimal format is {1}.", hex, hexString);
    }
}