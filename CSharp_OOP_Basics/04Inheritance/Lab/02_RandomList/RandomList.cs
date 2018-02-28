using System;
using System.Collections.Generic;

public class RandomList : List<string>
{
    private readonly Random rnd = new Random();
    private List<string> data;

    public RandomList()
    {
        this.Rnd = new Random();
        this.Data = data;
    }

    public Random Rnd { get; set; }
    public List<string> Data{ get; set; }

    public object RemoveRandomElement()
    {
        var index = rnd.Next(0, data.Count - 1);
        var str = data[index];
        data.RemoveAt(index);
        return str;
    }
}
