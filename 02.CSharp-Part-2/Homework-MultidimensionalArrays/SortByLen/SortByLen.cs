using System;

class SortByLen
{
    static void Main()
    {
        // You are given an array of strings.
        // Write a method that sorts the array by the length of its elements (the number of characters composing them).

        string[] stringArr = RandomStringArray();
        Console.WriteLine("Array: " + String.Join(", ", stringArr));

        Array.Sort(stringArr, (str1, str2) => str1.Length.CompareTo(str2.Length));

        Console.WriteLine("\nSorted by length of the elements:");
        foreach (var item in stringArr)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }

    static string[] RandomStringArray()
    {
        Random rand = new Random();
        int len = rand.Next(3, 10); // [3;10)
        string[] stringArr = new string[len];

        // let's build the words observing the frequency of the letters in English
        // so for example the vowels will appear more often
        // http://www.oxforddictionaries.com/words/what-is-the-frequency-of-the-letters-of-the-alphabet-in-english
        double[] frequencies = { 0.002, 0.004, 0.007, 0.010, 0.020, 0.031, 0.044, 0.061, 0.079, 0.100, 0.125, 0.155, 0.185, 0.217, 0.251, 0.287, 0.332, 0.387, 0.444, 0.511, 0.581, 0.652, 0.728, 0.803, 0.888, 1.000, };
        char[] letters = { 'q', 'j', 'z', 'x', 'v', 'k', 'w', 'y', 'f', 'b', 'g', 'h', 'm', 'p', 'd', 'u', 'c', 'l', 's', 'n', 't', 'o', 'i', 'r', 'a', 'e', };

        for (int i = 0; i < len; i++)
        {
            int wordLen = rand.Next(1, 10); // determines the length of the current string
            string word = string.Empty;
            for (int j = 0; j < wordLen; j++)
            {
                double frequency = rand.Next(2, 1000) / 1000d; // [0.002;0.999]
                int index = Array.BinarySearch(frequencies, frequency);
                if (index < 0) index = ~index;
                char letter = letters[index];
                word += letter;
            }
            stringArr[i] = word;
        }
        return stringArr;
    }
}
