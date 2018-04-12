using System.Collections.Generic;
using System.Linq;

public class Name : IComparer<Person>
{
    public int Compare(Person firstPerson, Person secondPerson)
    {
        int result = firstPerson.Name.Length
            .CompareTo(secondPerson.Name.Length);

        if (result == 0)
        {
            result = firstPerson.Name.ToLower().First()
                .CompareTo(secondPerson.Name.ToLower().First());
        }

        return result;
    }
}
