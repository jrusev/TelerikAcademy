namespace GameFifteen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class GameFifteen
    {
        private const int MatrixSize = 4;

        private static Random rand = new Random();

        private static int[,] solvedMatrix = new int[MatrixSize, MatrixSize]
        {
            { 1, 2, 3, 4 },
            { 5, 6, 7, 8 }, 
            { 9, 10, 11, 12 },
            { 13, 14, 15, 16 }
        };

        private static int emptyRow = 3;

        private static int emptyCol = 3;

        private static int[,] currentMatrix = new int[MatrixSize, MatrixSize]
        { 
            { 1, 2, 3, 4 },
            { 5, 6, 7, 8 },
            { 9, 10, 11, 12 },
            { 13, 14, 15, 16 } 
        };

        private static int[] deltaRow = new int[4] { -1, 0, 1, 0 };

        private static int[] deltaCol = new int[4] { 0, 1, 0, -1 };

        private static OrderedMultiDictionary<int, string> scoreboard = new OrderedMultiDictionary<int, string>(true);

        internal static void Main()
        {
            StartNewGame();
            GameLoop();
        }

        private static void StartNewGame()
        {
            GenerateMatrix();
            PrintWelcome();
            PrintMatrix();
        }

        private static void GenerateMatrix()
        {
            int value = 1;
            for (int i = 0; i < MatrixSize; i++)
            {
                for (int j = 0; j < MatrixSize; j++)
                {
                    currentMatrix[i, j] = value;
                    value++;
                }
            }

            int ramizeMoves = rand.Next(10, 21);
            for (int i = 0; i < ramizeMoves; i++)
            {
                int randomDirection = rand.Next(4);
                int newRow = emptyRow + deltaRow[randomDirection];
                int newCol = emptyCol + deltaCol[randomDirection];
                if (IsOutOfMAtrix(newRow, newCol))
                {
                    i--;
                    continue;
                }
                else
                {
                    MoveEmptyCell(newRow, newCol);
                }
            }

            // If we got the initial matrix, start over
            if (MatrixIsSolved())
            {
                GenerateMatrix();
            }
        }

        private static bool IsOutOfMAtrix(int row, int col)
        {
            return row >= MatrixSize || row < 0 || col < 0 || col >= MatrixSize;
        }

        private static void MoveEmptyCell(int newRow, int newCol)
        {
            int swapValue = currentMatrix[newRow, newCol];
            currentMatrix[newRow, newCol] = 16;
            currentMatrix[emptyRow, emptyCol] = swapValue;
            emptyRow = newRow;
            emptyCol = newCol;
        }

        private static void PrintMatrix()
        {
            Console.WriteLine(" -------------");
            for (int i = 0; i < MatrixSize; i++)
            {
                Console.Write("|");
                for (int j = 0; j < MatrixSize; j++)
                {
                    if (currentMatrix[i, j] <= 9)
                    {
                        Console.Write("  {0}", currentMatrix[i, j]);
                    }
                    else
                    {
                        if (currentMatrix[i, j] == 16)
                        {
                            Console.Write("   ");
                        }
                        else
                        {
                            Console.Write(" {0}", currentMatrix[i, j]);
                        }
                    }

                    if (j == MatrixSize - 1)
                    {
                        Console.Write(" |\n");
                    }
                }
            }

            Console.WriteLine(" -------------");
        }

        private static void PrintWelcome()
        {
            Console.WriteLine("Welcome to the game “15”. Please try to arrange the numbers sequentially.\n" +
            "Use 'top' to view the top scoreboard, 'restart' to start a new game and \n'exit' to quit the game.");
        }

        private static bool MatrixIsSolved()
        {
            for (int i = 0; i < MatrixSize; i++)
            {
                for (int j = 0; j < MatrixSize; j++)
                {
                    if (currentMatrix[i, j] != solvedMatrix[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static bool IsGoodForScoreboard(int moves)
        {
            foreach (var score in scoreboard)
            {
                if (moves < score.Key)
                {
                    return true;
                }
            }

            return false;
        }

        private static void RemoveLastScore()
        {
            if (scoreboard.Last().Value.Count > 0)
            {
                string[] values = new string[scoreboard.Last().Value.Count];
                scoreboard.Last().Value.CopyTo(values, 0);
                scoreboard.Last().Value.Remove(values.Last());
            }
            else
            {
                int[] keys = new int[scoreboard.Count];
                scoreboard.Keys.CopyTo(keys, 0);
                scoreboard.Remove(keys.Last());
            }
        }

        private static void GameWon(int moves)
        {
            Console.WriteLine("Congratulations! You won the game in {0} moves.", moves);
            int scorersCount = 0;
            foreach (var scorer in scoreboard)
            {
                scorersCount += scorer.Value.Count;
            }

            if (scorersCount == 5)
            {
                if (IsGoodForScoreboard(moves))
                {
                    RemoveLastScore();
                    AddScore(moves);
                }
            }
            else
            {
                AddScore(moves);
            }
        }

        private static void AddScore(int moves)
        {
            Console.Write("Please enter your name for the top scoreboard: ");
            string name = Console.ReadLine();
            scoreboard.Add(moves, name);
        }

        private static void PrintScoreboard()
        {
            if (scoreboard.Count == 0)
            {
                Console.WriteLine("Scoreboard is empty");
                return;
            }

            Console.WriteLine("Scoreboard:");
            int i = 1;
            foreach (var score in scoreboard)
            {
                foreach (var value in score.Value)
                {
                    Console.WriteLine("{0}. {1} --> {2} moves", i, value, score.Key);
                    i++;
                }
            }

            Console.WriteLine();
        }

        private static void GameLoop()
        {
            int moves = 0;
            Console.Write("Enter a number to move: ");
            string inputString = Console.ReadLine();
            while (inputString.CompareTo("exit") != 0)
            {
                ExecuteComand(inputString, ref moves);
                if (MatrixIsSolved())
                {
                    GameWon(moves);
                    PrintScoreboard();
                    StartNewGame();
                    moves = 0;
                }

                Console.Write("Enter a number to move: ");
                inputString = Console.ReadLine();
            }

            Console.WriteLine("Good bye!");
        }

        private static void ExecuteComand(string inputString, ref int moves)
        {
            switch (inputString)
            {
                case "restart":
                    moves = 0;
                    StartNewGame();
                    break;
                case "top":
                    PrintScoreboard();
                    PrintMatrix();
                    break;
                default:
                    MoveCell(inputString, ref moves);
                    break;
            }
        }

        private static void MoveCell(string inputString, ref int moves)
        {
            int number = 0;
            bool isNumber = int.TryParse(inputString, out number);
            if (!isNumber)
            {
                Console.WriteLine("Invalid comand!");
                return;
            }

            if (number <= 0 || number >= 16)
            {
                Console.WriteLine("Invalid move");
                return;
            }

            int newRow = 0;
            int newCol = 0;
            for (int i = 0; i < 4; i++)
            {
                newRow = emptyRow + deltaRow[i];
                newCol = emptyCol + deltaCol[i];
                if (IsOutOfMAtrix(newRow, newCol))
                {
                    if (i == 3)
                    {
                        Console.WriteLine("Invalid move");
                    }

                    continue;
                }

                if (currentMatrix[newRow, newCol] == number)
                {
                    MoveEmptyCell(newRow, newCol);
                    moves++;
                    PrintMatrix();
                    return;
                }

                if (i == 3)
                {
                    Console.WriteLine("Invalid move");
                }
            }
        }
    }
}
