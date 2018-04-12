using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ListyIterator<T> : IEnumerator<T>, IEnumerable<string>
{
    public int CurrentIndex { get; set; }

    public List<string> List { get; set; }

    public void Create(string[] args)
    {
        this.List = new List<string>();

        for (int index = 1; index < args.Length; index++)
        {
            this.List.Add(args[index]);
        }
    }

    public bool MoveNext() => ++CurrentIndex < List.Count;

    public void Reset() => this.CurrentIndex = -1;

    public T Current { get; set; }

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }

    public bool HasNext() => CurrentIndex != List.Count - 1;

    public string Print()
    {
        if (this.List.Count == 0)
        {
            throw new Exception("Invalid Operation!");
        }

        if (CurrentIndex >= this.List.Count)
        {
            return this.List.Last();
        }

        return this.List[CurrentIndex];
    }

    public string PrintAll()
    {
        return new StringBuilder()
            .Append(string.Join(" ", this.List))
            .ToString();
    }

    public IEnumerator<string> GetEnumerator()
    {
        return ((IEnumerable<string>)this.List).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}