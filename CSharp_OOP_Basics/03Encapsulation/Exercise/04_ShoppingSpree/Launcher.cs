using System;
using System.Collections.Generic;
using System.Linq;

public class Launcher
{
    public static void Main()
    {
        var people = new List<Person>();
        var products = new List<Product>();

        ReadPeople(people);
        ReadProducts(products);
        Shopping(people, products);
        PrintPeople(people);
    }

    private static void Shopping(List<Person> people, List<Product> products)
    {
        string buyProduct;
        while ((buyProduct = Console.ReadLine()) != "END")
        {
            var tokens = buyProduct
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var name = tokens[0];
            var product = tokens[1];

            BuyProduct(name, product, people, products);
        }
    }

    private static void PrintPeople(List<Person> people)
    {
        foreach (var person in people)
        {
            if (person.Bag.Count == 0)
            {
                Console.WriteLine($"{person}Nothing bought");
            }
            else
            {
                Console.WriteLine(person);
            }
        }
    }

    private static void BuyProduct(string name, string product, List<Person> people, List<Product> products)
    {
        foreach (var person in people)
        {
            if (person.Name == name)
            {
                foreach (var pr in products)
                {
                    if (pr.Name == product)
                    {
                        if (person.Money >= pr.Cost)
                        {
                            Console.WriteLine($"{person.Name} bought {pr.Name}");
                            person.Bag.Add(pr);
                            person.Money -= pr.Cost;
                            return;
                        }

                        Console.WriteLine($"{person.Name} can't afford {pr.Name}");
                        return;
                    }
                }
            }
        }
    }

    private static void ReadProducts(List<Product> products)
    {
        var productsTokens = Console.ReadLine()
            .Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        for (int i = 0; i < productsTokens.Length; i += 2)
        {
            try
            {
                var product = new Product(productsTokens[i], decimal.Parse(productsTokens[i + 1]));
                products.Add(product);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }
    }

    private static void ReadPeople(List<Person> people)
    {
        var peopleTokens = Console.ReadLine()
            .Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        for (int i = 0; i < peopleTokens.Length; i += 2)
        {
            try
            {
                var person = new Person(peopleTokens[i], decimal.Parse(peopleTokens[i + 1]));
                people.Add(person);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }
    }
}