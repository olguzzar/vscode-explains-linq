using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class Tests
{
    [Fact]
    public void TestGetQuery4()
    {
        // Arrange
        var students = new List<Student>
        {
            new Student { Id = 1, Name = "Alice", Age = 20, Major = "Math" },
            new Student { Id = 2, Name = "Bob", Age = 21, Major = "Physics" },
            new Student { Id = 3, Name = "Charlie", Age = 22, Major = "Chemistry" }
        };

        var grades = new List<Grade>
        {
            new Grade { StudentId = 1, Course = "Calculus", Score = 90 },
            new Grade { StudentId = 1, Course = "Algebra 1", Score = 80 },
            new Grade { StudentId = 2, Course = "Algebra 2", Score = 85 },
            new Grade { StudentId = 3, Course = "Algebra 1", Score = 95 },
            new Grade { StudentId = 3, Course = "Algebra 2", Score = 75 }
        };

        // Act
        var result = Program.GetQuery4(students, grades);

        // Assert
        Assert.Equal(2, result.Count());
        Assert.Equal("Algebra 1", result.ElementAt(0).Course);
        Assert.Equal("Algebra 2", result.ElementAt(1).Course);
    }
}