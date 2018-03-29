using System.Collections.Generic;
using System.Linq;

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

    public T Remove()
    {
        var rem = this.data.Last();
        this.data.RemoveAt(this.data.Count - 1);
        return rem;
    }

    public int Count => this.data.Count;
}

