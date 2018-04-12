using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Stack<T> : IEnumerable<T>
where T : struct
{
    public const int InitialCapacity = 4;

    private T[] data;

    public Stack()
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

    public void Push(T element)
    {
        if (this.Count == this.data.Length)
        {
            this.Resize();
        }

        this.data[this.Count++] = element;
    }

    public void Pop()
    {
        if (this.data.Length == 0)
        {
            throw new Exception($"No elements");
        }

        this.data = this.data.Take(this.data.Count() - 1).ToArray();
        this.Count--;
    }

    public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)this.data).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}