using System.Collections.Generic;

internal class Person
{
    public Person()
    {
        this.Children = new List<Person>();
        this.Parents = new List<Person>();
    }

    public string Name { get; set; }
    public string Birthday { get; set; }
    public List<Person> Parents { get; set; }
    public List<Person> Children { get; set; }

    public static Person CreatePerson(string personInput)
    {
        var person = new Person();

        if (IsBirthday(personInput)) person.Birthday = personInput;
            
        else person.Name = personInput;

        return person;
    }

    private static bool IsBirthday(string input)
    {
        return char.IsDigit(input[0]);
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Birthday}";
    }
}
