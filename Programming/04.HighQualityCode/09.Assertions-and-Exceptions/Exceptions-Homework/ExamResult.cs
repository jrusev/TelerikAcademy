using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("grade", "Grade cannot be less than zero!");
        }

        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("minGrade", "MinGrade cannot be less than zero!");
        }

        if (maxGrade < 0)
        {
            throw new ArgumentOutOfRangeException("maxGrade", "MaxGrade cannot be less than zero!");
        }

        if (maxGrade < minGrade)
        {
            throw new ArgumentOutOfRangeException("maxGrade", "MaxGrade cannot be less than minGrade!");
        }

        if (grade < minGrade || grade > maxGrade)
        {
            throw new ArgumentOutOfRangeException("grade", string.Format("Grade must be between {0} and {1}!", minGrade, maxGrade));
        }

        if (string.IsNullOrWhiteSpace(comments))
        {
            throw new ArgumentException("Comments cannot be null or empty!", "comments");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }
}
