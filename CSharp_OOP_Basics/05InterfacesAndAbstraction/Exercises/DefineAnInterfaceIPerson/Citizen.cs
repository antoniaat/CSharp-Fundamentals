using DefineAnInterfaceIPerson.Interfaces;

namespace DefineAnInterfaceIPerson
{
    public class Citizen : IPerson, IBirthable, IIdentifiable
    {
        public Citizen(string name, int age, string birthdate, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
            this.Id = id;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Birthdate { get; }
        public string Id { get; }
    }
}
