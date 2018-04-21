using System;
using System.Collections.Generic;
using System.Linq;

public class Database
{
    private List<Person> peopleData = new List<Person>();

    public Database()
    {
        this.PeopleData = peopleData;
    }

    public List<Person> PeopleData { get; set; }

    public void Add(Person person)
    {
        // Validation if person with that username or id already exist
        if (peopleData.Count(x => x.Username == person.Username) > 0
            || peopleData.Count(x => x.Id == person.Id) > 0)
        {
            throw new InvalidOperationException("Person already exists!");
        }

        peopleData.Add(person);
    }

    public void Remove()
    {
        if (peopleData.Count == 0)
        {
            throw new InvalidOperationException("People database it's empty!");
        }

        peopleData.RemoveAt(peopleData.Count - 1);
    }

    public string[] Fetch()
    {
        var returnedPeopleDatabase = new string[peopleData.Count];

        for (int index = 0; index < peopleData.Count; index++)
        {
            returnedPeopleDatabase[index] = peopleData[index].ToString();
        }

        return returnedPeopleDatabase;
    }

    public Person FindByUsername(string username)
    {
        if (username == null)
        {
            throw new ArgumentNullException($"Need to write username.");
        }

        Person person = peopleData
            .FirstOrDefault(x => x.Username == username);

        if (person == null)
        {
            throw new InvalidOperationException($"No user is present by this username.");
        }

        return person;
    }

    public Person FindById(long id)
    {
        if (id == null)
        {
            throw new ArgumentNullException($"Need to enter user ID.");
        }

        Person person = peopleData
            .FirstOrDefault(x => x.Id == id);

        if (person == null)
        {
            throw new InvalidOperationException($"No user is present by this ID.");
        }

        return person;
    }
}
