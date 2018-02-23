using System.Collections.Generic;

public class Student
{
    private string name;
    private int age;
    private double grade;

    public Student(string name, int age, double grade)
    {
        this.Name = name;
        this.Age = age;
        this.Grade = grade;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public double Grade { get; set; }
}

public class StudentSystem
{
    private Dictionary<string, Student> students;

    public StudentSystem()
    {
        this.Students = new Dictionary<string, Student>();
    }

    public Dictionary<string, Student> Students { get; set; }
}