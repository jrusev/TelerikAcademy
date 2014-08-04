using System;
using System.IO;

public class Scoreboard
{
    public void ShowScoreboard()
    {
        this.Create();
        FileInfo file = new FileInfo("scoreboard");
        StreamReader fileReader = file.OpenText();
        string line = null;
        bool isEmpty = true;
        int i = 0;
        while ((line = fileReader.ReadLine()) != null)
        {
            isEmpty = false;
            string[] nameAndScore = line.Split();
            Console.WriteLine("{0}: {1}->{2}", ++i, nameAndScore[0], nameAndScore[1]);
        }

        if (isEmpty)
        {
            Console.WriteLine("Scoreboard is empty.");
        }

        fileReader.Close();
    }

    public void Add(string name, int score)
    {
        this.Create();

        FileInfo file = new FileInfo("scoreboard");
        StreamReader fileReader = file.OpenText();
        string line = null;
        int index = 0;
        int[] scores = new int[5];
        string[] names = new string[5];
        while ((line = fileReader.ReadLine()) != null)
        {
            string[] nameAndScore = line.Split();
            scores[index] = int.Parse(nameAndScore[1]);
            names[index++] = nameAndScore[0];
        }

        if (index < 5)
        {
            scores[index] = score;
            names[index] = name;
        }
        else
        {
            if (score < scores[index - 1])
            {
                scores[index - 1] = score;
                names[index - 1] = name;
            }
        }

        if (index == 5)
        {
            index = 4;
        }

        for (int i = 0; i <= index - 1; i++)
        {
            for (int j = i + 1; j <= index; j++)
            {
                if (scores[i] > scores[j])
                {
                    int swapValue = scores[i];
                    scores[i] = scores[j];
                    scores[j] = swapValue;
                    string swapValueString = names[i];
                    names[i] = names[j];
                    names[j] = swapValueString;
                }
            }
        }

        fileReader.Close();
        StreamWriter fileWriter = file.CreateText();
        for (int i = 0; i <= index; i++)
        {
            fileWriter.WriteLine("{0} {1}", names[i], scores[i], i + 1);
        }

        fileWriter.Close();
    }

    private void Create()
    {
        FileInfo file = new FileInfo("scoreboard");
        FileStream stream = file.Open(FileMode.OpenOrCreate, FileAccess.Read);
        stream.Close();
    }
}