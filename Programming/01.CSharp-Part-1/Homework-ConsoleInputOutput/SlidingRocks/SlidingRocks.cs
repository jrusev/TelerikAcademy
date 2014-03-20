using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    const int playfieldWidth = 80;
    const int playfieldHeight = 40;
    const string symbols = "@&%$#";
    const int maxLives = 5;

    const long refreshInterval = 1000 / 25;
    const long rocksSpeed = 1000 / 25;
    const long newRocksInterval = 1000 / 7;


    //static string[] colorNames;
    static Dwarf player;
    static Random rand;
    static bool collision;
    static List<Rock> rockList;
    static ConsoleColor[] colors;
    static Stopwatch sw;
    static long elapsed;

    public enum Direction { Left, Right, Up, Down };

    class Rock
    {
        public int Col { get; set; }
        public int Row { get; set; }
        public char Symbol { get; set; }
        public ConsoleColor Color { get; set; }
        public int Lives { get; set; }
        public Direction Dir { get; set; }

        //
        public long RocksSpeed { get; set; }
        public long LastMoved { get; set; }

        public Rock()
        {
            this.Color = RandomColor();
            this.Symbol = RandomChar();
            this.Row = rand.Next(0, playfieldHeight - 1);
            this.RocksSpeed = 1000 / rand.Next(20,30);
            this.LastMoved = sw.ElapsedMilliseconds;

            if (rand.Next(2) < 1)
            {
                this.Dir = Direction.Right;
                this.Col = 0;
            }
            else
            {
                this.Dir = Direction.Left;
                this.Col = Console.WindowWidth - 1;
            }
        }

        public Rock(int row, int col, char symbol, ConsoleColor color)
        {
            this.Col = col;
            this.Row = row;
            this.Symbol = symbol;
            this.Color = color;
        }

        public void Move()
        {
            if (this.Dir == Direction.Right && this.Col + 1 < Console.WindowWidth)
            {
                this.Col++;
            }
            if (this.Dir == Direction.Left && this.Col - 1 >= 0)
            {
                this.Col--;
            }
        }
    }

    class Dwarf : Rock
    {
        public string SymbolString { get; set; } // to draw the user "(0)"
    }

    static void Main()
    {
        // These must be initialized first
        //colorNames = ConsoleColor.GetNames(typeof(ConsoleColor));
        sw = Stopwatch.StartNew();
        colors = new ConsoleColor[] { ConsoleColor.Cyan, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Yellow };
        rand = new Random();

        SetConsoleDimensions();
        ConstructUser();

        rockList = new List<Rock>();


        elapsed = sw.ElapsedMilliseconds;
        long lastRefresh = elapsed;
        long lastRockCreated = elapsed;
        long lastRockMoved = elapsed;
        long last = elapsed;

        PrintIntro();

        while (true)
        {
            // Check key and move player
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if (player.Row - 1 >= 0) player.Row = player.Row - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        if (player.Row + 1 < playfieldWidth) player.Row = player.Row + 1;
                        break;
                }

                // Flush the buffer
                while (Console.KeyAvailable) Console.ReadKey(true);
            }

            elapsed = sw.ElapsedMilliseconds;

            if (elapsed - lastRockCreated > newRocksInterval)
            {
                lastRockCreated = elapsed;
                rockList.Add(new Rock());
            }

            //if (elapsed - lastRockMoved > rocksSpeed)
            //{
            //    lastRockMoved = elapsed;
            //    MoveRocks(elapsed);
            //}

            MoveRocks();

            if (elapsed - lastRefresh > refreshInterval)
            {
                lastRefresh = elapsed;
                RefreshConsole();

                if (player.Row == 0)
                {
                    GameSuccess();
                }
            }
        }
    }

    static void PrintIntro()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("   Your task is to get to the top row.");
        Console.WriteLine("   Use Up and Down arrow keys to move.");
        Console.WriteLine("          Your have {0} lives!", player.Lives);
        Console.WriteLine("      Press any key to continue...");
        Console.ResetColor();
        Console.ReadKey(true);
    }

    static void MoveRocks()
    {
        for (int i = 0; i < rockList.Count; i++)
        {

            if (elapsed - rockList[i].LastMoved > rockList[i].RocksSpeed)
            {
                rockList[i].LastMoved = elapsed;
                // move   

                if (rockList[i].Dir == Direction.Right &&
                    rockList[i].Col + 1 >= Console.WindowWidth)
                {
                    rockList.RemoveAt(i);
                }
                else if (rockList[i].Dir == Direction.Left &&
                    rockList[i].Col - 1 < 0)
                {
                    rockList.RemoveAt(i);
                }
                else
                {
                    rockList[i].Move();
                    CheckForCollision(rockList[i]);
                }
  
            }

            //if (rockList[i].Dir == Direction.Right &&
            //    rockList[i].Col + 1 >= Console.WindowWidth)
            //{
            //    rockList.RemoveAt(i);
            //}
            //else if (rockList[i].Dir == Direction.Left &&
            //    rockList[i].Col - 1 < 0)
            //{
            //    rockList.RemoveAt(i);
            //}
            //else
            //{
            //    rockList[i].Move();
            //    CheckForCollision(rockList[i]);
            //}
        }
    }

    static void PressAnyKeyToContinue()
    {
        Console.ResetColor();
        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
        while (pressedKey.Key == ConsoleKey.UpArrow || pressedKey.Key == ConsoleKey.DownArrow)
        {
            pressedKey = Console.ReadKey(true);
        }
    }

    static void RefreshConsole()
    {
        Console.Clear();

        // Print rocks
        foreach (Rock rock in rockList)
        {
            PrintOnPosition(rock.Col, rock.Row, rock.Symbol, rock.Color);
        }

        // Print user
        if (collision)
        {
            collision = false;

            PrintStringOnPosition(playfieldWidth / 2, playfieldHeight / 2, String.Format("Lives: {0}", player.Lives), ConsoleColor.Red);
            PrintStringOnPosition(player.Col, player.Row, "(x)", ConsoleColor.Red);

            // Set to initial position
            player.Col = playfieldWidth / 2;
            player.Row = Console.WindowHeight - 1;
            rockList.Clear();

            PressAnyKeyToContinue();
        }
        else
        {
            PrintStringOnPosition(player.Col, player.Row, player.SymbolString, player.Color);
            //PrintStringOnPosition(player.Col, player.Row, player.Row.ToString(), player.Color);
        }
    }

    static void EndGame()
    {
        PressAnyKeyToContinue();
        Environment.Exit(0);
    }

    static void CheckForCollision(Rock rock)
    {
        // if ((rock.Row == (user.Row - 1)) && rock.Col >= user.Col && (rock.Col <= user.Col + 2))
        if (rock.Row == player.Row && rock.Col >= player.Col && (rock.Col <= player.Col + 2))
        {
            player.Lives--;
            collision = true;
            if (player.Lives <= 0)
            {
                PrintStringOnPosition(playfieldWidth / 2, playfieldHeight / 2, "GAME OVER!!!", ConsoleColor.Red);
                EndGame();
            }
        }
    }

    static void GameSuccess()
    {
        PrintStringOnPosition(playfieldWidth / 2, playfieldHeight / 2, "SUCCESS!!!", ConsoleColor.Green);
        EndGame();
    }

    static void SetConsoleDimensions()
    {
        Console.BufferHeight = Console.WindowHeight = playfieldHeight;
        Console.BufferWidth = Console.WindowWidth = playfieldWidth + 2;
    }

    static void ConstructUser()
    {
        player = new Dwarf();
        player.Col = playfieldWidth / 2;
        player.Row = Console.WindowHeight - 1;
        player.SymbolString = "(0)";
        player.Color = ConsoleColor.White;
        player.Lives = maxLives;
    }

    static ConsoleColor RandomColor()
    {
        return colors[rand.Next(colors.Length)];
        //string colorName = colorNames[rand.Next(colorNames.Length)];
        //return (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorName);
    }

    static char RandomChar()
    {
        int randomIndex = rand.Next(symbols.Length);
        return symbols[randomIndex];
    }

    static void PrintOnPosition(int x, int y, char c, ConsoleColor color)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(c);
    }

    static void PrintStringOnPosition(int x, int y, string str, ConsoleColor color)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(str);
    }
}