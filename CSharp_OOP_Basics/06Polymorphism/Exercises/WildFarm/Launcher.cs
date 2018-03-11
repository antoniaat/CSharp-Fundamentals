using System;
using System.Collections.Generic;
using System.Linq;

public class Launcher
{
    public static void Main()
    {
        var animals = new List<Animal>();

        int counter = 0;
        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            if (counter % 2 == 0) //even line
            {
                ReadEvenLines(command, animals); // Read And Create Animals
            }
            else // odd line
            {
                ReadOddLines(command, animals); // Feed Animals
            }
            counter++;
        }

        PrintAnimals(animals);
    }

    private static void PrintAnimals(List<Animal> animals)
    {
        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }

    private static void ReadEvenLines(string command, List<Animal> animals)
    {
        var tokens = command
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var type = tokens[0];
        var name = tokens[1];
        var weight = double.Parse(tokens[2]);

        if (type == "Cat" || type == "Tiger") // Felines
        {
            var animal = FelinesAnimals(name, weight, tokens, type);
            animals.Add(animal);
            animal.ProduceSound();
        }
        else if (type == "Hen" || type == "Owl") // Birds
        {
            var animal = Birds(name, weight, tokens, type);
            animals.Add(animal);
            animal.ProduceSound();
        }
        else if (type == "Mouse" || type == "Dog") // Birds
        {
            var animal = Mammals(name, weight, tokens, type);
            animals.Add(animal);
            animal.ProduceSound();
        }
    }

    private static Animal Mammals(string name, double weight, string[] tokens, string type)
    {
        var livingRegion = tokens[3];

        if (type == "Mouse") return new Mouse(name, weight, 0, livingRegion);

        if (type == "Dog") return new Dog(name, weight, 0, livingRegion);

        throw new ArgumentException("Invalid type!");
    }

    private static Animal Birds(string name, double weight, string[] tokens, string type)
    {
        var wingSize = double.Parse(tokens[3]);

        if (type == "Hen") return new Hen(name, weight, 0, wingSize);

        if (type == "Owl") return new Owl(name, weight, 0, wingSize);

        throw new ArgumentException("Invalid type!");
    }

    private static Animal FelinesAnimals(string name, double weight, string[] tokens, string type)
    {
        var livingRegion = tokens[3];
        var breed = tokens[4];

        if (type == "Cat") return new Cat(name, weight, 0, livingRegion, breed);

        if (type == "Tiger") return new Tiger(name, weight, 0, livingRegion, breed);

        throw new ArgumentException("Invalid type!");
    }

    private static void ReadOddLines(string command, List<Animal> animals) // Feed Animals
    {
        var foodTokens = command
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var food = SetFood(foodTokens);

        var animal = animals.Last();

        try
        {
            animal.Eat(food);
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private static Food SetFood(string[] foodTokens)
    {
        var foodType = foodTokens[0];
        var quantity = int.Parse(foodTokens[1]);

        if (foodType == "Vegetable") return new Vegetable(quantity);

        if (foodType == "Meat") return new Meat(quantity);

        if (foodType == "Fruit") return new Fruit(quantity);

        if (foodType == "Seed") return new Fruit(quantity);

        return null;
    }
}