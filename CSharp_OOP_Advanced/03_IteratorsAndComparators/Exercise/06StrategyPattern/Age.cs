using System.Collections.Generic;

public class Age : IComparer<Person>
{
    public int Compare(Person firstPerson, Person secondPerson)
    {
        int result = firstPerson.Age
            .CompareTo(secondPerson.Age);

        return result;
    }
}
