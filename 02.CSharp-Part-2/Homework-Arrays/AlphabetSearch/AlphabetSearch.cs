using System;

class AlphabetSearch
{
    static void Main()
    {
        // Write a program that creates an array containing all letters from the alphabet (A-Z).
        // Read a word from the console and print the index of each of its letters in the array.

        char[] alphabet = new char[52];
        for (int i = 0; i < alphabet.Length; i++)
        {
            if (i < 26)
                alphabet[i] = (char)('A' + i);
            else
                alphabet[i] = (char)('a' + i - 26);
        }

        Console.Write("Please enter a word: ");
        string word = Console.ReadLine();

        // print the word letter by letter
        Console.Write("Letter: ");
        foreach (var item in word)
        {
            Console.Write("{0,3}", item);
        }
        Console.WriteLine();

        // we will print the number of the letter in the alphabet, not the index in the array
        // ... the position of 'a' and 'A' is 1
        // ... the position of 'z' and 'Z' is 26
        Console.Write("Number: ");
        for (int i = 0; i < word.Length; i++)
        {
            int index = MyBinarySearch(alphabet, word[i]);
            if (index < 0)
            {
                Console.Write(" na"); // not a letter from the alphabet
            }
            else
            {
                Console.Write("{0,3}", (index % 26) + 1); // Console.Write("{0,3}", index); // to print just the index [0,51]              
            }
        }
        Console.WriteLine();
    }

    static int MyBinarySearch(char[] letters, char key)
    {
        // takes an array of chars and a value to search
        // returns the index of the element in the array
        // or -1 if the element is not found
        // the array must be sorted before calling this method
        int low = 0;
        int high = letters.Length - 1;
        while (high >= low)
        {
            int mid = low + (high - low) / 2;
            if (key == letters[mid])
                return mid;
            else if (key < letters[mid])
                high = mid - 1;
            else
                low = mid + 1;
        }
        return -1;
    }
}
