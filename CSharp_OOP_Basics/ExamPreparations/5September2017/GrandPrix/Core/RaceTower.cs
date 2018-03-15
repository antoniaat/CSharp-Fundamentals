using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private string currentWeather;

    private int _trackLenght;

    private Dictionary<string, Driver> _driversByName;

    private readonly Dictionary<string, Driver> _failedDrivers;

    private readonly DriverFactory _driverFactory;

    public int Laps { get; private set; }

    public int currentLapsNum;

    public int CurrentLapsNum
    {
        get => this.currentLapsNum;

        set => this.currentLapsNum = value + this.Laps;
    }
    public RaceTower()
    {
        this.currentWeather = "Sunny";
        this._driverFactory = new DriverFactory();
        this._driversByName = new Dictionary<string, Driver>(); // Name, Driver
        this._failedDrivers = new Dictionary<string, Driver>(); // Failure Reason, Driver
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.Laps = lapsNumber;
        this._trackLenght = trackLength;
        this.currentLapsNum = lapsNumber;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        var type = commandArgs[0];
        var name = commandArgs[1];
        var horsePower = int.Parse(commandArgs[2]);
        var fuelAmount = double.Parse(commandArgs[3]);
        var tyreType = commandArgs[4];
        var tyreHardness = double.Parse(commandArgs[5]);
        var grip = commandArgs.Count > 6 ? double.Parse(commandArgs[6]) : 0;

        Driver newDriver = null;
        Tyre tyre = CreateTyre(tyreType, tyreHardness, grip);
        Car car = new Car(horsePower, fuelAmount, tyre);

        try
        {
            newDriver = this._driverFactory.ProduceDriver(type, name, car);
        }

        catch (ArgumentException)
        {
            return;
        }

        this._driversByName.Add(newDriver.Name, newDriver);
    }

    private Tyre CreateTyre(string tyreType, double tyreHardness, double grip)
    {
        Tyre tyre = null;

        if (tyreType == "Ultrasoft")
        {
            tyre = new UltrasoftTyre(tyreHardness, grip);
        }
        else if (tyreType == "Hard")
        {
            tyre = new HardTyre(tyreHardness);
        }

        return tyre;
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string reasonToBox = commandArgs[0];
        string driverName = commandArgs[1];

        if (_driversByName.ContainsKey(driverName))
        {
            _driversByName[driverName].TotalTime += 20;

            if (reasonToBox == "ChangeTyres")
            {
                var tyreHardness = double.Parse(commandArgs[3]);
                var grip = commandArgs.Count == 5 ? double.Parse(commandArgs[4]) : 0;
                _driversByName[driverName].Car.Tyre.ChangeTyres(tyreHardness, grip);
            }

            else if (reasonToBox == "Refuel")
            {
                var fuelAmount = double.Parse(commandArgs[2]);
                _driversByName[driverName].Car.FuelAmount += fuelAmount;
            }
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        int numOfLaps = int.Parse(commandArgs[0]);
        if (currentLapsNum - numOfLaps > 0)
        {
            int counter = 1;
            foreach (var driver in _driversByName)
            {
                try
                {
                    driver.Value.TotalTime += 60 / (_trackLenght / driver.Value.Speed);
                    driver.Value.Car.FuelAmount -= _trackLenght * driver.Value.FuelConsumptionPerkm;
                    driver.Value.Car.Tyre.ReduceDegradation();
                }
                catch (Exception exception)
                {
                    _failedDrivers.Add(exception.Message, driver.Value); // Throws exception
                    _driversByName.Remove(driver.Key);
                }
                counter++;
                if (counter == numOfLaps) break;
            }

            this.currentLapsNum -= numOfLaps;
            CheckForOvertaking();
        }

        else
        {
            Console.WriteLine($"There is no time! On lap {numOfLaps}.");
        }

        return null;
    }

    private void CheckForOvertaking()
    {
        var driversSortedByTotalTime = _driversByName.OrderBy(x => x.Value.TotalTime).ToDictionary(x => x.Key, y => y.Value);

        for (int index = driversSortedByTotalTime.Count; index >= 2; index -= 2)
        {
            var driverWhoIsBehind = driversSortedByTotalTime.ElementAt(index - 1);
            var driverInFront = driversSortedByTotalTime.ElementAt(index - 2);
            var intervalOfTimeBetweenDrivers = driverWhoIsBehind.Value.TotalTime - driverInFront.Value.TotalTime;

            if (SpecialCasesForOvertakingSucceed(index))
            {
                Console.WriteLine(string.Format(Constants.SuccessfulOvertakingMessage, driverWhoIsBehind.Key), driverInFront.Key);
                continue;
            }

            if (intervalOfTimeBetweenDrivers <= 2)
            {
                driverWhoIsBehind.Value.TotalTime += intervalOfTimeBetweenDrivers;
                driverInFront.Value.TotalTime -= intervalOfTimeBetweenDrivers;
            }
        }
    }

    private bool SpecialCasesForOvertakingSucceed(int index)
    {
        bool failureSucceed = false;

        // AggressiveDriver on UltrasoftTyre has an overtake interval up to 3 seconds to the driver ahead and crashes if attempts an overtake in Foggy weather.
        if (_driversByName.ElementAt(index - 1).Value.GetType().Name == "AgressiveDriver"
            && _driversByName.ElementAt(index - 1).Value.Car.Tyre.GetType().Name == "UltrasoftTyre"
            && currentWeather == "Foggy"
            && _driversByName.ElementAt(index - 1).Value.TotalTime - _driversByName.ElementAt(index - 2).Value.TotalTime <=
            3)
        {
            _failedDrivers.Add(Constants.CrashedFailureMessage, _driversByName.ElementAt(index).Value);
            _driversByName.Remove(_driversByName.ElementAt(index).Key);
            failureSucceed = true;
        }

        // EnduranceDriver on HardTyre has an overtake interval up to 3 seconds to the driver ahead and crashes if attempts an overtake in Rainy weather. 
        if (_driversByName.ElementAt(index - 1).Value.GetType().Name == "EnduranceDriver"
            && _driversByName.ElementAt(index - 1).Value.Car.Tyre.GetType().Name == "HardTyre"
            && currentWeather == "Rainy"
            && _driversByName.ElementAt(index - 1).Value.TotalTime - _driversByName.ElementAt(index - 2).Value.TotalTime <=
            3)
        {
            _failedDrivers.Add(Constants.CrashedFailureMessage, _driversByName.ElementAt(index).Value);
            _driversByName.Remove(_driversByName.ElementAt(index).Key);
            failureSucceed = true;
        }

        return failureSucceed;
    }

    public string GetLeaderboard()
    {
        return new StringBuilder()
            .AppendLine(string.Format(Constants.LeaderBoardMessage, currentLapsNum, Laps))
            .Append(PrintAllDrivers()).ToString();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        var weather = commandArgs[0];
        this.currentWeather = weather;
    }

    private string PrintAllDrivers()
    {
        StringBuilder result = new StringBuilder();

        int position = 0;
        foreach (var driver in _driversByName.OrderByDescending(x => x.Value.TotalTime))
        {
            position++;
            result.AppendLine($"{position} {driver.Value.Name} {driver.Value.TotalTime}");
        }

        position = 0;
        foreach (var driver in _failedDrivers.OrderByDescending(x => x.Value.TotalTime))
        {
            position++;
            result.AppendLine($"{position} {driver.Value.Name} {driver.Key}");
        }

        return result.ToString();
    }

    public void FinishGame()
    {
        Console.WriteLine($"{_driversByName.First().Value.Name} wins the race for {_driversByName.First().Value.TotalTime:f3} seconds.");
    }
}