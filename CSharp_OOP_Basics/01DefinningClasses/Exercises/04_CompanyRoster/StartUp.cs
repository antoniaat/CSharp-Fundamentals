using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var employees = new List<Employee>();
        var highestSalary = new Dictionary<string, List<decimal>>();

        for (var i = 0; i < n; i++)
        {
            var currentLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var name = currentLine[0];
            var salary = decimal.Parse(currentLine[1]);
            var position = currentLine[2];
            var department = currentLine[3];
            Employee employee;

            if (currentLine.Length == 5)
            {
                bool isDigit = char.IsDigit(currentLine[4][0]);
                if (isDigit)
                {
                    var age = int.Parse(currentLine[4]);
                    employee = new Employee(name, salary, position, department, age);
                }
                else
                {
                    var email = currentLine[4];
                    employee = new Employee(name, salary, position, department, email);
                }
            }
            else if (currentLine.Length == 6)
            {
                bool isDigit = char.IsDigit(currentLine[4][0]);

                if (isDigit)
                {
                    var email = currentLine[5];
                    var age = int.Parse(currentLine[4]);
                    employee = new Employee(name, salary, position, department, age, email);
                }
                else
                {
                    var email = currentLine[4];
                    var age = int.Parse(currentLine[5]);
                    employee = new Employee(name, salary, position, department, email, age);
                }
            }
            else
            {
                employee = new Employee(name, salary, position, department);
            }

            employees.Add(employee);
        }

        foreach (var employee in employees)
        {
            if (employee.Email == null)
            {
                employee.Email = "n/a";
            }
            if (employee.Age == 0)
            {
                employee.Age = -1;
            }
        }

        foreach (var em in employees)
        {
            if (!highestSalary.ContainsKey(em.Department))
            {
                highestSalary.Add(em.Department, new List<decimal>());
            }

            highestSalary[em.Department].Add(em.Salary);
        }

        var highestAvg = highestSalary.OrderByDescending(x => x.Value.Sum() / x.Value.Count)
            .Take(1)
            .First();

        Console.WriteLine($"Highest Average Salary: {highestAvg.Key}");

        employees.Where(x => x.Department == highestAvg.Key)
            .OrderByDescending(x => x.Salary)
            .ToList()
            .ForEach(Console.WriteLine);
    }
}