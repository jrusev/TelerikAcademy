using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        bool[][] input = Enumerable.Range(0, n)
            .Select(_ => Console.ReadLine())
            .Select(line =>
                line.Select(c => c == 'Y').ToArray()
            ).ToArray();

        int result = 0;

        for (int row = 0; row < input.Length; row++)
        {
            var friends = new HashSet<int>();

            for (int col = 0; col < input[row].Length; col++)
            {
                if (input[row][col])
                {
                    friends.Add(col);

                    for (int friendCol = 0; friendCol < input[col].Length; friendCol++)
                    {
                        if (friendCol == row)
                            continue;

                        if (input[col][friendCol])
                            friends.Add(friendCol);
                    }
                }
            }

            result = Math.Max(friends.Count, result);
        }

        Console.WriteLine(result);
    }
}