using System;

internal class Person
{
    private string name;
    private int age;

    public string Name { get; set; }
    public int Age { get; set; }

    public Person() : this("No name", 1)
    {
    }

    public Person(int age) : this("No name", age)
    {
    }

    public Person(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new NullReferenceException("Invalid name");
        }

        this.Name = name;
    }

    public Person(string name, int age) : this(name)
    {
        this.Age = age;
    }
}