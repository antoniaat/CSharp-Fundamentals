using System.Collections.Generic;

public class Team
{
    private string name;
    private readonly List<Person> firstTeam;
    private readonly List<Person> reserveTeam;

    public Team(string name)
    {
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();
        this.Name = name;
    }

    public string Name { get; set; }
    public List<Person> FirstTeam => this.firstTeam;
    public List<Person> ReserveTeam => this.reserveTeam;

    public void AddPlayer(Person person)
    {
        if (person.Age < 40)
        {
            firstTeam.Add(person);
        }
        else
        {
            reserveTeam.Add(person);
        }
    }
}