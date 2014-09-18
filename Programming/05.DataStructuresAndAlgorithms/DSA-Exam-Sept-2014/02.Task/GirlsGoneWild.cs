using System;
using System.Collections.Generic;
using System.IO;

class GirlsGoneWild
{
    static int K;
    static char[] letters;
    static int L;
    static int N;
    static Dress[] combination;
    static List<string> girls = new List<string>();

    const string Test001 = @"3
baca
2
";

    static void Main()
    {
        //Console.SetIn(new StringReader(Test001));

        K = int.Parse(Console.ReadLine());
        letters = Console.ReadLine().ToCharArray();
        L = letters.Length;
        N = int.Parse(Console.ReadLine());

        combination= new Dress[N];
        Array.Sort(letters);

        Comb(0, 0);
        girls.Sort();
        Console.WriteLine(girls.Count);
        if (girls.Count > 0)
        {
            Console.WriteLine(string.Join(Environment.NewLine, girls));
        }        
    }

    static void Comb(int index, int start)
    {
        if (index >= N)
        {
            Permutate(letters, 0, new char[N], new bool[letters.Length]);
            return;
        }
        else
        {
            for (int i = start; i < K; i++)
            {
                combination[index] = new Dress() { Shirt = i };              

                Comb(index + 1, i + 1);
            }
        }
    }

    private static void Permutate(char[] set, int p, char[] perm, bool[] used)
    {
        if (p == N)
        {
            for (int i = 0; i < N; i++)
            {
                combination[i].Letter = perm[i];
            }
            girls.Add(string.Join("-", combination));
            return;
        }

        perm[p] = '0';
        for (int i = 0; i < set.Length; i++)
        {
            if (!used[i] && set[i] > perm[p])
            {
                perm[p] = set[i];
                used[i] = true;
                Permutate(set, p + 1, perm, used);
                used[i] = false;
            }
        }
    }

    struct Dress
    {
        public char Letter;
        public int Shirt;
        public override string ToString()
        {
            return Shirt.ToString() + Letter.ToString();
        }
    }
}
