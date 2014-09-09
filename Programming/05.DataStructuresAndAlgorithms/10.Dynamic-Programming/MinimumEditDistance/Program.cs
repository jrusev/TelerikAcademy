using System;

// Write a program to calculate the Minimum Edit Distance between two words.
// Sample costs for each operation : repalce = 1, delete = 0.9, insert = 0.8
// Example: x = "developer", y = "enveloped" -> cost = 2.7
class Program
{
    struct Cost { public double Replace, Delete, Insert; }

    static void Main()
    {
        var cost = new Cost() { Replace = 1.0, Delete = 0.9, Insert = 0.8 };
        string s = "developer", t = "enveloped";
        Console.WriteLine("{0} -> {1} = {2}", s, t, MinEditDistance(s, t, cost));
    }

    static double MinEditDistance(string s, string t, Cost cost)
    {
        var d = new double[s.Length + 1, t.Length + 1];
        for (int i = 0; i <= s.Length; i++)
            d[i, 0] = i * cost.Delete;
        for (int j = 0; j <= t.Length; j++)
            d[0, j] = j * cost.Insert;
        for (int j = 1; j <= t.Length; j++)
            for (int i = 1; i <= s.Length; i++)
                if (s[i - 1] == t[j - 1])
                    d[i, j] = d[i - 1, j - 1];  // no operation
                else
                    d[i, j] = Math.Min(Math.Min(
                        d[i - 1, j] + cost.Delete,
                        d[i, j - 1] + cost.Insert),
                        d[i - 1, j - 1] + cost.Replace);
        return d[s.Length, t.Length];
    }
}
