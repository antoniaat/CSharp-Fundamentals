using System;

public class StartUp
{
    public static void Main()
    {
        var studentsDict = new StudentSystem();

        while (true)
        {
            ParseCommand(studentsDict);
        }
    }

    public static void ParseCommand(StudentSystem studentsDict)
    {
        var args = Console.ReadLine().Split();

        if (args[0] == "Create")
        {
            var name = args[1];
            var age = int.Parse(args[2]);
            var grade = double.Parse(args[3]);

            if (studentsDict.Students.ContainsKey(name)) return;

            var student = new Student(name, age, grade);
            studentsDict.Students[name] = student;
        }

        else if (args[0] == "Show")
        {
            var name = args[1];
            if (!studentsDict.Students.ContainsKey(name)) return;

            var student = studentsDict.Students[name];
            var print = $"{student.Name} is {student.Age} years old.";

            if (student.Grade >= 5.00) print += " Excellent student.";

            else if (student.Grade < 5.00 && student.Grade >= 3.50) print += " Average student.";

            else print += " Very nice person.";

            Console.WriteLine(print);
        }

        else if (args[0] == "Exit") Environment.Exit(0);
    }
}
