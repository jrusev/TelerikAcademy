using System;
using System.IO;

public class Program
{
    const string Test001 = @"8
108214 Pleven
339077 Plovdiv
200612 Burgas
334688 Varna
1241396 Sofia
92162 Sliven
151951 Ruse
137907 StaraZagora
";

    const string Test002 = @"4
19906 NikiTown
19832 EvlogiTown
19894 IvoTown
19896 DonchoTown
";

    const string Test003 = @"3
2 HaxorTown
2 LeetTown
2 RoxxorTown
";

    public static void Main()
    {
        //Console.SetIn(new StringReader(Test001));

        int n = int.Parse(Console.ReadLine());
        var towns = new int[n];
        for (int i = 0; i < n; i++)
        {
            var parameters = Console.ReadLine().Split(' ');
            towns[i] = int.Parse(parameters[0]);
        }

        Console.WriteLine(FindLongestPath(towns));
    }

    private static int FindLongestPath(int[] towns)
    {
        int size = towns.Length;
        var lis = new int[size];
        var lds = new int[size];

        for (int i = 0; i < size; ++i)        
            for (int j = 0; j < i; ++j)           
                if (towns[j] < towns[i])               
                    lis[i] = Math.Max(lis[j] + 1, lis[i]);

        for (int i = size - 1; i >= 0; --i)       
            for (int j = size - 1; j > i; --j)           
                if (towns[j] < towns[i])               
                    lds[i] = Math.Max(lds[j] + 1, lds[i]);


        int longestPath = 0;
        for (int i = 0; i < size; ++i)       
            longestPath = Math.Max(longestPath, lds[i] + lis[i] + 1);       

        return longestPath;
    }
}
