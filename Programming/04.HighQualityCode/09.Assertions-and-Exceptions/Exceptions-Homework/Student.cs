using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException("firstName cannot be null or empty.", "firstName");
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("lastName cannot be null or empty.", "lastName");
        }

        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams ?? new List<Exam>();
    }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public IList<Exam> Exams { get; private set; }

    public IList<ExamResult> GetExamResults()
    {
        var results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams.Count == 0)
        {
            throw new InvalidOperationException("Unable to calculate average exam results: no exams");
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = this.GetExamResults();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = 
                ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
