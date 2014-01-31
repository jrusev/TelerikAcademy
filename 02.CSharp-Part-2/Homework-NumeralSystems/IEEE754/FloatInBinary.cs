using System;

class FloatInBinary
{
    static void Main()
    {
        // Write a program that shows the internal binary representation
        // of given 32-bit signed floating-point number in IEEE 754 format (the C# type float).
        // Example: -27.25 -> sign = 1, exponent = 10000011, mantissa = 10110100000000000000000.

        // See: http://en.wikipedia.org/wiki/IEEE_754-1985#Representation_of_numbers

        float num = -27.25f; // 1 _ 1000 0011 _ 101 1010 0000 0000 0000 0000.
        Console.WriteLine("Float: {0}", num);

        // Convert the number to a sequence of 4 bytes
        byte[] byteArray = BitConverter.GetBytes(num); // Length = 4

        // Print the binary represenation
        PrintFloatBinary(byteArray);
        Console.WriteLine();

        // Sign (1 bit)
        int sign = GetSign(byteArray);

        // Exponent (8 bits)
        byte[] exponent = GetExponent(byteArray);

        // Mantissa (23 bits)
        byte[] mantissa = GetMantissa(byteArray);


        // Print the bits separated according to the IEEE 754 format
        Console.Write("IEEE 754: ");
        Console.Write("{0} ", sign);
        Console.Write("{0} ", String.Join("", exponent));
        Console.Write("{0} ", String.Join("", mantissa));
        Console.WriteLine();

        // Print the sign, exponent and mantissa 
        Console.WriteLine("sign = {0}", sign);
        Console.WriteLine("exponent = {0}", String.Join("", exponent));
        Console.WriteLine("mantissa = {0}", String.Join("", mantissa));
    }

    // Print the binary representation of a C# type float
    static void PrintFloatBinary(byte[] byteArray)
    {
        // Four sequences of 8 bits, separated by space
        Console.Write("Binary: ");
        for (int i = byteArray.Length - 1; i >= 0; i--)
        {
            Console.Write(Convert.ToString(byteArray[i], 2).PadLeft(8, '0') + ' ');
        }
        Console.WriteLine();
    }

    static int GetSign(byte[] byteArray)
    {
        return (byteArray[3] >> 7) & 1; // Take the first bit from this byte
    }

    static byte[] GetExponent(byte[] byteArray)
    {
        // Exponent (8 bits)
        byte[] exponent = new byte[8];
        for (int i = 6; i >= 0; i--) // Take the last 7 bits from this byte
        {
            exponent[6 - i] = (byte)((byteArray[3] >> i) & 1);
        }
        exponent[7] = (byte)((byteArray[2] >> 7) & 1); // ... and the first bit from this byte
        return exponent;
    }

    static byte[] GetMantissa(byte[] byteArray)
    {
        // Mantissa (23 bits)
        byte[] mantissa = new byte[23];
        int m = 0; // index for the mantissa
        for (int i = 6; i >= 0; i--) // Take the last 7 bits from this byte
        {
            mantissa[m] = (byte)((byteArray[2] >> i) & 1);
            m++;
        }
        for (int i = 7; i >= 0; i--) // Take all bits from this byte
        {
            mantissa[m] = (byte)((byteArray[1] >> i) & 1);
            m++;
        }
        for (int i = 7; i >= 0; i--) // Take all bits from this byte
        {
            mantissa[m] = (byte)((byteArray[0] >> i) & 1);
            m++;
        }
        return mantissa;
    }
}
