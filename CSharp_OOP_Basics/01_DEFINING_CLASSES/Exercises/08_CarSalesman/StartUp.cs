using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var cars = new List<Car>();
        var engines = new List<Engine>();

        for (int i = 0; i < n; i++)
        {
            AddEngines(engines);
        }

        var m = int.Parse(Console.ReadLine());

        for (int i = 0; i < m; i++)
        {
            AddCars(cars, engines);
        }

        CheckForEmptyFields(cars);
        PrintCars(cars);
    }

    private static void PrintCars(List<Car> cars)
    {
        foreach (var car in cars)
        {
            if (car.Weight == 0)
            {
                if (car.Engine.Displacement == 0)
                {
                    Console.WriteLine(
                        $"{car.Model}: \n  {car.Engine.Model}: \n    Power: {car.Engine.Power} \n    Displacement: n/a \n    Efficiency: {car.Engine.Efficiency} \n  Weight: n/a \n  Color: {car.Color}");
                    continue;
                }
                Console.WriteLine(
                    $"{car.Model}: \n  {car.Engine.Model}: \n    Power: {car.Engine.Power} \n    Displacement: {car.Engine.Displacement} \n    Efficiency: {car.Engine.Efficiency} \n  Weight: n/a \n  Color: {car.Color}");
                continue;
            }

            if (car.Engine.Displacement == 0)
            {
                if (car.Weight == 0)
                {
                    Console.WriteLine(
                        $"{car.Model}: \n  {car.Engine.Model}: \n    Power: {car.Engine.Power} \n    Displacement: n/a \n    Efficiency: {car.Engine.Efficiency} \n  Weight: n/a \n  Color: {car.Color}");
                    continue;
                }
                Console.WriteLine(
                    $"{car.Model}: \n  {car.Engine.Model}: \n    Power: {car.Engine.Power} \n    Displacement: n/a \n    Efficiency: {car.Engine.Efficiency} \n  Weight: {car.Weight} \n  Color: {car.Color}");
                continue;
            }

            Console.WriteLine(car);
        }
    }

    private static void CheckForEmptyFields(List<Car> cars)
    {
        foreach (var car in cars)
        {
            if (car.Color == null)
            {
                car.Color = "n/a";
            }
            if (car.Engine.Efficiency == null)
            {
                car.Engine.Efficiency = "n/a";
            }
        }
    }

    private static void AddCars(List<Car> cars, List<Engine> engines)
    {
        var currentCar = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var model = currentCar[0];
        var engine = currentCar[1];

        if (currentCar.Length == 2)
        {
            foreach (var eng in engines)
            {
                if (eng.Model == engine)
                {
                    cars.Add(new Car(model, eng));
                }
            }
        }

        if (currentCar.Length == 3)
        {
            if (Char.IsDigit(currentCar[2].First()))
            {
                var weight = currentCar[2];

                foreach (var eng in engines)
                {
                    if (eng.Model == engine)
                    {
                        cars.Add(new Car(model, eng, weight));
                    }
                }
            }
            else
            {
                var color = currentCar[2];

                foreach (var eng in engines)
                {
                    if (eng.Model == engine)
                    {
                        cars.Add(new Car(model, eng, color));
                    }
                }
            }
        }

        if (currentCar.Length == 4)
        {
            if (Char.IsDigit(currentCar[2].First()))
            {
                var weight = int.Parse(currentCar[2]);
                var color = currentCar[3];

                foreach (var eng in engines)
                {
                    if (eng.Model == engine)
                    {
                        cars.Add(new Car(model, eng, weight, color));
                    }
                }
            }
            else
            {
                var color = currentCar[2];
                var weight = int.Parse(currentCar[3]);

                foreach (var eng in engines)
                {
                    if (eng.Model == engine)
                    {
                        cars.Add(new Car(model, eng, color, weight));
                    }
                }
            }
        }
    }

    private static void AddEngines(List<Engine> engines)
    {
        var currentEngine = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var model = currentEngine[0];
        var power = int.Parse(currentEngine[1]);

        if (currentEngine.Length == 3)
        {
            if (Char.IsDigit(currentEngine[2].First()))
            {
                var displacement = int.Parse(currentEngine[2]);
                engines.Add(new Engine(model, power, displacement));
            }
            else
            {
                var efficiency = currentEngine[2];
                engines.Add(new Engine(model, power, efficiency));
            }
        }

        if (currentEngine.Length == 4)
        {
            if (Char.IsDigit(currentEngine[2].First()))
            {
                var displacement = int.Parse(currentEngine[2]);
                var efficiency = currentEngine[3];
                engines.Add(new Engine(model, power, displacement, efficiency));
            }
            else
            {
                var efficiency = currentEngine[2];
                var displacement = int.Parse(currentEngine[3]);
                engines.Add(new Engine(model, power, efficiency, displacement));
            }
        }

        if (currentEngine.Length == 2)
        {
            engines.Add(new Engine(model, power));
        }
    }
}