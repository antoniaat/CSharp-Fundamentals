using System;

public class Launcher
{
    public static void Main()
    {
        var car = ReadAndCreateCar();
        var truck = ReadAndCreateTruck();
        var bus = ReadAndCreateBus();

        var n = int.Parse(Console.ReadLine()); // Number of commands
        MoveVehicles(n, car, truck, bus);

        PrintVehicles(car, truck, bus);
    }

    private static void PrintVehicles(Car car, Truck truck, Bus bus)
    {
        Console.WriteLine($"Car: {car.FuelQuantity:f2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
    }

    private static void MoveVehicles(int n, Car car, Truck truck, Bus bus)
    {
        for (int counter = 0; counter < n; counter++)
        {
            var command = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (command[0] == "Drive" || command[0] == "DriveEmpty")
            {
                DriveVehicle(command, car, truck, bus);
            }
            else if (command[0] == "Refuel")
            {
                RefuelVehicle(command, car, truck, bus);
            }
        }
    }

    private static void RefuelVehicle(string[] command, Car car, Truck truck, Bus bus)
    {
        try
        {
            if (command[1] == "Car")
            {
                var fuel = double.Parse(command[2]);
                car.Refueled(fuel);
            }
            else if (command[1] == "Truck")
            {
                var fuel = double.Parse(command[2]);
                truck.Refueled(fuel);
            }
            else if (command[1] == "Bus")
            {
                var fuel = double.Parse(command[2]);
                bus.Refueled(fuel);
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void DriveVehicle(string[] command, Car car, Truck truck, Bus bus)
    {
        try
        {
            switch (command[1])
            {
                case "Car":
                    {
                        var distance = double.Parse(command[2]);
                        Console.WriteLine(car.Driven(distance));
                        break;
                    }
                case "Truck":
                    {
                        var distance = double.Parse(command[2]);
                        Console.WriteLine(truck.Driven(distance));
                        break;
                    }
                case "Bus":
                    {
                        if (command[0] == "DriveEmpty")
                        {
                            var distance = double.Parse(command[2]);
                            Console.WriteLine(bus.DrivenEmpty(distance));
                        }
                        else
                        {
                            var distance = double.Parse(command[2]);
                            Console.WriteLine(bus.Driven(distance));
                        }
                        break;
                    }
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static Truck ReadAndCreateTruck()
    {
        // Information about truck
        var informationForTruck = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var truckFuelQuantity = double.Parse(informationForTruck[1]);
        var truckLitersPerKm = double.Parse(informationForTruck[2]);
        var capacity = double.Parse(informationForTruck[3]);

        return new Truck(truckFuelQuantity, truckLitersPerKm, capacity);
    }

    private static Car ReadAndCreateCar()
    {
        // Information about car
        var informationForCar = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var carFuelQuantity = double.Parse(informationForCar[1]);
        var carLitersPerKm = double.Parse(informationForCar[2]);
        var capacity = double.Parse(informationForCar[3]);

        return new Car(carFuelQuantity, carLitersPerKm, capacity);
    }

    private static Bus ReadAndCreateBus()
    {
        // Information about bus
        var informationForBus = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var busFuelQuantity = double.Parse(informationForBus[1]);
        var busLitersPerKm = double.Parse(informationForBus[2]);
        var capacity = double.Parse(informationForBus[3]);

        return new Bus(busFuelQuantity, busLitersPerKm, capacity);
    }
}