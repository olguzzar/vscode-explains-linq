using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Major { get; set; }
}

class Grade
{
    public int StudentId { get; set; }
    public string? Course { get; set; }
    public int Score { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Create some sample data
        List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Alice", Age = 20, Major = "Computer Science" },
            new Student { Id = 2, Name = "Bob", Age = 21, Major = "Mathematics" },
            new Student { Id = 3, Name = "Charlie", Age = 19, Major = "English" },
            new Student { Id = 4, Name = "David", Age = 22, Major = "History" }
        };

        List<Grade> grades = new List<Grade>
        {
            new Grade { StudentId = 1, Course = "Programming 101", Score = 90 },
            new Grade { StudentId = 1, Course = "Data Structures", Score = 85 },
            new Grade { StudentId = 2, Course = "Calculus", Score = 95 },
            new Grade { StudentId = 2, Course = "Linear Algebra", Score = 80 },
            new Grade { StudentId = 3, Course = "Shakespeare", Score = 75 },
            new Grade { StudentId = 4, Course = "Art History", Score = 88 }
        };

        // LINQ queries
        var query1 = from s in students
                     where s.Age > 20
                     select s;

        var query2 = from s in students
                     join g in grades on s.Id equals g.StudentId
                     where g.Score >= 80
                     select new { s.Name, g.Course };

        var query3 = from s in students
                     where s.Major == "Computer Science"
                     select s;

        var query4 = from g in grades
                     where g.Course?.Contains("Algbra") == true
                     select g;

        var query5 = from s in students
                     join g in grades on s.Id equals g.StudentId
                     where g.Score >= 80 && s.Age > 20
                     select new { s.Name, g.Course };

        // Output results
        Console.WriteLine("Students over 20:");
        foreach (var student in query1)
        {
            Console.WriteLine(student.Name);
        }

        Console.WriteLine("\nCourses with grades of 80 or higher:");
        foreach (var result in query2)
        {
            Console.WriteLine($"{result.Name}: {result.Course}");
        }

        Console.WriteLine("\nStudents majoring in Computer Science:");
        foreach (var student in query3)
        {
            Console.WriteLine(student.Name);
        }

        Console.WriteLine("\nGrades for courses containing 'Algebra':");
        foreach (var grade in query4)
        {
            Console.WriteLine($"{grade.StudentId}: {grade.Course} - {grade.Score}");
        }

        Console.WriteLine("\nCourses with grades of 80 or higher and students over 20:");
        foreach (var result in query5)
        {
            Console.WriteLine($"{result.Name}: {result.Course}");
        }
    }
}

