using System;

class ExtractSentences
{
    static void Main()
    {
        /*
         * Write a program that extracts from a given text all sentences containing given word.
		    Example: The word is "in". The text is:
                We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.
            The expected result is:
                We are living in a yellow submarine.
                We will move out of it in 5 days.
            Consider that the sentences are separated by "." and the words – by non-letter symbols.
         */

        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string keyWord = "in";

        string[] sentences = text.Split('.');

        foreach (var sentence in sentences)
        {
            // Find the key word in the sentence
            int keyWordIndex = sentence.IndexOf(keyWord, StringComparison.OrdinalIgnoreCase);

            while (keyWordIndex != -1) // Keyword is found
            {
                // Is the first word in the sentence or the symbol before it is a non-letter symbol.
                bool check1 = keyWordIndex == 0 || !Char.IsLetter(sentence[keyWordIndex - 1]);

                // Is the last word in the sentence or the symbol after it is a non-letter symbol.
                bool check2 = keyWordIndex + keyWord.Length >= sentence.Length || !Char.IsLetter(sentence[keyWordIndex + keyWord.Length]);

                if (check1 && check2)
                {
                    Console.WriteLine(sentence.Trim() + '.');
                    break; // No need to continue the search in this sentence
                }
                else
                {
                    // Find the next occurence in the sentence
                    keyWordIndex = sentence.IndexOf(keyWord, keyWordIndex + 1);
                }
            }
        }
    }
}