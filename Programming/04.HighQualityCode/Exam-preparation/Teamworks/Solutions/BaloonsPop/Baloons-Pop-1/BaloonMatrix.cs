namespace PoppingBaloons
{
    using System;

    public class BaloonMatrix
    {
        private int[,] board;

        public BaloonMatrix()
        {
            this.Turns = 0;
            this.board = new int[6, 10];
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    this.board[i, j] = rnd.Next(1, 5);
                }
            }

            this.PrintBoard();
        }

        public int Turns { get; set; }

        public bool PopBaloon(int x, int y)
        {
            // changes the game state and returns boolean, indicating wheater the game is over
            if (this.board[x - 1, y - 1] == 0)
            {
                Console.WriteLine("Invalid Move! Can not pop a baloon at that place!!");
                return false;
            }
            else
            {
                this.Turns++;
                int state = this.board[x - 1, y - 1];
                int top = x - 1;
                int bottom = x - 1;
                int left = y - 1;
                int right = y - 1;
                while (top > 0 && (this.board[top - 1, y - 1] == state))
                {
                    top--;
                }

                while (bottom < 5 && this.board[bottom + 1, y - 1] == state)
                {
                    bottom++;
                }

                while (left > 0 && this.board[x - 1, left - 1] == state)
                {
                    left--;
                }

                while (right < 9 && this.board[x - 1, right + 1] == state)
                {
                    right++;
                }

                for (int i = left; i <= right; i++)
                {
                    // first remove the elements on the same row and float the elemnts above down
                    if (x == 1)
                    {
                        this.board[x - 1, i] = 0;
                    }
                    else
                    {
                        for (int j = x - 1; j > 0; j--)
                        {
                            this.board[j, i] = this.board[j - 1, i];
                            this.board[j - 1, i] = 0;
                        }
                    }
                }

                if (top == bottom)
                {
                    Console.WriteLine();
                    this.PrintBoard();
                    Console.WriteLine();
                    return this.IsGameOver();
                }
                else
                {
                    // otherwise fix the problematic column as well
                    for (int i = top; i > 0; --i)
                    {
                        // first float the elements above down and replace them
                        this.board[i + bottom - top, y - 1] = this.board[i, y - 1];
                        this.board[i, y - 1] = 0;
                    }

                    if (bottom - top > top - 1)
                    {
                        // is there are more baloons to pop in the column than elements above them, need to pop them as well
                        for (int i = top; i <= bottom; i++)
                        {
                            if (this.board[i, y - 1] == state)
                            {
                                this.board[i, y - 1] = 0;
                            }
                        }
                    }
                }

                Console.WriteLine();
                this.PrintBoard();
                Console.WriteLine();
                return this.IsGameOver();
            }
        }

        public void PrintBoard()
        {
            Console.WriteLine("    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("    --------------------");
            for (int i = 0; i < 6; i++)
            {
                Console.Write(i.ToString() + " | ");
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(this.ColorCode(this.board[i, j]) + " ");
                }

                Console.WriteLine("| ");
            }

            Console.WriteLine("    --------------------");
            Console.WriteLine("Insert row and column or other command");
        }

        private char ColorCode(int a)
        {
            switch (a)
            {
                case 1:
                    return '1';
                case 2:
                    return '2';
                case 3:
                    return '3';
                case 4:
                    return '4';
                default:
                    return '-';
            }
        }
        
        private bool IsGameOver()
        {
            foreach (var cell in this.board)
            {
                if (cell != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}