namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class MineSweeper
    {
        private const int MaxPoints = 35;

        public static void Main()
        {
            string command = string.Empty;
            var gameField = CreateEmptyField();
            var mines = PlaceMines();
            int points = 0;
            bool boom = false;
            var winners = new List<Score>(6);
            int row = 0;
            int col = 0;
            bool startGame = true;            
            bool gameFinished = false;

            do
            {
                if (startGame)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                    " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    DrawField(gameField);
                    startGame = false;
                }

                Console.Write("Daj red i kolona : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                        row <= gameField.GetLength(0) && col <= gameField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Ranking(winners);
                        break;
                    case "restart":
                        gameField = CreateEmptyField();
                        mines = PlaceMines();
                        DrawField(gameField);
                        boom = false;
                        startGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (mines[row, col] != '*')
                        {
                            if (mines[row, col] == '-')
                            {
                                NextTurn(gameField, mines, row, col);
                                points++;
                            }

                            if (MaxPoints == points)
                            {
                                gameFinished = true;
                            }
                            else
                            {
                                DrawField(gameField);
                            }
                        }
                        else
                        {
                            boom = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (boom)
                {
                    DrawField(mines);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " + "Daj si niknejm: ", points);
                    string nickname = Console.ReadLine();
                    var score = new Score(nickname, points);
                    if (winners.Count < 5)
                    {
                        winners.Add(score);
                    }
                    else
                    {
                        for (int i = 0; i < winners.Count; i++)
                        {
                            if (winners[i].Points < score.Points)
                            {
                                winners.Insert(i, score);
                                winners.RemoveAt(winners.Count - 1);
                                break;
                            }
                        }
                    }

                    winners.Sort((Score r1, Score r2) => r2.Name.CompareTo(r1.Name));
                    winners.Sort((Score r1, Score r2) => r2.Points.CompareTo(r1.Points));
                    Ranking(winners);

                    gameField = CreateEmptyField();
                    mines = PlaceMines();
                    points = 0;
                    boom = false;
                    startGame = true;
                }

                if (gameFinished)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    DrawField(mines);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string name = Console.ReadLine();
                    var score = new Score(name, points);
                    winners.Add(score);
                    Ranking(winners);
                    gameField = CreateEmptyField();
                    mines = PlaceMines();
                    points = 0;
                    gameFinished = false;
                    startGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void Ranking(List<Score> points)
        {
            Console.WriteLine("\nPoints:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, points[i].Name, points[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty ranking!\n");
            }
        }

        private static void NextTurn(char[,] cell, char[,] bombs, int row, int col)
        {
            char numberOfBombs = NumberOfBombs(bombs, row, col);
            bombs[row, col] = numberOfBombs;
            cell[row, col] = numberOfBombs;
        }

        private static void DrawField(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateEmptyField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            var board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] gameField = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    gameField[i, j] = '-';
                }
            }

            var bombCells = new List<int>();
            while (bombCells.Count < 15)
            {
                var random = new Random();
                int cell = random.Next(50);
                if (!bombCells.Contains(cell))
                {
                    bombCells.Add(cell);
                }
            }

            foreach (var cell in bombCells)
            {
                int col = cell / cols;
                int row = cell % cols;
                if (row == 0 && cell != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                gameField[col, row - 1] = '*';
            }

            return gameField;
        }

        private static char NumberOfBombs(char[,] field, int row, int col)
        {
            int count = 0;
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            if (row - 1 >= 0)
            {
                if (field[row - 1, col] == '*')
                {
                    count++;
                }
            }

            if (row + 1 < rows)
            {
                if (field[row + 1, col] == '*')
                {
                    count++;
                }
            }

            if (col - 1 >= 0)
            {
                if (field[row, col - 1] == '*')
                {
                    count++;
                }
            }

            if (col + 1 < cols)
            {
                if (field[row, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (field[row - 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (field[row - 1, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (field[row + 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (field[row + 1, col + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }

        public class Score
        {
            private string name;
            private int points;

            public Score()
            {
            }

            public Score(string name, int points)
            {
                this.name = name;
                this.points = points;
            }

            public string Name
            {
                get { return this.name; }
                set { this.name = value; }
            }

            public int Points
            {
                get { return this.points; }
                set { this.points = value; }
            }
        }
    }
}
