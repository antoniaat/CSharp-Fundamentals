public class Rebel : IBuyer 
{
    private string name;
    private int age;
    private string group;

    public Rebel(string name, int age, string group)
    {
        this.Name = name;
        this.Age = age;
        this.Group = group;
    }

    public string Name { get; set; }

    public int Age{ get; set; }

    public string Group{ get; set; }

    public void BuyFood()
    {
        
    }

    public int Food { get; set; }
}
