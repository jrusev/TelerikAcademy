using System;

public class Message
{
    public void Invalid()
    {
        Console.WriteLine("* Invalid move!");
    }

    public void Move()
    {
        Console.Write("Enter your move (L=left, R=right, U=up, D=down): ");
    }
    
    public void Intro()
    {
        Console.WriteLine("Welcome to \"Labyrinth\" game. Please try to escape. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
    }

    public void NewLine()
    {
        Console.WriteLine();
    }

    public void Win(int moves)
    {
        Console.Write("Congratulations! You escaped in {0} moves.\nPlease enter your name for the top scoreboard: ", moves);        
    }

    public void Playing()
    {
        Console.WriteLine("You are playing \"Labyrinth\" game. Please try to escape. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
    }
}