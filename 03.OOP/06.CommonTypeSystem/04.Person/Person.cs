// Create a class Person with two fields – name and age.
// Age can be left unspecified (may contain null value.
// Override ToString() to display the information of a person and if age is not specified – to say so.
// Write a program to test this functionality.
public class Person
{
    private string name;
    private byte? age;

    public Person(string name, byte? age = null)
    {
        this.name = name;
        this.age = age;
    }

    public override string ToString()
    {
        return this.name + string.Format(this.age == null ? " (age not specified)" : " (age : {0})", this.age);
    }
}