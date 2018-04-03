using System;
using System.Collections.Generic;
using System.Text;

public class Box<T> : IComparable
{
    private readonly List<T> data;

    public Box()
    {
        this.data = new List<T>();
    }

    public void Add(T item)
    {
        this.data.Add(item);
    }

    public override string ToString()
    {
        var result = new StringBuilder();

        foreach (var item in data)
        {
            result.AppendLine($"{item.GetType().FullName}: {item}");
        }

        return result.ToString();
    }

    public int CompareTo(object element)
    {
        int count = 0;

        foreach (var item in data)
        {
            if (item.ToString().CompareTo(element) > 0)
            {
                count++;
            }
        }

        return count;
    }
}