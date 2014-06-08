using System;

public class SimpleMathExam : Exam
{
    public const int TotalProblems = 2;

    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < 0 || problemsSolved > TotalProblems)
        {
            if (problemsSolved > TotalProblems)
            {
                throw new ArgumentOutOfRangeException(
                    "problemsSolved",
                    string.Format("Problems solved must be between 0 and {0}.", TotalProblems));
            }
        }

        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved { get; private set; }

    public override ExamResult Check()
    {
        if (this.ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: nothing done.");
        }
        else if (this.ProblemsSolved == 2)
        {
            return new ExamResult(6, 2, 6, "Average result: nothing done.");
        }

        return new ExamResult(0, 0, 0, "Invalid number of problems solved!");
    }
}
