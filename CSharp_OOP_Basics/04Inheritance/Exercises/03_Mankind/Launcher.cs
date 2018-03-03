using System;

public class Launcher
{
    public static void Main()
    {
        try
        {
            var studentTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var studentFirstName = studentTokens[0];
            var studentLastName = studentTokens[1];
            var facultyNumber = studentTokens[2];

            var student = new Student(studentFirstName, studentLastName, facultyNumber);

            var workerTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var workerFirstName = workerTokens[0];
            var workerLastName = workerTokens[1];
            var weekSalary = decimal.Parse(workerTokens[2]);
            var hoursPerDay = decimal.Parse(workerTokens[3]);

            var worker = new Worker(workerFirstName, workerLastName, weekSalary, hoursPerDay);

            Console.WriteLine(student + Environment.NewLine);
            Console.WriteLine(worker);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}