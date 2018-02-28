using System.Collections.Generic;

public class StackOfStrings
{
    private List<string> data = new List<string>();

    public void Push(string item)
    {
        data.Add(item);
    }

    public void Pop(string item)
    {
        data.RemoveAt(data.Count - 1);
    }

    public string Peek(string item)
    {
        return data[data.Count - 1];
    }

    public bool IsEmpty()
    {
        var isEmpty = data.Count == 0;
        return isEmpty;
    }

    public List<string> Data { get; set; }
}
