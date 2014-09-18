using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

// http://bgcoder.com/Contests/Practice/Index/90#0
class Program
{
    static Dictionary<string, char> dict = new Dictionary<string, char>();
    static HashSet<int> possibleLengths = new HashSet<int>();
    static List<string> messages = new List<string>();
    const string Test01 = @"123456789012
A19284123456121231234346912783C1267628376D21470912387489012H1872980347012934J752398475K719287340912L821649712639478M71264897126N3O789012P123456Q123456789012R1S2T9U12V123W1234X5Y6Z7
";
    static void Main()
    {
        //Console.SetIn(new StringReader(Test01));

        var message = Console.ReadLine();
        var cypher = Console.ReadLine();

        BuildDictionary(cypher);
        Decypgher(message, string.Empty);

        Console.WriteLine(messages.Count);
        messages.Sort();
        if (messages.Count > 0)
            Console.WriteLine(string.Join(Environment.NewLine, messages));
    }

    static void Decypgher(string suffix, string decyphered)
    {
        if (suffix.Length == 0)
        {
            messages.Add(decyphered);
            return;
        }

        foreach (var length in possibleLengths)
        {
            if (length > suffix.Length)
            {
                continue;
            }

            var prefix = suffix.Substring(0, length);
            if (dict.ContainsKey(prefix))
            {
                Decypgher(suffix.Substring(length), decyphered + dict[prefix]);
            }
        }
    }

    private static void BuildDictionary(string cypher)
    {
        for (int i = 0; i < cypher.Length; i++)
        {
            char letter = cypher[i++];

            var sb = new StringBuilder();
            for (; i < cypher.Length && cypher[i] < 'A'; i++)
                sb.Append(cypher[i]);
            i--;

            var code = sb.ToString();
            dict.Add(code, letter);
            possibleLengths.Add(code.Length);
        }
    }
}

