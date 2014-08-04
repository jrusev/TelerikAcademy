using System;

public class HangmanGame
{
    private string wordToGuess;
    private char[] guessedLetters;

    private string[] words =
    {
        "computer",
        "programmer", 
        "software", 
        "debugger",
        "compiler",
        "developer",
        "algorithm",
        "array",
        "method",
        "variable"
    };

    private Random randomGenerator = new Random();

    public HangmanGame()
    {
        this.Reset();
    }

    public int Mistakes { get; private set; }

    public bool HelpUsed { get; private set; }

    public void Reset()
    {
        this.wordToGuess = this.GetRandomWord();
        this.guessedLetters = new char[this.wordToGuess.Length];

        for (int i = 0; i < this.wordToGuess.Length; i++)
        {
            this.guessedLetters[i] = '_';
        }

        this.Mistakes = 0;
        this.HelpUsed = false;
    }

    public char RevealLetter()
    {
        char result = char.MinValue;
        for (int i = 0; i < this.guessedLetters.Length; i++)
        {
            if (this.guessedLetters[i] == '_')
            {
                this.guessedLetters[i] = this.wordToGuess[i];
                result = this.wordToGuess[i];
                this.HelpUsed = true;
                break;
            }
        }

        return result;
    }

    public int CountLetterOccurance(char letter)
    {
        int count = 0;
        for (int i = 0; i < this.wordToGuess.Length; i++)
        {
            if (this.wordToGuess[i] == letter)
            {
                this.guessedLetters[i] = letter;
                count++;
            }
        }

        if (count == 0)
        {
            this.Mistakes++;
        }

        return count;
    }

    public void PrintCurrentProgress()
    {
        Console.Write("The secret word is: ");
        for (int i = 0; i < this.guessedLetters.Length; i++)
        {
            Console.Write("{0} ", this.guessedLetters[i]);
        }

        Console.WriteLine();
    }

    public bool GameIsOver()
    {
        for (int i = 0; i < this.guessedLetters.Length; i++)
        {
            if (this.guessedLetters[i] == '_')
            {
                return false;
            }
        }

        return true;
    }

    private string GetRandomWord()
    {
        int randIndex = this.randomGenerator.Next(this.words.Length);
        return this.words[randIndex];
    }
}
