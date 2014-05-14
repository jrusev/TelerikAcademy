namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class MineSweeper
    {
        private const int MaxEmptyCells = 35;

        public static void Main()
        {
            string command = string.Empty;
            var gameField = CreateEmptyField();
            var mines = PlaceMines();
            int cellsOpened = 0;
            bool boom = false;
            var topPlayers = new List<Player>(6);
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
                        PrintScoreBoard(topPlayers);
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
                                UpdateField(gameField, mines, row, col);
                                cellsOpened++;
                            }

                            if (cellsOpened == MaxEmptyCells)
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
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " + "Daj si niknejm: ", cellsOpened);
                    string nickname = Console.ReadLine();
                    var player = new Player(nickname, cellsOpened);
                    if (topPlayers.Count < 5)
                    {
                        topPlayers.Add(player);
                    }
                    else
                    {
                        for (int i = 0; i < topPlayers.Count; i++)
                        {
                            if (topPlayers[i].Points < player.Points)
                            {
                                topPlayers.Insert(i, player);
                                topPlayers.RemoveAt(topPlayers.Count - 1);
                                break;
                            }
                        }
                    }

                    topPlayers.Sort((Player r1, Player r2) => r2.Name.CompareTo(r1.Name));
                    topPlayers.Sort((Player r1, Player r2) => r2.Points.CompareTo(r1.Points));
                    PrintScoreBoard(topPlayers);

                    gameField = CreateEmptyField();
                    mines = PlaceMines();
                    cellsOpened = 0;
                    boom = false;
                    startGame = true;
                }

                if (gameFinished)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    DrawField(mines);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string name = Console.ReadLine();
                    var score = new Player(name, cellsOpened);
                    topPlayers.Add(score);
                    PrintScoreBoard(topPlayers);
                    gameField = CreateEmptyField();
                    mines = PlaceMines();
                    cellsOpened = 0;
                    gameFinished = false;
                    startGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void PrintScoreBoard(List<Player> players)
        {
            Console.WriteLine("\nPoints:");
            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, players[i].Name, players[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty ranking!\n");
            }
        }

        private static void UpdateField(char[,] cell, char[,] mines, int row, int col)
        {
            char adjacentMines = CountAdjacentMines(mines, row, col);
            mines[row, col] = adjacentMines;
            cell[row, col] = adjacentMines;
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

        private static char CountAdjacentMines(char[,] field, int row, int col)
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
    }
}
