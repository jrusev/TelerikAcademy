using System;

public class CSharpExam : Exam
{
    private const int MinScore = 0;
    private const int MaxScore = 100;

    public CSharpExam(int score)
    {
        if (!(MinScore <= score && score <= MaxScore))
        {
            throw new ArgumentOutOfRangeException("score", string.Format("Score must be in the range between {0} and {1}.", MinScore, MaxScore));
        }

        this.Score = score;
    }

    // No need for validation here - the setter is private
    public int Score { get; private set; }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, MinScore, MaxScore, "Exam results calculated by score.");
    }
}
