using System;

public class StartUp
{
    public static void Main()
    {
        var nPeople = int.Parse(Console.ReadLine());
        var currentFamilly = new Family();

        for (var person = 0; person < nPeople; person++)
        {
            var tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var name = tokens[0];
            var age = int.Parse(tokens[1]);

            var currentPerson = new Person(name, age);
            currentFamilly.AddMember(currentPerson);
        }

        Console.WriteLine($"{currentFamilly.GetOldestMember().Name} {currentFamilly.GetOldestMember().Age}");
    }
}