namespace KingSurvival
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using KingSurvival;

    public class Game
    {
        private static int size = 8;

        private static King king = new King(4, 7);

        private static Pawn pawnA = new Pawn(1, 0);
       
        private static Pawn pawnB = new Pawn(3, 0);
       
        private static Pawn pawnC = new Pawn(5, 0);
      
        private static Pawn pawnD = new Pawn(7, 0);
      
        private static bool isKingTurn = true;
      
        internal static void Main()
        {
            char[,] board = new char[,] 
            { 
                { '+', '-', '+', '-', '+', '-', '+', '-' },
                { '-', '+', '-', '+', '-', '+', '-', '+' },
                { '+', '-', '+', '-', '+', '-', '+', '-' },
                { '-', '+', '-', '+', '-', '+', '-', '+' },
                { '+', '-', '+', '-', '+', '-', '+', '-' },
                { '-', '+', '-', '+', '-', '+', '-', '+' },
                { '+', '-', '+', '-', '+', '-', '+', '-' },
                { '-', '+', '-', '+', '-', '+', '-', '+' }
            };

            board[pawnA.Y, pawnA.X] = 'A';
            board[pawnB.Y, pawnB.X] = 'B';
            board[pawnC.Y, pawnC.X] = 'C';
            board[pawnD.Y, pawnD.X] = 'D';
            board[king.Y, king.X] = 'K';

            PrintMatrix(board);
            bool pawnsWin = false;

            while (king.Y > 0 && king.Y < size && !pawnsWin)
            {
                isKingTurn = true;
                while (isKingTurn)
                {
                    isKingTurn = false;

                    PrintMatrix(board);
                    Console.Write("King`s Turn:");
                    string direction = Console.ReadLine();
                    if (direction == string.Empty)
                    {
                        isKingTurn = true;
                        continue;
                    }

                    direction = direction.ToUpper();

                    switch (direction)
                    {
                        case "KUL":
                            KingMove(-1, -1, board);
                            break;
                        case "KUR":
                            KingMove(1, -1, board);
                            break;
                        case "KDL":
                            KingMove(-1, 1, board);
                            break;
                        case "KDR":
                            KingMove(1, 1, board);
                            break;
                        default:
                            isKingTurn = true;
                            Console.WriteLine("Invalid input!");
                            Console.WriteLine("**Press a key to continue**");
                            Console.ReadKey();
                            break;
                    }
                }

                while (!isKingTurn)
                {
                    isKingTurn = true;
                    PrintMatrix(board);
                    Console.Write("Pawn`s Turn:");
                    string direction = Console.ReadLine();
                    if (direction == string.Empty)
                    {
                        isKingTurn = false;
                        continue;
                    }

                    direction = direction.ToUpper();

                    switch (direction)
                    {
                        case "ADR":
                            pawnsWin = PawnAMove(1, 1, board);
                            break;
                        case "ADL":
                            pawnsWin = PawnAMove(-1, 1, board);
                            break;
                        case "BDL":
                            pawnsWin = PawnBMove(-1, 1, board);
                            break;
                        case "BDR":
                            pawnsWin = PawnBMove(1, 1, board);
                            break;
                        case "CDL":
                            pawnsWin = PawnCMove(-1, 1, board);
                            break;
                        case "CDR":
                            pawnsWin = PawnCMove(1, 1, board);
                            break;
                        case "DDR":
                            pawnsWin = PawnDMove(1, 1, board);
                            break;
                        case "DDL":
                            pawnsWin = PawnDMove(-1, 1, board);
                            break;
                        default:
                            isKingTurn = false;
                            Console.WriteLine("Invalid input!");
                            Console.WriteLine("**Press a key to continue**");
                            Console.ReadKey();
                            break;
                    }

                    PrintMatrix(board);
                }
            }

            if (pawnsWin)
            {
                Console.WriteLine("Pawns win!");
            }
            else
            {
                Console.WriteLine("Kings win!");
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            Console.Clear();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write("{0,2}", matrix[i, j]);
                }

                Console.WriteLine(string.Empty);
            }
        }

        private static void KingMove(int dirX, int dirY, char[,] matrix)
        {
            if (king.X + dirX < 0 || king.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = true;
                return;
            }

            if (king.Y + dirY < 0 || king.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = true;
                return;
            }

            if (matrix[king.Y + dirY, king.X + dirX] == 'A')
            {
                matrix[king.Y + dirY, king.X + dirX] = 'K';
                matrix[pawnA.Y, pawnA.X] = '-';
            }

            if (matrix[king.Y + dirY, king.X + dirX] == 'B')
            {
                matrix[king.Y + dirY, king.X + dirX] = 'K';
                matrix[pawnB.Y, pawnB.X] = '-';
            }

            if (matrix[king.Y + dirY, king.X + dirX] == 'C')
            {
                matrix[king.Y + dirY, king.X + dirX] = 'K';
                matrix[pawnC.Y, pawnC.X] = '-';
            }

            if (matrix[king.Y + dirY, king.X + dirX] == 'D')
            {
                matrix[king.Y + dirY, king.X + dirX] = 'K';
                matrix[pawnD.Y, pawnD.X] = '-';
            }

            matrix[king.Y, king.X] = '-';
            matrix[king.Y + dirY, king.X + dirX] = 'K';
            king.Y += dirY;
            king.X += dirX;
            return;
        }

        private static bool PawnAMove(int dirX, int dirY, char[,] matrix)
        {
            if (pawnA.X + dirX < 0 || pawnA.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }

            if (pawnA.Y + dirY < 0 || pawnA.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }

            if (matrix[pawnA.Y + dirY, pawnA.X + dirX] == 'K')
            {
                Console.WriteLine("Pawn`s win!");
                return true;
            }

            if (matrix[pawnA.Y + dirY, pawnA.X + dirX] == 'D' || matrix[pawnA.Y + dirY, pawnA.X + dirX] == 'B'
                                                             || matrix[pawnA.Y + dirY, pawnA.X + dirX] == 'C')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }

            matrix[pawnA.Y, pawnA.X] = '-';
            matrix[pawnA.Y + dirY, pawnA.X + dirX] = 'A';
            pawnA.Y += dirY;
            pawnA.X += dirX;
            return false;
        }

        private static bool PawnBMove(int dirX, int dirY, char[,] matrix)
        {
            if (pawnB.X + dirX < 0 || pawnB.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }

            if (pawnB.Y + dirY < 0 || pawnB.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }

            if (matrix[pawnB.Y + dirY, pawnB.X + dirX] == 'K')
            {
                Console.WriteLine("Pawn`s win!");
                return true;
            }

            if (matrix[pawnB.Y + dirY, pawnB.X + dirX] == 'A' || matrix[pawnB.Y + dirY, pawnB.X + dirX] == 'C'
                || matrix[pawnB.Y + dirY, pawnB.X + dirX] == 'D')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }

            matrix[pawnB.Y, pawnB.X] = '-';
            matrix[pawnB.Y + dirY, pawnB.X + dirX] = 'B';
            pawnB.Y += dirY;
            pawnB.X += dirX;
            return false;
        }

        private static bool PawnCMove(int dirX, int dirY, char[,] matrix)
        {
            if (pawnC.X + dirX < 0 || pawnC.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }

            if (pawnC.Y + dirY < 0 || pawnC.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }

            if (matrix[pawnC.Y + dirY, pawnC.X + dirX] == 'K')
            {
                Console.WriteLine("Pawn`s win!");
                return true;
            }

            if (matrix[pawnC.Y + dirY, pawnC.X + dirX] == 'A' || matrix[pawnC.Y + dirY, pawnC.X + dirX] == 'B'
                || matrix[pawnC.Y + dirY, pawnC.X + dirX] == 'D')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }

            matrix[pawnC.Y, pawnC.X] = '-';
            matrix[pawnC.Y + dirY, pawnC.X + dirX] = 'C';
            pawnC.Y += dirY;
            pawnC.X += dirX;
            return false;
        }

        private static bool PawnDMove(int dirX, int dirY, char[,] matrix)
        {
            if (pawnD.Y + dirY < 0 || pawnD.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }

            if (pawnD.X + dirX < 0 || pawnD.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }

            if (matrix[pawnD.Y + dirY, pawnD.X + dirX] == 'K')
            {
                Console.WriteLine("Pawn`s win!");
                return true;
            }

            if (matrix[pawnD.Y + dirY, pawnD.X + dirX] == 'A' || matrix[pawnD.Y + dirY, pawnD.X + dirX] == 'B'
                                                             || matrix[pawnD.Y + dirY, pawnD.X + dirX] == 'C')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }

            matrix[pawnD.Y, pawnD.X] = '-';
            matrix[pawnD.Y + dirY, pawnD.X + dirX] = 'D';
            pawnD.Y += dirY;
            pawnD.X += dirX;
            return false;
        }
    }
}