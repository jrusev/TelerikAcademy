using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

/*
* Implement the "Falling Rocks" game in the text console.
* A small dwarf stays at the bottom of the screen and can move left and right (by the arrows keys).
* A number of rocks of different sizes and forms constantly fall down and you need to avoid a crash.
* Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with appropriate density.
* The dwarf is (O). Ensure a constant game speed by Thread.Sleep(150).
* Implement collision detection and scoring system.
*/

struct Rocks
{
    public int col;
    public int row;
    public char symbol;
    public string symbolString; // to draw the user "(0)"
    public ConsoleColor color;
}

class Program
{
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
    static void Main()
    {

        int playfieldWidth = 80;
        int playfieldHeight = 40;
        Console.BufferHeight = Console.WindowHeight = playfieldHeight;
        Console.BufferWidth = Console.WindowWidth = playfieldWidth + 2;

        int lives = 3;

        Rocks user = new Rocks();
        user.col = playfieldWidth / 2;
        user.row = Console.WindowHeight - 1;
        user.symbolString = "(0)";
        user.color = ConsoleColor.White;
        Random randomGenerator = new Random();
        List<Rocks> objects = new List<Rocks>();
        while (true)
        {
            bool collision = false;
            {
                int chance = randomGenerator.Next(0, 120);
                // ^, @, *, &, +, %, $, #, !, ., ;,
                if (chance < 10)
                {
                    Rocks newObject = new Rocks();
                    newObject.color = ConsoleColor.Blue;
                    newObject.symbol = '^';
                    newObject.col = randomGenerator.Next(0, playfieldWidth);
                    newObject.row = 0;
                    objects.Add(newObject);
                }
                else if (chance < 20)
                {
                    Rocks newObject = new Rocks();
                    newObject.color = ConsoleColor.Cyan;
                    newObject.symbol = '@';
                    newObject.col = randomGenerator.Next(0, playfieldWidth);
                    newObject.row = 0;
                    objects.Add(newObject);
                }
                else if (chance < 30)
                {
                    Rocks newObject = new Rocks();
                    newObject.color = ConsoleColor.DarkCyan;
                    newObject.symbol = '*';
                    newObject.col = randomGenerator.Next(0, playfieldWidth);
                    newObject.row = 0;
                    objects.Add(newObject);
                }
                else if (chance < 40)
                {
                    Rocks newObject = new Rocks();
                    newObject.color = ConsoleColor.Green;
                    newObject.symbol = '&';
                    newObject.col = randomGenerator.Next(0, playfieldWidth);
                    newObject.row = 0;
                    objects.Add(newObject);
                }
                else if (chance < 50)
                {
                    Rocks newObject = new Rocks();
                    newObject.color = ConsoleColor.Magenta;
                    newObject.symbol = '&';
                    newObject.col = randomGenerator.Next(0, playfieldWidth);
                    newObject.row = 0;
                    objects.Add(newObject);
                }
                else if (chance < 60)
                {
                    Rocks newObject = new Rocks();
                    newObject.color = ConsoleColor.Yellow;
                    newObject.symbol = '+';
                    newObject.col = randomGenerator.Next(0, playfieldWidth);
                    newObject.row = 0;
                    objects.Add(newObject);
                }
                else if (chance < 70)
                {
                    Rocks newObject = new Rocks();
                    newObject.color = ConsoleColor.Red;
                    newObject.symbol = '%';
                    newObject.col = randomGenerator.Next(0, playfieldWidth);
                    newObject.row = 0;
                    objects.Add(newObject);
                }
                else if (chance < 80)
                {
                    Rocks newObject = new Rocks();
                    newObject.color = ConsoleColor.DarkMagenta;
                    newObject.symbol = '$';
                    newObject.col = randomGenerator.Next(0, playfieldWidth);
                    newObject.row = 0;
                    objects.Add(newObject);
                }
                else if (chance < 90)
                {
                    Rocks newObject = new Rocks();
                    newObject.color = ConsoleColor.DarkGreen;
                    newObject.symbol = '#';
                    newObject.col = randomGenerator.Next(0, playfieldWidth);
                    newObject.row = 0;
                    objects.Add(newObject);
                }
                else if (chance < 100)
                {
                    Rocks newObject = new Rocks();
                    newObject.color = ConsoleColor.DarkYellow;
                    newObject.symbol = '!';
                    newObject.col = randomGenerator.Next(0, playfieldWidth);
                    newObject.row = 0;
                    objects.Add(newObject);
                }
                else if (chance < 110)
                {
                    Rocks newObject = new Rocks();
                    newObject.color = ConsoleColor.DarkBlue;
                    newObject.symbol = '.';
                    newObject.col = randomGenerator.Next(0, playfieldWidth);
                    newObject.row = 0;
                    objects.Add(newObject);
                }
                else
                {
                    Rocks newObject = new Rocks();
                    newObject.color = ConsoleColor.DarkRed;
                    newObject.symbol = ';';
                    newObject.col = randomGenerator.Next(0, playfieldWidth);
                    newObject.row = 0;
                    objects.Add(newObject);
                }

            }

            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (user.col - 1 >= 0)
                    {
                        user.col = user.col - 1;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (user.col + 1 < playfieldWidth)
                    {
                        user.col = user.col + 1;
                    }
                }
            }
            List<Rocks> newList = new List<Rocks>();
            for (int i = 0; i < objects.Count; i++)
            {
                Rocks oldRocks = objects[i];
                Rocks newObject = new Rocks();
                newObject.col = oldRocks.col;
                newObject.row = oldRocks.row + 1;
                newObject.symbol = oldRocks.symbol;
                newObject.color = oldRocks.color;

                if ((newObject.row == (user.row - 1)) && newObject.col >= user.col && (newObject.col <= user.col + 2))
                {
                    lives--;
                    collision = true;
                    if (lives <= 0)
                    {
                        PrintStringOnPosition(playfieldWidth / 2, playfieldHeight / 2, "GAME OVER!!!", ConsoleColor.Red);
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                }
                if (newObject.row < Console.WindowHeight)
                {
                    newList.Add(newObject);
                }
            }
            objects = newList;
            Console.Clear();
            if (collision)
            {
                objects.Clear();
                PrintStringOnPosition(user.col, user.row, "(x)", ConsoleColor.Red);
            }
            else
            {
                PrintStringOnPosition(user.col, user.row, user.symbolString, user.color);
            }
            foreach (Rocks element in objects)
            {
                PrintOnPosition(element.col, element.row, element.symbol, element.color);
            }

            // Draw info
            //PrintStringOnPosition(0, 0, "user.col: " + user.col, ConsoleColor.White);
            Thread.Sleep(50);
        }
    }
}