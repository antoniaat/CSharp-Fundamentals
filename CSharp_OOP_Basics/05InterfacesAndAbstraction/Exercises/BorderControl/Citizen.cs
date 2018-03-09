public class Citizen :IIdentable, IBuyer
{
    public Citizen(string name, int age, string id, string birthday)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthday = birthday;
    }

    public string Name { get; set; }

    public int Age { get; set; }

    public string Id { get; set; }

    public string Birthday { get; }

    public void BuyFood()
    {

    }

    public int Food { get; set; }
}

