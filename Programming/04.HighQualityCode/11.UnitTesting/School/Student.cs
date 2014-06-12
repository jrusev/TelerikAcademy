using System;
using System.Collections.Generic;

public class Student
{
    public const int MinID = 10000;
    public const int MaxID = 99999;

    public Student(string name, int id)
    {
        if (id < MinID || id > MaxID)
        {
            throw new ArgumentOutOfRangeException("id", "ID is out of range!");
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name must not be null or empty!");
        }

        this.Name = name;
        this.Id = id;
    }

    public string Name { get; private set; }

    public int Id { get; private set; }
}