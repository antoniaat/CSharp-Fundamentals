using System.Collections;
using System.Collections.Generic;

public class Lake<T> : IEnumerable<T>
    where T : struct
{
    public Lake(List<T> inputArgs)
    {
        this.Data = inputArgs;
    }

    public List<T> Data { get; set; }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Data.Count; i++)
        {
            if (i % 2 == 0)
            {
                yield return this.Data[i];
            }
        }

        var oddPositions = new List<T>();

        for (int i = 1; i < this.Data.Count; i++)
        {
            if (i % 2 != 0)
            {
                oddPositions.Add(this.Data[i]);
            }
        }

        oddPositions.Reverse();

        for (int i = 0; i < oddPositions.Count; i++)
        {
            yield return oddPositions[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}