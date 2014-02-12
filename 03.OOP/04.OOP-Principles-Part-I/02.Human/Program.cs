namespace Human
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension method).
    // Initialize a list of 10 workers and sort them by money per hour in descending order.
    // Merge the lists and sort them by first name and last name.
    internal class Program
    {
        private static readonly Random Rand = new Random();

        private static void Main()
        {
            IEnumerable<Student> students = GetRandomStudents(10);

            students = students.OrderBy(s => s.Grade);

            Console.WriteLine("STUDENTS");
            Console.WriteLine("=============================");
            Console.WriteLine(string.Join<Student>(Environment.NewLine, students));

            IEnumerable<Worker> workers = GetRandomWorkers(10);

            workers = workers.OrderBy(w => -w.MoneyPerHour());

            Console.WriteLine("\nWORKERS");
            Console.WriteLine("=============================");
            Console.WriteLine(string.Join<Worker>(Environment.NewLine, workers));

            var merged = students.Concat<Human>(workers).OrderBy(h => h.FirstName).ThenBy(h => h.LastName).Select(h => h.FirstName + " " + h.LastName);

            Console.WriteLine("\nMERGED");
            Console.WriteLine("=============================");
            Console.WriteLine(string.Join(Environment.NewLine, merged));
        }

        private static Student[] GetRandomStudents(int n)
        {
            Student[] students = new Student[n];
            for (int i = 0; i < n; i++)
            {
                students[i] = RandomStudent();
            }

            return students;
        }

        private static Worker[] GetRandomWorkers(int n)
        {
            Worker[] workers = new Worker[n];
            for (int i = 0; i < n; i++)
            {
                workers[i] = RandomWorker();
            }

            return workers;
        }

        private static Student RandomStudent()
        {
            return new Student(RandomNames.RandFirstName(), RandomNames.RandSecondName(), RandGrade());
        }

        private static Worker RandomWorker()
        {
            return new Worker(RandomNames.RandFirstName(), RandomNames.RandSecondName(), RandSalary(), 8);
        }

        private static int RandGrade()
        {
            return Rand.Next(1, 12);
        }

        private static int RandSalary()
        {
            return Rand.Next(150, 300);
        }  
    }
}