using System;

class AllCards
{
    static void Main()
    {
        // Write a program that prints all possible cards from a standard deck of 52 cards (without jokers).
        // The cards should be printed with their English names. Use nested for() loops and switch-case.

        string[] value = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "K", "Q", "A" };
        string[] rank = { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "King", "Queen", "Ace" };
        string[] suit = { "Spades", "Hearts", "Diamonds", "Clubs"};

        for (int c = 0; c < 4; c++)
        {
            for (int v = 0; v < value.Length; v++)
            {
                Console.Write("{0,2}",value[v]);
                switch (c)
                {
                    case 0:
                        Console.Write('\u0006'); // spades
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('\u0003'); // hearts
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('\u0004'); // diamonds
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 3:
                        Console.Write('\u0005'); // clubs
                        break;
                }
                Console.WriteLine("  {0} of {1}",rank[v],suit[c]);
            }
            Console.WriteLine();
        }
    }
}