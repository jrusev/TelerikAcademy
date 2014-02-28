using System;
using System.Collections;

internal class Program
{
    // Define a class BitArray64 to hold 64 bit values inside an ulong value.
    // Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.
    internal static void Main()
    {
        // Let's use int.MaxValue (32 one's) to set the BitArray64
        BitArray64 bitArray1 = new BitArray64(int.MaxValue);

        // Use IEnumerable to foreach the elements in the BitArray64
        Console.Write("bitArray1: ");
        foreach (var bit in bitArray1)
        {
            Console.Write(bit);
        }

        // Use BitArray64.ToString to print the second bitarray
        BitArray64 bitArray2 = new BitArray64(int.MaxValue - 1);
        Console.WriteLine("\nbitArray2: {0}", bitArray2);

        // Test BitArray64.Equals, ==, !=
        Console.WriteLine();
        Console.WriteLine("bitArray1.Equals(bitArray2) -> {0}", bitArray1.Equals(bitArray2));
        Console.WriteLine("(bitArray1 == bitArray2) -> {0}", bitArray1 == bitArray2);
        Console.WriteLine("(bitArray1 != bitArray2) -> {0}", bitArray1 != bitArray2);

        // Test BitArray64.GetHashCode
        Console.WriteLine();
        Console.WriteLine("bitArray1 HashCode: {0}", bitArray1.GetHashCode());
        Console.WriteLine("bitArray2 HashCode: {0}", bitArray2.GetHashCode());

        // Test indexers
        Console.WriteLine();
        Console.WriteLine("bitArray1[0] = {0}", bitArray1[0]);
        Console.WriteLine("bitArray2[0] = {0}", bitArray2[0]);
    }
}