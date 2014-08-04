namespace PoppingBaloons
{
    using System;

    internal class EntryPoint
    {
        internal static void Main()
        {
            Console.WriteLine("Welcome to “Balloons Pops” game. Please try to pop the balloons.");
            Console.WriteLine(" Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            GameEngine game = new GameEngine();
            while (true)
            {
                game.ParseCommand(Console.ReadLine());
            }
        }
    }
}
