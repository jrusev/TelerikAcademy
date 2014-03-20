using System;
using System.Collections.Generic;
using System.Linq;

class CountLettersInText
{
    static void Main()
    {
        // Write a program that reads a string and prints all different letters in the string along with information how many times each letter is found. 

        string str = "Write a program that reads a string and prints all different letters in the string along with information how many times each letter is found.";
        Console.WriteLine(str);

        Dictionary<char, int> dictionary = new Dictionary<char, int>();

        // Fill the dictionary
        foreach (var symbol in str)
        {
            if (Char.IsLetter(symbol)) // Select only letters
            {
                // Upper case and lower case will count as the same letter
                char letter = Char.ToUpper(symbol); 
                if (dictionary.ContainsKey(letter))
                {
                    dictionary[letter]++;
                }
                else
                {
                    dictionary.Add(letter, 1);
                }  
            }
        }

        // Order the dictionary by key using LINQ
        var ordered = dictionary.OrderBy(x => x.Key);

        // Loop through the <key,value> pairs
        foreach (var pair in ordered)
        {
            Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
        }
    }
}