using System;

class DescribeStrings
{
    static void Main()
    {
        // Describe the strings in C#. What is typical for the string data type?
        // Describe the most important methods of the String class.

        /* Answer:
         * Strings are reference types, very similar to char[] arrays.
         * So their elements can be accessed with an indexer.
         * Strings however are immutable, i.e. their elements cannot be changed once created.
         * So when a string variable changes value, a new string object is created.
         * The most important methods are:
         *      instance: String.CompareTo, String.IndexOf, String.Substring, String.Split
         *      static: String.Compare String.Copy, String.Format, String.Join, String.Replace
         */
    }
}