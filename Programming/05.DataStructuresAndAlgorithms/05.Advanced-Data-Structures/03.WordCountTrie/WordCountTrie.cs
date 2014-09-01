using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using rm.Trie;

// Write a program that finds a set of words (e.g. 1000 words) in a large text (e.g. 100 MB text file).
// Print how many times each word occurs in the text.
// Hint: you may find a C# trie in Internet.
public class WordCountTrie
{
    public static void Main()
    {
        // Builing trie from a 6.2MB file with one million words
        var trie = BuildTrieFromText("../../big-by-Peter-Norwig.txt");

        // Get a list of search words from a file with 1000 words
        var searchList = ReadSearchWordsFromFile("../../search-words.txt");

        // Find how many times each word occurs in the text by using the trie method WordCount()
        var sw = Stopwatch.StartNew();
        var searchWords = searchList.ToDictionary(w => w, w => trie.WordCount(w));
        sw.Stop();
        Console.WriteLine("1000 words found in {0} ms", sw.ElapsedMilliseconds);

        // Write each word and its frequency to file (check the file for results)...
        WriteWordFrequenciesToFile(searchWords, "../../output.txt");
    }

    private static ITrie BuildTrieFromText(string path)
    {
        var trie = TrieFactory.GetTrie();
        int totalWords = 0;

        Console.WriteLine("Builing trie from a 6.18MB file with one million words...");
        var sw = Stopwatch.StartNew();

        // The text files is a concatenation of several public domain books from Project Gutenberg
        // and lists of most frequent words from Wiktionary and the British National Corpus.
        using (var reader = new StreamReader(path))
        {
            foreach (var word in Words(reader))
            {
                trie.AddWord(word);
                totalWords++;
            }
        }

        sw.Stop();
        Console.WriteLine("Trie built in {0} ms", sw.ElapsedMilliseconds);
        Console.WriteLine("Total words in file: {0}", totalWords);
        Console.WriteLine("Unique words in file: {0}", trie.GetWords().Count);

        return trie;
    }

    private static List<string> ReadSearchWordsFromFile(string path)
    {
        var searchList = new List<string>();
        using (var reader = new StreamReader(path))
        {
            foreach (var word in Words(reader))
            {
                searchList.Add(word);
            }
        }

        return searchList;
    }

    private static void WriteWordFrequenciesToFile(Dictionary<string, int> searchWords, string path)
    {
        using (var writer = new StreamWriter(path))
        {
            foreach (var kvp in searchWords)
            {
                writer.WriteLine(kvp);
            }
        }
    }

    private static IEnumerable<string> Words(TextReader reader)
    {
        bool inWord = false;
        var sb = new StringBuilder();

        int read;

        while ((read = reader.Read()) != -1)
        {
            char ch = (char)read;
            if (char.IsLetter(ch) != inWord)
            {
                inWord = !inWord;
                if (!inWord)
                {
                    yield return sb.ToString();
                    sb.Length = 0;
                }
            }

            if (inWord)
            {
                sb.Append(ch);
            }
        }

        if (inWord)
        {
            yield return sb.ToString();
        }
    }
}