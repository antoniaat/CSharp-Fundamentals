using System;
using System.Collections.Generic;

public class Launcher
{
    public static void Main()
    {
        var toppings = new List<Topping>();

        var pizzaTokens = Console.ReadLine()
            .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        var pizza = new Pizza(pizzaTokens[1]);

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            if (tokens[0] == "Dough")
            {
                ReadDough(pizza, tokens);
            }

            else if (tokens[0] == "Topping")
            {
                ReadTopping(tokens, toppings);
            }
        }

        pizza.Toppings = toppings;
    }

    private static void ReadDough(Pizza pizza, string[] tokens)
    {
        try
        {
            pizza.Dough = new Dough(tokens[1].ToLower(), tokens[2].ToLower(), double.Parse(tokens[3]));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            Environment.Exit(0);
        }
    }

    private static void ReadTopping(string[] tokens, List<Topping> toppings)
    {
        try
        {
            var topping = new Topping(tokens[1], double.Parse(tokens[2]));
            toppings.Add(topping);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            Environment.Exit(0);
        }

        if (toppings.Count > 10)
        {
            Console.WriteLine($"Number of toppings should be in range [0..10].");
            Environment.Exit(0);
        }
    }
}