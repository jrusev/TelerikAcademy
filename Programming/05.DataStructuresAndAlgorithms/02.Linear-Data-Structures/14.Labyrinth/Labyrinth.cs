using System;
using System.Collections.Generic;
using System.Threading;

// We are given a labyrinth of size N x N. Some of its cells are empty (0) and some are full (x).
// We can move from an empty cell to another empty cell if they share common wall.
// Given a starting position (*) calculate and fill in the array the minimal distance
// from this position to any other cell in the array. Use "u" for all unreachable cells.
// Example:
//  0	0	0	x 	0	x    	3	4	5	x 	u 	x 
//  0	x 	0	x 	0	x    	2	x 	6	x 	u 	x 
//  0	* 	x 	0	x 	0   =>	1	* 	x 	8	x 	10
//  0	x 	0	0	0	0   	2	x 	6	7	8	9
//  0	0	0	x 	x 	0   	3	4	5	x 	x 	10
//  0	0	0	x 	0	x    	4	5	6	x 	u 	x 
public class Program
{
    private static string emp = ".";
    private static string unr = "u";
    private static int[] dirRow = new int[4] { -1,  1,  0,  0 };
    private static int[] dirCol = new int[4] {  0,  0,  1, -1 };
    private static string[,] labyrinth;

    private static void Main()
    {
        labyrinth = new string[6, 6] 
        {
            { emp, emp, emp, "x", emp, "x" },
            { emp, "x", emp, "x", emp, "x" },
            { emp, "*", "x", emp, "x", emp },
            { emp, "x", emp, emp, emp, emp },
            { emp, emp, emp, "x", "x", emp },
            { emp, emp, emp, "x", emp, "x" },
        };

        int startRow = 2;
        int startCol = 1;

        PrintMatrix(startRow, startCol, false);
        FillLabyrinth(startRow, startCol);
        PrintMatrix(startRow, startCol, true);

        Console.WriteLine("Matrix is filled.");
        Console.ReadKey(true);
    }

    private static void FillLabyrinth(int startRow, int startCol)
    {
        var queue = new Queue<Tuple<int, int>>();
        queue.Enqueue(new Tuple<int, int>(startRow, startCol));

        while (queue.Count > 0)
        {
            var currentCell = queue.Dequeue();
            
            var row = currentCell.Item1;
            var col = currentCell.Item2;
            var wave = (row == startRow) && (col == startCol) ? 0 : int.Parse(labyrinth[row, col]);

            wave++;

            for (int i = 0; i < dirRow.Length; i++)
            {
                int nextRow = row + dirRow[i];
                int nextCol = col + dirCol[i];

                if (IsInMatrix(nextRow, nextCol) && labyrinth[nextRow, nextCol] == emp)
                {
                    queue.Enqueue(new Tuple<int, int>(nextRow, nextCol));
                    labyrinth[nextRow, nextCol] = wave.ToString();
                    PrintMatrix(nextRow, nextCol, false);
                }
            }
        }
    }

    private static bool IsInMatrix(int row, int col)
    {
        return row >= 0 && row < labyrinth.GetLongLength(0) && col >= 0 && col < labyrinth.GetLongLength(1);
    }

    private static void PrintMatrix(int redRow, int redCol, bool finished)
    {
        Console.Clear();
        for (int row = 0; row < labyrinth.GetLongLength(0); row++)
        {
            for (int col = 0; col < labyrinth.GetLongLength(1); col++)
            {
                if (row == redRow && col == redCol && !finished)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ResetColor();
                }

                if (finished && labyrinth[row, col] == emp)
                {
                    labyrinth[row, col] = unr;
                }

                Console.Write(labyrinth[row, col] + "  ");
            }

            Console.WriteLine();    
        }

        ////Console.WriteLine("Press any key to see the waves...");
        ////Console.ReadKey(true); 

        Thread.Sleep(500);
    }
}
