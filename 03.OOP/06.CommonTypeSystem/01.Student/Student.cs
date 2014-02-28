// Define a class Student, which contains data about a student – first, middle and last name,
// SSN, permanent address, mobile phone e-mail, course, specialty, university, faculty.
// Use an enumeration for the specialties, universities and faculties.
// Override the standard methods, inherited by  System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.
public enum Specialty
{
    Mathematics,
    Physics,
    ComputerScience,
    Management,
    Psychology
}

public enum University
{
    Harvard,
    MIT,
    Stanford
}

public enum Faculty
{
    Engineering,
    Business,
    Phylosophy
}

public class Student
{
    public Student(string firstName, string lastName, string ssn, University uni, Faculty fac, Specialty spec)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.SSN = ssn;
        this.University = uni;
        this.Faculty = fac;
        this.Specialty = spec;
    }

    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    public string LastName { get; set; }

    public string SSN { get; set; }

    public string Address { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public uint Course { get; set; }

    public University University { get; set; }

    public Faculty Faculty { get; set; }

    public Specialty Specialty { get; set; }

    public static bool operator ==(Student studentA, Student studentB)
    {
        // Calls the static Object.Equals, which first checks if the objects are equal by reference,
        // then if either one of them is null, and finally calls the virtual Equals,
        // which we have overriden here
        return Student.Equals(studentA, studentB);
    }

    public static bool operator !=(Student studentA, Student studentB)
    {
        return !Student.Equals(studentA, studentB);
    }

    public override bool Equals(object obj)
    {
        Student student = obj as Student;
        if (student == null)
        {
            return false;
        }

        // The Social Security Number guarantees that the person is the same...
        if (this.SSN != student.SSN)
        {
            return false;
        }

        // ... but we must also make sure it is the same student
        if (this.University != student.University)
        {
            return false;
        }

        if (this.Faculty != student.Faculty)
        {
            return false;
        }

        if (this.Specialty != student.Specialty)
        {
            return false;
        }

        return true;
    }

    public override int GetHashCode()
    {
        return
            this.SSN.GetHashCode() ^
            this.University.GetHashCode() ^
            this.Faculty.GetHashCode() ^
            this.Specialty.GetHashCode();
    }

    public override string ToString()
    {
        string str = string.Format("{0} {1}: {2}, {3}, {4}", this.FirstName, this.LastName, this.University, this.Faculty, this.Specialty);
        return str;
    }
}