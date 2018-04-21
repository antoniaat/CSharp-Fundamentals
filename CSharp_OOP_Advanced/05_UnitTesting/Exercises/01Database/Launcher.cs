using System;
using System.Linq;

public class Launcher
{
    public static void Main()
    {
        int[] tokens = Console.ReadLine()?
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        var db = new Database(tokens);

        ReadCommands(db);
    }

    private static void ReadCommands(Database db)
    {
        string command;
        while ((command = Console.ReadLine()) != "STOP")
        {
            var args = command?.Split(' ');

            switch (args[0])
            {
                case "Add":
                    db.Add(int.Parse(args[1]));
                    break;
                case "Remove":
                    db.Remove();
                    break;
                case "Fetch":
                    var returnedArray = db.Fetch();

                    foreach (var num in returnedArray)
                    {
                        Console.Write($"{num} ");
                    }

                    break;
            }
        }
    }
}
