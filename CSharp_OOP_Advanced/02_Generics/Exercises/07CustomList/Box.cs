using System;
using System.Linq;
using System.Text;

public class Box<T>
    where T : IComparable<T>
{
    private const int InitialCapacity = 4;

    private T[] data;

    public Box()
    {
        this.data = new T[InitialCapacity];
    }

    private void Resize()
    {
        T[] newData = new T[this.data.Length * 2];

        for (int i = 0; i < this.data.Length; i++)
        {
            newData[i] = this.data[i];
        }

        this.data = newData;
    }

    public int Count { get; private set; }

    public void Add(T element)
    {
        if (this.Count == this.data.Length)
        {
            this.Resize();
        }

        this.data[this.Count++] = element;
    }

    public void Remove(T element)
    {
        this.data[--this.Count] = element;
    }

    public T Max()
    {
        return this.data.Max();
    }

    public T Min()
    {
        return this.data.Min();
    }

    public bool Contain(T element)
    {
        return data.Contains(element);
    }

    public void Swap(int firstIndex, int secondIndex)
    {
        var firstElement = this.data[firstIndex];
        data[firstIndex] = data[secondIndex];
        data[secondIndex] = firstElement;
    }

    public int CountGreaterThan(T item)
    {
        var counter = 0;

        foreach (var element in data)
        {
            if (item.CompareTo(element) < 0)
            {
                counter++;
            }
        }

        return counter;
    }

    public void Sort()
    {
        Array.Sort(this.data, 0, this.Count);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        foreach (var element in this.data)
        {
            sb.AppendLine($"{element}");
        }

        return sb.ToString().Trim();
    }
}