namespace _10_PredicateParty
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class PredicateParty
    {
        public static void Main()
        {
            var partyPeople = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();

            string commands;
            while ((commands = Console.ReadLine()) != "Party!")
            {
                var tokens = commands.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
                var operation = tokens[0];
                var command = tokens[1];
                var parameter = tokens[2];

                if (operation == "Remove")
                {
                    RemovePeople(command, parameter, partyPeople);
                }

                else if (operation == "Double")
                {
                    DoublePeople(command, parameter, partyPeople);
                }
            }

            PrintPeople(partyPeople);
        }

        public static void DoublePeople(string command, string parameter, List<string> partyPeople)
        {
            if (command == "StartsWith")
            {
                var doubled = partyPeople.Where(x => x.StartsWith(parameter)).ToList();
                InsertPeople(doubled, partyPeople);
            }
            else if (command == "EndsWith")
            {
                var doubled = partyPeople.Where(x => x.EndsWith(parameter)).ToList();
                InsertPeople(doubled, partyPeople);
            }
            else if (command == "Length")
            {
                var doubled = partyPeople.Where(x => x.Length == int.Parse(parameter)).ToList();
                InsertPeople(doubled, partyPeople);
            }
        }

        public static void InsertPeople(List<string> doubled, List<string> partyPeople)
        {
            for (var i = 0; i < doubled.Count(); i++)
            {
                partyPeople.Insert(i, doubled[i]);
            }
        }

        public static void RemovePeople(string command, string parameter, List<string> partyPeople)
        {
            if (command == "StartsWith")
            {
                partyPeople.RemoveAll(x => x.StartsWith(parameter));
            }
            else if (command == "EndsWith")
            {
                partyPeople.RemoveAll(x => x.EndsWith(parameter));
            }
            else if (command == "Length")
            {
                partyPeople.RemoveAll(x => x.Length == int.Parse(parameter));
            }
        }

        public static void PrintPeople(List<string> partyPeople)
        {
            if (partyPeople.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }

            else
            {
                Console.Write(string.Join(", ", partyPeople));
                Console.WriteLine(" are going to the party!");
            }
        }
    }
}
