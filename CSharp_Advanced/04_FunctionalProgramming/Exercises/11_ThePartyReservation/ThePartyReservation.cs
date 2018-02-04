namespace _11_ThePartyReservation
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class ThePartyReservation
    {
        public static void Main()
        {
            var invitations = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var partyPeopleList = new List<string>();

            string commands;
            while ((commands = Console.ReadLine()) != "Print")
            {
                var tokens = commands.Split(';').ToList();
                var operation = tokens[0];
                var command = tokens[1];
                var parameter = tokens[2];

                if (operation == "Add filter")
                    AddFilterCommands(command, partyPeopleList, invitations,parameter);

                else if (operation == "Remove filter")
                    RemoveFilterCommands(command, partyPeopleList, invitations, parameter);
            }

            Console.WriteLine(string.Join(" ", invitations));
        }

        private static void RemoveFilterCommands(string command, List<string> partyPeopleList, List<string> invitations, string parameter)
        {
            switch (command)
            {
                case "Starts with":
                    invitations.AddRange(partyPeopleList.Where(x => x.StartsWith(parameter)));
                    partyPeopleList.RemoveAll(x => x.StartsWith(parameter));
                    break;
                case "Ends with":
                    invitations.AddRange(partyPeopleList.Where(x => x.EndsWith(parameter)));
                    partyPeopleList.RemoveAll(x => x.EndsWith(parameter));
                    break;
                case "Length":
                    invitations.AddRange(partyPeopleList.Where(x => x.Length == int.Parse(parameter)));
                    partyPeopleList.RemoveAll(x => x.Length == int.Parse(parameter));
                    break;
                case "Contains":
                    invitations.AddRange(partyPeopleList.Where(x => x.Contains(parameter)));
                    partyPeopleList.RemoveAll(x => x.Contains(parameter));
                    break;
            }
        }

        public static void AddFilterCommands(string command, List<string> partyPeopleList, List<string> invitations, string parameter)
        {
            switch (command)
            {
                case "Starts with":
                    partyPeopleList.AddRange(invitations.Where(x => x.StartsWith(parameter)));
                    invitations.RemoveAll(x => x.StartsWith(parameter));
                    break;
                case "Ends with":
                    partyPeopleList.AddRange(invitations.Where(x => x.EndsWith(parameter)));
                    invitations.RemoveAll(x => x.EndsWith(parameter));
                    break;
                case "Length":
                    partyPeopleList.AddRange(invitations.Where(x => x.Length == int.Parse(parameter)));
                    invitations.RemoveAll(x => x.Length == int.Parse(parameter));
                    break;
                case "Contains":
                    partyPeopleList.AddRange(invitations.Where(x => x.Contains(parameter)));
                    invitations.RemoveAll(x => x.Contains(parameter));
                    break;
            }
        }
    }
}
