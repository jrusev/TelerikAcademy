using System;

public class EntryPoint
{
    internal static void Main()
    {
        ScoreBoard scoreBoard = new ScoreBoard();
        HangmanGame game = new HangmanGame();
        Console.WriteLine("Welcome to “Hangman” game. Please try to guess my secret word.");
        string command = null;
        while (command != "exit")
        {
            Console.WriteLine();
            game.PrintCurrentProgress();
            if (game.GameIsOver())
            {
                if (game.HelpUsed)
                {
                    Console.WriteLine(
                        "You won with {0} mistake(s) but you have cheated." +
                        " You are not allowed to enter into the scoreboard.",
                        game.Mistakes);
                }
                else
                {
                    if (scoreBoard.GetWorstTopScore() <= game.Mistakes)
                    {
                        Console.WriteLine(
                            "You won with {0} mistake(s) but you score did not enter in the scoreboard",
                            game.Mistakes);
                    }
                    else
                    {
                        Console.Write("Please enter your name for the top scoreboard: ");
                        string name = Console.ReadLine();
                        scoreBoard.AddNewScore(name, game.Mistakes);
                        scoreBoard.Print();
                    }
                }

                game.Reset();
            }
            else
            {
                Console.Write("Enter your guess: ");
                command = Console.ReadLine();
                command.ToLower();
                if (command.Length == 1)
                {
                    int revealedLetterCount = game.CountLetterOccurance(command[0]);
                    if (revealedLetterCount == 0)
                    {
                        Console.WriteLine("Sorry! There are no unrevealed letters “{0}”.", command[0]);
                    }
                    else
                    {
                        Console.WriteLine("Good job! You revealed {0} letter(s).", revealedLetterCount);
                    }
                }
                else
                {
                    ExecuteCommand(command, scoreBoard, game);
                }
            }
        }
    }

    private static void ExecuteCommand(string command, ScoreBoard scoreBoard, HangmanGame game)
    {
        switch (command)
        {
            case "top":
                scoreBoard.Print();
                break;
            case "help":
                char revealedLetter = game.RevealLetter();
                Console.WriteLine("OK, I reveal for you the next letter '{0}'.", revealedLetter);
                break;
            case "restart":
                scoreBoard.ReSet();
                Console.WriteLine("\nWelcome to “Hangman” game. Please try to guess my secret word.");
                game.Reset();
                break;
            case "exit":
                Console.WriteLine("Good bye!");
                break;
            default:
                Console.WriteLine("Incorrect guess or command!");
                break;
        }
    }
}