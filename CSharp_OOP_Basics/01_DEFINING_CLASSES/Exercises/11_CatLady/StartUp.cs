using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var cats = new List<Cat>();

        string inputLine;
        while ((inputLine = Console.ReadLine()) != "End")
        {
            var tokens = inputLine.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var type = tokens[0];
            var name = tokens[1];
            var characteristic = double.Parse(tokens[2]);

            cats.Add(new Cat(name, type, characteristic));
        }

        var nameOfCat = Console.ReadLine();
        var cat = cats.First(x => x.Name == nameOfCat);

        Console.WriteLine(cat.Type == "Cymric"
            ? $"{cat.Type} {cat.Name} {cat.Characteristic:f2}"
            : $"{cat.Type} {cat.Name} {cat.Characteristic}");
    }
}
