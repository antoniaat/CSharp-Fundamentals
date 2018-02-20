using System;
using System.Collections.Generic;

internal class OpinionPoll
{
    private List<Person> peopleList;

    public OpinionPoll()
    {
        this.PeopleList = new List<Person>();
    }

    public List<Person> PeopleList
    {
        get => this.peopleList;
        set
        {
            if (value != null)
            {
                this.peopleList = value;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }

    public void AddMember(Person member)
    {
        if (member.Age > 30) peopleList.Add(member);
    }
}