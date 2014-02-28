// Task 1:
// Define a class Student, which contains data about a student – first, middle and last name,
// SSN, permanent address, mobile phone e-mail, course, specialty, university, faculty.
// Use an enumeration for the specialties, universities and faculties.
// Override the standard methods, inherited by  System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.
//
// Task 2:
// Add implementations of the ICloneable interface. The Clone() method should deeply copy all object's fields into a new object of type Student.
//
// Task 3:
// Implement the  IComparable<Student> interface to compare students
// by names (as first criteria, in lexicographic order)
// and by social security number (as second criteria, in increasing order).
using System;

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

public class Student : ICloneable, IComparable<Student>
{
    public Student(string firstName, string lastName, ulong ssn, University uni, Faculty fac, Specialty spec)
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

    public ulong SSN { get; set; }

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

    /// <summary>
    /// Creates a deep copy of the Student.
    /// </summary>
    public object Clone()
    {
        // From MSDN: Because the Clone method simply returns the existing string instance,
        // there is little reason to call it directly.
        Student deepClone = new Student(
            (string)this.FirstName.Clone(),
            this.LastName,
            this.SSN,
            this.University,
            this.Faculty,
            this.Specialty);

        deepClone.Phone = this.Phone;
        deepClone.Address = this.Address;
        deepClone.Email = this.Email;
        deepClone.Course = this.Course;

        return deepClone;
    }

    /// <summary>
    /// Compare studetns by by names (as first criteria, in lexicographic order)
    /// and by social security number (as second criteria, in increasing order).
    /// </summary>
    public int CompareTo(Student other)
    {
        int firstNamesCompare = string.Compare(this.FirstName, other.FirstName);
        if (firstNamesCompare != 0)
        {
            return firstNamesCompare;
        }
        else
        {
            if (this.SSN > other.SSN)
            {
                return 1;
            }
            else if (this.SSN < other.SSN)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }        
    }
}