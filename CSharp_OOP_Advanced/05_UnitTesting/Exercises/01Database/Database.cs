using System;

public class Database
{
    public int CurrentIndex;

    public const int MaxCapacity = 16;

    private int[] data = new int[MaxCapacity];

    public Database(params int[] args)
    {
        this.Data = data;

        foreach (var num in args)
        {
            this.Add(num);
        }
    }

    public int[] Data { get; set; }

    public int Count { get; set; }

    public void Add(int number)
    {
        if (CurrentIndex == MaxCapacity - 1)
        {
            throw new InvalidOperationException();
        }

        this.Data[CurrentIndex++] = number;
    }

    public void Remove()
    {
        if (this.Data.Length == 0)
        {
            throw new InvalidOperationException("Database it's empty!");
        }

        this.Data[--CurrentIndex] = 0;
    }

    public int[] Fetch()
    {
        int[] arrayToReturn = new int[CurrentIndex];

        for (int index = 0; index < CurrentIndex; index++)
        {
            arrayToReturn[index] = this.Data[index];
        }

        return arrayToReturn;
    }
}
