using System;

public class Person
{
    private long id;

    public Person(long id, string username)
    {
        this.Id = id;
        this.Username = username;
    }

    public long Id
    {
        get => this.id;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException($"ID can't be negative number.");
            }

            this.id = value;
        }
    }

    public string Username { get; set; }

    public override string ToString()
    {
        return $"Username : {this.Username} , ID: {this.Id}";
    }
}
