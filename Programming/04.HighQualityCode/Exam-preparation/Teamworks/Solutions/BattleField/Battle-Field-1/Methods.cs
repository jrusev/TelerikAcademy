namespace BattleField
{
    using System;

    public class Methods
    {
        public static void AddMines(int n, int rows, int cols, string[,] minefield)
        {
            int count = 0;
            var rand = new Random();
            int randRow;
            int randCol;
            int minPercent = Convert.ToInt32(0.15 * (n * n));
            int maxPercent = Convert.ToInt32(0.30 * (n * n));
            int countMines = rand.Next(minPercent, maxPercent);

            while (count <= countMines)
            {
                randRow = rand.Next(0, n);
                randCol = rand.Next(0, n);
                randRow += 2;
                randCol = (2 * randCol) + 2;

                while (minefield[randRow, randCol] != " " && minefield[randRow, randCol] != "-")
                {
                    randRow = rand.Next(0, n);
                    randCol = rand.Next(0, n);
                    randRow += 2;
                    randCol = (2 * randCol) + 2;
                }

                string randomDigit = Convert.ToString(rand.Next(1, 6));
                minefield[randRow, randCol] = randomDigit;
                minefield[randRow, randCol + 1] = " ";
                count++;
            }
        }

        public static void PrintMatrix(int rows, int cols, string[,] matrix)
        {
            Console.Clear();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        public static void GameLoop(int n, int rows, int cols, string[,] matrix, int countPlayed)
        {
            countPlayed++;

            var rowCol = ReadInput(n);
            int row = rowCol.Item1;
            int col = rowCol.Item2;

            row += 2;
            col = (2 * col) + 2;

            while (matrix[row, col] == "-" || matrix[row, col] == "X")
            {
                while (!IsInsideMatrix(row, col, n))
                {
                    Console.WriteLine("Invalid move !");
                    rowCol = ReadInput(n);
                    row = rowCol.Item1;
                    col = rowCol.Item2;
                }

                row += 2;
                col = (2 * col) + 2;
            }

            int minePower = Convert.ToInt32(matrix[row, col]);
            switch (minePower)
            {
                case 1:
                    HitOne(row, col, rows, cols, matrix);
                    break;
                case 2:
                    HitTwo(row, col, rows, cols, matrix);
                    break;
                case 3:
                    HitThree(row, col, rows, cols, matrix);
                    break;
                case 4:
                    HitFour(row, col, rows, cols, matrix);
                    break;
                case 5:
                    HitFive(row, col, rows, cols, matrix);
                    break;
            }

            PrintMatrix(rows, cols, matrix);
            if (!GameHasEnded(rows, cols, matrix))
            {
                GameLoop(n, rows, cols, matrix, countPlayed);
            }
            else
            {
                Console.WriteLine("Game over. Detonated mines: " + countPlayed);
            }
        }

        public static void HitOne(int x, int y, int rows, int cols, string[,] workField)
        {
            workField[x, y] = "X";
            if (x - 1 > 1 && y - 2 > 1)
            {
                workField[x - 1, y - 2] = "X";
            }

            if (x - 1 > 1 && y < cols - 2)
            {
                workField[x - 1, y + 2] = "X";
            }

            if (x < rows - 1 && y < cols - 2)
            {
                workField[x + 1, y + 2] = "X";
            }

            if (x < rows - 1 && y - 2 > 1)
            {
                workField[x + 1, y - 2] = "X";
            }
        }

        public static void HitTwo(int x, int y, int rows, int cols, string[,] workField)
        {
            workField[x, y] = "X";
            HitOne(x, y, rows, cols, workField);
            if (y - 2 > 1)
            {
                workField[x, y - 2] = "X";
            }

            if (y < cols - 2)
            {
                workField[x, y + 2] = "X";
            }

            if (x - 1 > 1)
            {
                workField[x - 1, y] = "X";
            }

            if (x < rows - 1)
            {
                workField[x + 1, y] = "X";
            }
        }

        public static void HitThree(int x, int y, int rows, int cols, string[,] workField)
        {
            HitTwo(x, y, rows, cols, workField);
            if (x - 2 > 1)
            {
                workField[x - 2, y] = "X";
            }

            if (x < rows - 2)
            {
                workField[x + 2, y] = "X";
            }

            if (y - 4 > 1)
            {
                workField[x, y - 4] = "X";
            }

            if (y == 18)
            {
                workField[x, y + 2] = "X";
            }
            else if (y == 20)
            {
                workField[x, y] = "X";
            }
            else
            {
                if (y < cols - 3)
                {
                    workField[x, y + 4] = "X";
                }
            }
        }

        public static void HitFour(int x, int y, int rows, int cols, string[,] workField)
        {
            HitThree(x, y, rows, cols, workField);
            if (x - 2 > 1 && y - 2 > 1)
            {
                workField[x - 2, y - 2] = "X";
            }

            if (x - 1 > 1 && y - 4 > 1)
            {
                workField[x - 1, y - 4] = "X";
            }

            if (x - 2 > 1 && y < cols - 2)
            {
                workField[x - 2, y + 2] = "X";
            }

            if (x < rows - 1 && y - 4 > 1)
            {
                workField[x + 1, y - 4] = "X";
            }

            if (x < rows - 2 && y - 2 > 1)
            {
                workField[x + 2, y - 2] = "X";
            }

            if (x < rows - 2 && y < cols - 2)
            {
                workField[x + 2, y + 2] = "X";
            }

            if (y == 18)
            {
                if (x - 1 > 1)
                {
                    workField[x - 1, y + 2] = "X";
                }

                if (x < rows - 1)
                {
                    workField[x + 1, y + 2] = "X";
                }
            }
            else if (y == 20)
            {
                if (x - 1 > 1)
                {
                    workField[x - 1, y] = "X";
                }

                if (x < rows - 1)
                {
                    workField[x + 1, y] = "X";
                }
            }
            else
            {
                if (x - 1 > 1 && y < cols - 3)
                {
                    workField[x - 1, y + 4] = "X";
                }

                if (x < rows - 1 && y < cols - 3)
                {
                    workField[x + 1, y + 4] = "X";
                }
            }
        }

        public static void HitFive(int x, int y, int rows, int cols, string[,] poleZaRabota)
        {
            HitFour(x, y, rows, cols, poleZaRabota);
            if (x - 2 > 1 && y - 4 > 1)
            {
                poleZaRabota[x - 2, y - 4] = "X";
            }

            if (x < rows - 2 && y - 4 > 1)
            {
                poleZaRabota[x + 2, y - 4] = "X";
            }

            if (y == 18)
            {
                if (x < rows - 2)
                {
                    poleZaRabota[x + 2, y + 2] = "X";
                }

                if (x - 2 > 1)
                {
                    poleZaRabota[x - 2, y + 2] = "X";
                }
            }
            else if (y == 20)
            {
                if (x < rows - 2)
                {
                    poleZaRabota[x + 2, y] = "X";
                }

                if (x - 2 > 1)
                {
                    poleZaRabota[x - 2, y] = "X";
                }
            }
            else
            {
                if (x < rows - 2 && y < cols - 3)
                {
                    poleZaRabota[x + 2, y + 4] = "X";
                }

                if (x - 2 > 1 && y < cols - 3)
                {
                    poleZaRabota[x - 2, y + 4] = "X";
                }
            }
        }

        public static bool GameHasEnded(int rows, int cols, string[,] matrix)
        {
            bool hasEnded = true;
            for (int i = 2; i < rows; i++)
            {
                for (int j = 2; j < cols; j++)
                {
                    if (matrix[i, j] == "1" || matrix[i, j] == "2" || matrix[i, j] == "3" || matrix[i, j] == "4" || matrix[i, j] == "5")
                    {
                        hasEnded = false;
                        break;
                    }
                }
            }

            return hasEnded;
        }

        private static bool IsInsideMatrix(int row, int col, int n)
        {
            return !(row < 0 || row > (n - 1) || col < 0 || col > (n - 1));
        }

        private static Tuple<int, int> ReadInput(int n)
        {
            Console.WriteLine("Please enter coordinates: ");
            string input = Console.ReadLine();
            int row = int.Parse(input.Substring(0, 1));
            int col = int.Parse(input.Substring(2, 1));

            while ((row < 0 || row > (n - 1)) && (col < 0 || col > (n - 1)))
            {
                Console.WriteLine("Invalid move !");
                Console.WriteLine("Please enter coordinates: ");
                input = Console.ReadLine();
                row = int.Parse(input.Substring(0, 1));
                col = int.Parse(input.Substring(2, 1));
            }

            return Tuple.Create<int, int>(row, col);
        }
    }
}
