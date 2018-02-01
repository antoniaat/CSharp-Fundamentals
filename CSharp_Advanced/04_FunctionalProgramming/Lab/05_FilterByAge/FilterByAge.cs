namespace _05_FilterByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FilterByAge
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var students = new Dictionary<string, int>();

            AddStudents(n, students);

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine()?.Trim();

            CheckForConditionsAndPrint(students, condition, age, format);
        }

        private static void CheckForConditionsAndPrint(Dictionary<string, int> students, string condition, int age, string format)
        {
            if (condition == "older")
            {
                var olderStudents = students
                    .Where(x => x.Value >= age)
                    .ToDictionary(t => t.Key, t => t.Value);
                CheckForFormat(olderStudents, format);
            }

            else if (condition == "younger")
            {
                var youngerStudents = students
                    .Where(x => x.Value <= age)
                    .ToDictionary(t => t.Key, t => t.Value);
                CheckForFormat(youngerStudents, format);
            }
        }

        public static void CheckForFormat(Dictionary<string,int> students, string format)
        {
            foreach (var kvp in students)
            {
                switch (format)
                {
                    case "name":
                        Console.WriteLine($"{kvp.Key}");
                        break;
                    case "age":
                        Console.WriteLine($"{kvp.Value}");
                        break;
                    case "name age":
                        Console.WriteLine($"{kvp.Key} - {kvp.Value}");
                        break;
                }
            }
        }

        public static void AddStudents(int n, Dictionary<string, int> students)
        {
            for (var i = 0; i < n; i++)
            {
                var currentLine = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var currentName = currentLine[0];
                var currentAge = int.Parse(currentLine[1]);

                if (!students.ContainsKey(currentName))
                    students.Add(currentName, currentAge);
            }
        }
    }
}