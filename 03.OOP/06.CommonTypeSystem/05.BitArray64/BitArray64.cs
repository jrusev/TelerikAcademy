using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

// Define a class BitArray64 to hold 64 bit values inside an ulong value.
// Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.
public class BitArray64 : IEnumerable<int>
{
    private const byte Size = 64;
    private ulong bits;

    public BitArray64(ulong bits)
    {
        this.bits = bits;
    }

    /// <summary>
    /// Gets the value of the bit at a specific position in the BitArray64.
    /// </summary>
    /// <param name="index">The zero-based index of the value to get.</param>
    /// <returns>The int value of the bit at position index.</returns>
    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= BitArray64.Size)
            {
                throw new ApplicationException("Index is outside the range of the BitArray64!");
            }

            return (int)((this.bits >> index) & 1);
        }
    }

    public static bool operator ==(BitArray64 ba1, BitArray64 ba2)
    {
        return BitArray64.Equals(ba1, ba2);
    }

    public static bool operator !=(BitArray64 ba1, BitArray64 ba2)
    {
        return !BitArray64.Equals(ba1, ba2);   
    }

    public override bool Equals(object obj)
    {
        BitArray64 ba = obj as BitArray64;
        if (ba == null)
        {
            return false;
        }

        return this.bits == ba.bits;
    }

    public override int GetHashCode()
    {
        return this.bits.GetHashCode();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder(BitArray64.Size);
        foreach (var bit in this)
        {
            sb.Append(bit);
        }

        return sb.ToString();
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < BitArray64.Size; i++)
        {
            yield return this[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        for (int i = 0; i < BitArray64.Size; i++)
        {
            yield return this[i];
        }
    }
}