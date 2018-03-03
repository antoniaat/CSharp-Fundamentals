using System;
using System.Linq;

public class Human
{
    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string FirstName
    {
        get => this.firstName;
        set
        {
            if (!char.IsUpper(value.First()))
            {
                throw new ArgumentException($"Expected upper case letter!Argument: {value}");
            }
            if (value.Length < 3)
            {
                throw new ArgumentException($"Expected length at least 4 symbols!Argument: {value}");
            }
            this.firstName = value;
        }
    }

    public string LastName
    {
        get => this.lastName;
        set
        {
            if (!char.IsUpper(value.First()))
            {
                throw new ArgumentException($"Expected upper case letter!Argument: {value}");
            }
            if (value.Length < 2)
            {
                throw new ArgumentException($"Expected length at least 3 symbols!Argument: {value}");
            }
            this.lastName = value;
        }
    }
}