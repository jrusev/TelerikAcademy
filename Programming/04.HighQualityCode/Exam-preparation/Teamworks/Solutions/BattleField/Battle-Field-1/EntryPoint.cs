namespace BattleField
{
    using System;

    public class EntryPoint
    {
        internal static void Main()
        {
            Console.Write("Welcome to \"Battle Field game.\" Enter battle field size: n = ");
            int n = Convert.ToInt32(Console.ReadLine());
            while (n < 1 || n > 10)
            {
                Console.WriteLine("Enter a number between 1 and 10!");
                n = Convert.ToInt32(Console.ReadLine());
            }

            int rows = n + 2;
            int cols = (n * 2) + 2;

            string[,] field = new string[rows, cols];

            PrepareGameField(field);

            Methods.AddMines(n, rows, cols, field);
            Methods.PrintMatrix(rows, cols, field);
            int countPlayed = 0;
            Methods.GameLoop(n, rows, cols, field, countPlayed);
        }

        private static void PrepareGameField(string[,] field)
        {
            field[0, 0] = " ";
            field[0, 1] = " ";
            field[1, 0] = " ";
            field[1, 1] = " ";

            for (int row = 2; row < field.GetLength(0); row++)
            {
                for (int col = 2; col < field.GetLength(1); col++)
                {
                    if (col % 2 == 0)
                    {
                        if (col == 2)
                        {
                            field[0, col] = "0";
                        }
                        else
                        {
                            field[0, col] = Convert.ToString((col - 2) / 2);
                        }
                    }
                    else
                    {
                        field[0, col] = " ";
                    }

                    if (col < field.GetLength(1) - 1)
                    {
                        field[1, col] = "-";
                    }

                    field[row, 0] = Convert.ToString(row - 2);
                    field[row, 1] = "|";

                    if (col % 2 == 0)
                    {
                        field[row, col] = "-";
                    }
                    else
                    {
                        field[row, col] = " ";
                    }
                }
            }
        }
    }
}