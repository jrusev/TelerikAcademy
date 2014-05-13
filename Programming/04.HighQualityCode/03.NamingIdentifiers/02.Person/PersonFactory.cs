public class PersonFactory
{
    public enum Sex
    { 
        male,
        female
    }

    public void MakePerson(int personID)
    {
        var person = new Person();
        person.Age = personID;

        if (personID % 2 == 0)
        {
            person.Name = "Батката";
            person.Sex = Sex.male;
        }
        else
        {
            person.Name = "Мацето";
            person.Sex = Sex.female;
        }
    }

    public class Person
    {
        public Sex Sex { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
