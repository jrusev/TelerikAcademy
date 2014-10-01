using System;
using System.Collections.Generic;
using HttpRequestResponseMessage.Models;

class Program
{
    static void Main()
    {
        var baseUrl = "http://localhost:5309/";
        var requester = new HttpRequester(baseUrl);

        var newStudent = new Student()
        {
            FirstName = "Nikolay 2",
            LastName = "Kostov 2"
        };

        var createStudentTask = requester.PostAsync<Student>("api/students", newStudent);

        createStudentTask
            .GetAwaiter()
            .OnCompleted(() =>
            {
                Console.WriteLine("Student {0} created!", createStudentTask.Result.FullName);
                var students = requester.Get<IEnumerable<Student>>("api/students");
                foreach (var student in students)
                {
                    Console.WriteLine(student.FullName);
                }
            });
        while (true)
        {
            Console.ReadLine();
        }
    }
}
