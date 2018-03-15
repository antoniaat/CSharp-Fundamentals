using System;
using System.Collections.Generic;
using System.Linq;

public class Launcher
{
    public static void Main()
    {
        var raceTower = new RaceTower();
        var engine = new Engine(raceTower);
        engine.Run();

        //var list = new List<int> {4, 2, 3, 343, 41, -029, 22, 9};

        //list = list.OrderBy(x => x).ToList();

        //foreach (var num in list)
        //{
        //    Console.WriteLine(num);
        //}
    }
}
