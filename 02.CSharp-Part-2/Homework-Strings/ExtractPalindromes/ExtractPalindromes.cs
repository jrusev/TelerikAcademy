using System;

class ExtractPalindromes
{
    static void Main()
    {
        // Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

        string text = "Write a program that extracts from a given text level all palindromes, e.g. ABBA lamal exe noon";

        string[] wordList = text.Split(' ');

        foreach (var word in wordList)
        {
            if (IsPalindrom(word))
            {
                Console.WriteLine(word);
            }
        }
    }

    static bool IsPalindrom(string word)
    {
        if (word.Length < 3)
        {
            return false;
        }

        for (int i = 0; i < word.Length / 2; i++)
        {
            if (word[i] != word[word.Length - 1 - i])
            {
                return false;
            }
        }

        return true;
    }
}