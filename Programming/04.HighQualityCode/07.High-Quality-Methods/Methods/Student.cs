using System;

public class Student
{
    public Student(string firstName, string lastName, DateTime birthDate)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.BirthDate = birthDate;
    }

    // TODO: add checks
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public DateTime BirthDate { get; private set; }

    public string Town { get; set; }

    public string OtherInfo { get; set; }

    public bool IsOlderThan(Student other)
    {
        return this.BirthDate > other.BirthDate;
    }
}
