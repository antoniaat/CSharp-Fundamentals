using System.Collections.Generic;
using System.Text;

public class Box<T>
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

    public void Swap(int firstIndex, int secondIndex)
    {
        var firstValue = data[firstIndex];
        var secondValue = data[secondIndex];

        data[firstIndex] = secondValue;
        data[secondIndex] = firstValue;
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
}