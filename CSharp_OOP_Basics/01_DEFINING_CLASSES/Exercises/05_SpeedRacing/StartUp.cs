using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            CreateCars(cars);
        }

        string travel;
        while ((travel = Console.ReadLine()) != "End")
        {
            var tokens = travel.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var carModel = tokens[1];
            var amountOfKm = int.Parse(tokens[2]);
            Travel(carModel, amountOfKm, cars);
        }

        cars.ForEach(Console.WriteLine);
    }

    public static void CreateCars(List<Car> cars)
    {
        var currentLine = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var model = currentLine[0];
        var fuelAmount = int.Parse(currentLine[1]);
        var distanceTraveled = double.Parse(currentLine[2]);

        var car = new Car(model, fuelAmount, distanceTraveled);
        cars.Add(car);
    }

    public static void Travel(string carModel, double amountOfKm, List<Car> cars)
    {
        foreach (Car car in cars)
        {
            if (car.Model == carModel)
            {
                var distance = car.Consumption * amountOfKm;

                if (distance <= car.Amount)
                {
                    car.Distance += amountOfKm;
                    car.Amount -= distance;
                }
                else
                {
                    Console.WriteLine($"Insufficient fuel for the drive");
                }
            }
        }
    }
}