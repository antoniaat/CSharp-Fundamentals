using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var cars = new List<Car>();

        for (var i = 0; i < n; i++)
        {
            var currentCar = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var name = currentCar[0];
            var engineSpeed = int.Parse(currentCar[1]);
            var enginePower = int.Parse(currentCar[2]);
            var cargoWeight = int.Parse(currentCar[3]);
            var cargoType = currentCar[4];
            var tires = new Tire[4];
            var index = 0;

            for (var j = 5; j < currentCar.Length; j += 2, index++)
            {
                var tire1Pressure = double.Parse(currentCar[j]);
                var tire1Age = int.Parse(currentCar[j + 1]);
                tires[index] = new Tire(tire1Pressure, tire1Age);
            }

            var engine = new Engine(engineSpeed, enginePower);
            var cargo = new Cargo(cargoType, cargoWeight);

            var car = new Car(name, engine, cargo, tires);
            cars.Add(car);
        }

        var type = Console.ReadLine();

        if (type == "fragile")
        {
            cars
                .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                .ToList()
                .ForEach(x =>
                {
                    Console.WriteLine(x.Model);
                });
        }
        else if (type == "flamable")
        {
            cars
                .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                .ToList()
                .ForEach(x =>
                {
                    Console.WriteLine(x.Model);
                });
        }
    }
}