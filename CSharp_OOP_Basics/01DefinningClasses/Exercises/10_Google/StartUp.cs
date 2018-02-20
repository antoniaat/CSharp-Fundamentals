using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var people = new List<Person>();

        string inputLine;
        while ((inputLine = Console.ReadLine()) != "End")
        {
            var tokens = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var name = tokens[0];

            var person = people.FirstOrDefault(p => p.Name == name);

            if (person == null)
            {
                person = new Person(name);
                people.Add(person);
            }

            switch (tokens[1])
            {
                case "company":
                    person.Company = new Company(tokens[2], tokens[3], double.Parse(tokens[4]));
                    break;

                case "pokemon":
                    person.Pokemons.Add(new Pokemon(tokens[2], tokens[3]));
                    break;

                case "parents":
                    person.Parents.Add(new Relative(tokens[2], tokens[3]));
                    break;

                case "children":
                    person.Children.Add(new Relative(tokens[2], tokens[3]));
                    break;

                case "car":
                    person.Car = new Car(tokens[2], int.Parse(tokens[3]));
                    break;
            }
        }

        var printPerson = Console.ReadLine();

        Console.WriteLine(people.FirstOrDefault(x => x.Name == printPerson)?.ToString());
    }
}