using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private readonly RaceTower raceTower;

    public Engine(RaceTower raceTower)
    {
        this.raceTower = raceTower;
    }

    internal void Run()
    {
        while (!this.raceTower.IsRaceOver)
        {
            var commandArgs = Console.ReadLine().Split();
            var commandtype = commandArgs[0];
            var methodArgs = commandArgs.Skip(1).ToList();

            switch (commandtype)
            {
                case "RegisterDriver":
                    this.raceTower.RegisterDriver(methodArgs);
                    break;

                case "Leaderboard":
                    Console.WriteLine(this.raceTower.GetLeaderboard());
                    break;

                case "CompleteLaps":
                    var result = this.raceTower.CompleteLaps(methodArgs);
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        Console.WriteLine(result);
                    }
                    break;

                case "Box":
                    this.raceTower.DriverBoxes(methodArgs);
                    break;

                case "ChangeWeather":
                    this.raceTower.ChangeWeather(methodArgs);
                    break;

                default:
                    Console.WriteLine("INVALID COMMAND");
                    break;
            }
        }
    }
}