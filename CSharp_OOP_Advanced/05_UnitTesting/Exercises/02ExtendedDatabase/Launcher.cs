using System;

namespace _02ExtendedDatabase
{
    public class Launcher
    {
        public static Database Database = new Database();

        public static void Main()
        {
            ReadCommands();
        }

        private static void ReadCommands()
        {
            string command;
            while ((command = Console.ReadLine()) != "STOP")
            {
                var args = command.Split(' ');
                CommandDispatcher(args);
            }
        }

        private static void CommandDispatcher(string[] args)
        {
            if (args[0] == "Add")
            {
                var person = new Person(long.Parse(args[1]), args[2]);
                Database.Add(person);
            }
            else if (args[0] == "Remove")
            {
                Database.Remove();
            }
            else if (args[0] == "Fetch")
            {
                Database.Fetch();
            }
            else if (args[0] == "FindById")
            {
                Console.WriteLine(Database.FindById(long.Parse(args[1])));
            }
            else if (args[0] == "FindByUsername")
            {
                Console.WriteLine(Database.FindByUsername(args[1]));
            }
            else
            {
                Console.WriteLine("Invalid command.");
            }
        }
    }
}
    