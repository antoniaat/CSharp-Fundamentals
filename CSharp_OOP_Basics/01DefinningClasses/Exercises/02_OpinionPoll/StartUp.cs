using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var poll = new OpinionPoll();

        for (var person = 0; person < n; person++)
        {
            var tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var name = tokens[0];
            var age = int.Parse(tokens[1]);

            var currentPerson = new Person(name, age);
            poll.AddMember(currentPerson);
        }

        foreach (var person in poll.PeopleList.OrderBy(x => x.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}