using System;

public class ScoreBoard
{
    public const int ScoreboardCapacity = 5;
    private string[] scoreboardNames = new string[ScoreboardCapacity];
    private int[] scoreboardMistakes = new int[ScoreboardCapacity];
    private bool isEmpty;

    public ScoreBoard()
    {
        for (int i = 0; i < this.scoreboardNames.Length; i++)
        {
            this.scoreboardMistakes[i] = int.MaxValue;
        }

        this.isEmpty = true;
    }

    public void Print()
    {
        if (this.isEmpty)
        {
            Console.WriteLine("Scoreboard is empty!");
        }
        else
        {
            Console.WriteLine("Scoreboard:");
            int i = 0;
            while (this.scoreboardNames[i] != null)
            {
                Console.WriteLine("{0}. {1} ---> {2} mistacke(s)!", i + 1, this.scoreboardNames[i], this.scoreboardMistakes[i]);
                i++;
                if (i >= this.scoreboardNames.Length)
                {
                    break;
                }
            }
        }
    }

    public void AddNewScore(string name, int mistakes)
    {
        int indexToPutNewScore = this.GetNewScoreIndex(mistakes);
        if (indexToPutNewScore == this.scoreboardNames.Length)
        {
            return;
        }
        else
        {
            this.ShiftScoresDown(indexToPutNewScore);
            this.scoreboardNames[indexToPutNewScore] = name;
            this.scoreboardMistakes[indexToPutNewScore] = mistakes;
            this.isEmpty = false;
        }
    }

    public int GetWorstTopScore()
    {
        int worstTopScore = int.MaxValue;
        if (this.scoreboardNames[this.scoreboardNames.Length - 1] != null)
        {
            worstTopScore = this.scoreboardMistakes[this.scoreboardNames.Length - 1];
        }

        return worstTopScore;
    }

    public void ReSet()
    {
        for (int i = 0; i < this.scoreboardNames.Length; i++)
        {
            this.scoreboardNames[i] = null;
            this.scoreboardMistakes[i] = 0;
        }

        this.isEmpty = true;
    }

    private int GetNewScoreIndex(int mistakes)
    {
        for (int i = 0; i < this.scoreboardMistakes.Length; i++)
        {
            if (mistakes < this.scoreboardMistakes[i])
            {
                return i;
            }
        }

        return this.scoreboardNames.Length;
    }

    private void ShiftScoresDown(int startPosition)
    {
        for (int i = this.scoreboardNames.Length - 1; i > startPosition; i--)
        {
            this.scoreboardNames[i] = this.scoreboardNames[i - 1];
            this.scoreboardMistakes[i] = this.scoreboardMistakes[i - 1];
        }
    }
}
