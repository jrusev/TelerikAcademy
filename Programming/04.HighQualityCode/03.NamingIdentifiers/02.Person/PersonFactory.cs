using System;

public class PersonFactory
{
    public enum Sex
    { 
        male,
        female
    }

    public static Person MakePerson(int age)
    {
        var person = new Person();
        person.Age = age;

        if (age % 2 == 0)
        {
            person.Name = "Батката";
            person.Sex = Sex.male;
        }
        else
        {
            person.Name = "Мацето";
            person.Sex = Sex.female;
        }

        return person;
    }

    public static void Main()
    {
        Console.WriteLine(MakePerson(21));
    }

    public class Person
    {
        public Sex Sex { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Sex: {1}, Age: {2}", this.Name, this.Sex, this.Age);
        }
    }
}
