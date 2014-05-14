namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MineSweeper
    {
        public static void Main()
        {
            string command = string.Empty;
            char[,] gameField = DrawNewGameField();
            char[,] mines = PlaceMines();
            int count = 0;
            bool boom = false;
            var winners = new List<Score>(6);
            int row = 0;
            int col = 0;
            bool startGame = true;
            const int Max = 35;
            bool flag2 = false;

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
                        gameField = DrawNewGameField();
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
                                count++;
                            }

                            if (Max == count)
                            {
                                flag2 = true;
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
                    Console.Write(
                        "\nHrrrrrr! Umria gerojski s {0} to4ki. " + "Daj si niknejm: ", count);
                    string niknejm = Console.ReadLine();
                    var t = new Score(niknejm, count);
                    if (winners.Count < 5)
                    {
                        winners.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < winners.Count; i++)
                        {
                            if (winners[i].Points < t.Points)
                            {
                                winners.Insert(i, t);
                                winners.RemoveAt(winners.Count - 1);
                                break;
                            }
                        }
                    }

                    winners.Sort((Score r1, Score r2) => r2.Name.CompareTo(r1.Name));
                    winners.Sort((Score r1, Score r2) => r2.Points.CompareTo(r1.Points));
                    Ranking(winners);

                    gameField = DrawNewGameField();
                    mines = PlaceMines();
                    count = 0;
                    boom = false;
                    startGame = true;
                }

                if (flag2)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    DrawField(mines);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string name = Console.ReadLine();
                    var score = new Score(name, count);
                    winners.Add(score);
                    Ranking(winners);
                    gameField = DrawNewGameField();
                    mines = PlaceMines();
                    count = 0;
                    flag2 = false;
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
            int boardRows = board.GetLength(0);
            int boardCols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < boardRows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < boardCols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] DrawNewGameField()
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

            List<int> list = new List<int>();
            while (list.Count < 15)
            {
                Random random = new Random();
                int asfd = random.Next(50);
                if (!list.Contains(asfd))
                {
                    list.Add(asfd);
                }
            }

            foreach (int i2 in list)
            {
                int kol = i2 / cols;
                int red = i2 % cols;
                if (red == 0 && i2 != 0)
                {
                    kol--;
                    red = cols;
                }
                else
                {
                    red++;
                }

                gameField[kol, red - 1] = '*';
            }

            return gameField;
        }

        ////private static void smetki(char[,] field)
        ////{
        ////    int kol = field.GetLength(0);
        ////    int red = field.GetLength(1);

        ////    for (int i = 0; i < kol; i++)
        ////    {
        ////        for (int j = 0; j < red; j++)
        ////        {
        ////            if (field[i, j] != '*')
        ////            {
        ////                char kolkoo = NumberOfBombs(field, i, j);
        ////                field[i, j] = kolkoo;
        ////            }
        ////        }
        ////    }
        ////}

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
