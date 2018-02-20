using System.Collections.Generic;
using System.Linq;

internal class Family
{
    private List<Person> people;

    public List<Person> People { get; set; }

    public Family()
    {
        this.people = new List<Person>();
    }

    public void AddMember(Person member)
    {
        people.Add(member);
    }

    public Person GetOldestMember()
    {
        return this.people
            .OrderByDescending(m => m.Age)
            .FirstOrDefault();
    }
}