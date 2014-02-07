using System;
using System.Text;

public static class StringBuilderExtensions
{
    /// <summary>
    /// Retrieves a substring starting at a specified character position and has a specified length.
    /// </summary>
    /// <param name="startIndex">The zero-based starting character position of a substring in this instance.</param>
    /// <param name="length">The length of the substring.</param>
    public static StringBuilder Substring(this StringBuilder sb, int startIndex, int length)
    {
        if (startIndex < 0 || startIndex > sb.Length)
        {
            throw new ArgumentOutOfRangeException("The index is less than zero or greater than the length of the string.");
        }

        if (length < 0)
        {
            throw new ArgumentOutOfRangeException("The length is less than zero.");
        }

        if (startIndex + length > sb.Length)
        {
            throw new ArgumentOutOfRangeException("The sum of startIndex and length is greater than the length of the string.");
        }

        if (length == 0)
        {
            return new StringBuilder(string.Empty);
        }

        string subs = sb.ToString(startIndex, length);
        return new StringBuilder(subs);
    }
}