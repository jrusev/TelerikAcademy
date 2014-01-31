using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

class ExtractDates
{
    enum WordParseState { OutOfWord, InWord };
    enum DateParseState { OutOfDate, ProcessingDay, ProcessingMonth, ProcessingYear };

    static void Main()
    {
        // Write a program that extracts from a given text all dates that match the format DD.MM.YYYY.
        // Display them in the standard date format for Canada.
        // Example:
        //      I was born at 14.06.1980. My sister was born at 3.7.1984. In 5/1999 I graduated my high school. The law says (see section 7.3.12) that we are allowed to do this (section 7.4.2.9).
        // Result:
        //      14.06.1980
        //      3.7.1984

        string text = "I was born at 14.06.1980. My sister was born at 3.7.1984. In 5/1999 I graduated my high school. The law says (see section 7.3.12) that we are allowed to do this (section 7.4.2.9).";

        // Split the text in words
        string[] wordList = SplitText(text);

        DateTime date;
        foreach (var word in wordList)
        {
            char lastSymbol = word[word.Length - 1];

            // If the last symbol is a punctuation - remove it
            if (IsPunctiation(lastSymbol))
            {
                if (DateTime.TryParseExact(word.Remove(word.Length - 1), "d.M.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    Console.WriteLine(date.ToString(CultureInfo.GetCultureInfo("en-CA").DateTimeFormat.ShortDatePattern));
            }
            else
            {
                if (DateTime.TryParseExact(word, "d.M.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    Console.WriteLine(date.ToString(CultureInfo.GetCultureInfo("en-CA").DateTimeFormat.ShortDatePattern));
            }
        }
    }

    // Checks if a given character is a punctuation mark
    static bool IsPunctiation(char ch)
    {
        char[] punctuation = { '.', ',', '!', '?', ';', ')', '(' };

        foreach (var mark in punctuation)
            if (ch == mark) return true;

        return false;
    }

    // Splits the text in words (similar to String.Split)
    static string[] SplitText(string text)
    {
        List<string> wordList = new List<string>();
        StringBuilder word = new StringBuilder();

        WordParseState state = WordParseState.OutOfWord;

        foreach (var ch in text)
        {
            switch (state)
            {
                case WordParseState.OutOfWord:
                    if (ch != ' ')
                    {
                        state = WordParseState.InWord;
                        word.Append(ch);
                    }
                    break;
                case WordParseState.InWord:
                    if (ch != ' ')
                    {
                        word.Append(ch);
                    }
                    else
                    {
                        wordList.Add(word.ToString());
                        word.Clear();
                        state = WordParseState.OutOfWord;
                    }
                    break;
            }
        }

        if (state == WordParseState.InWord)
        {
            wordList.Add(word.ToString());
        }

        return wordList.ToArray();
    }
}