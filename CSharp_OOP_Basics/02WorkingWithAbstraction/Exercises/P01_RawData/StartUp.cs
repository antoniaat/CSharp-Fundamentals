using System;
using System.Collections.Generic;
using System.Linq;

public class RawData
{
    public static void Main()
    {
        var cars = new List<Car>();
        var inputLines = int.Parse(Console.ReadLine());

        ReadInputLines(cars, inputLines);
        PrintCarWithCommandType(cars);
    }

    private static void PrintCarWithCommandType(List<Car> cars)
    {
        string command = Console.ReadLine()?.Trim();

        if (command == "fragile")
        {
            var fragile = cars
                .Where(x => x.CargoType == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                .Select(x => x.Model)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, fragile));
        }

        else
        {
            var flamable = cars
                .Where(x => x.CargoType == "flamable" && x.EnginePower > 250)
                .Select(x => x.Model)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, flamable));
        }
    }

    private static void ReadInputLines(List<Car> cars, int inputLines)
    {
        for (int line = 0; line < inputLines; line++)
        {
            var parameters = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var model = parameters[0];
            var engineSpeed = int.Parse(parameters[1]);
            var enginePower = int.Parse(parameters[2]);
            var cargoWeight = int.Parse(parameters[3]);
            var cargoType = parameters[4];

            var car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, null);

            FillTires(car, parameters);

            cars.Add(car);
        }
    }

    private static void FillTires(Car car, string[] parameters)
    {
        for (int index = 5; index < 13; index += 2) // Row lenght is always 13.
        {
            var pressure = double.Parse(parameters[index]);
            var age = int.Parse(parameters[index + 1]);

            var tire = new Tire(pressure, age);
            car.Tires.Add(tire);
        }
    }
}
