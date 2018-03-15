using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private readonly RaceTower _raceTower;

    public Engine(RaceTower raceTower)
    {
        this._raceTower = raceTower;
    }

    public void Run()
    {
        int numberOfLaps = int.Parse(Console.ReadLine());
        int lenghtOfTheTrack = int.Parse(Console.ReadLine());

        _raceTower.SetTrackInfo(numberOfLaps, lenghtOfTheTrack);

        while (_raceTower.currentLapsNum > 0)
        {
            string inputLine = Console.ReadLine();
            List<string> inputParams = inputLine.Split().ToList();
            string commandResult = this.DispatchCommand(inputParams);
            if(commandResult != null) Console.WriteLine(commandResult);
        }

        _raceTower.FinishGame();
    }

    private string DispatchCommand(List<string> inputParams)
    {
        string command = inputParams[0];
        inputParams.RemoveAt(0);

        string result = null;

        switch (command)
        {
            case "RegisterDriver":
                _raceTower.RegisterDriver(inputParams);
                break;

            case "Leaderboard":
                result = _raceTower.GetLeaderboard();
                break;

            case "CompleteLaps":
                result = _raceTower.CompleteLaps(inputParams);
                break;

            case "Box":
                _raceTower.DriverBoxes(inputParams);
                break;

            case "ChangeWeather":
                _raceTower.ChangeWeather(inputParams);
                break;
        }

        return result;
    }
}
