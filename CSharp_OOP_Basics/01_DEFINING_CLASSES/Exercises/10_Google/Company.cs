internal class Company
{
    private string name;
    private string department;
    private double salary;

    public Company(string name, string department, double salary)
    {
        this.Name = name;
        this.Department = department;
        this.Salary = salary;
    }

    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }

    public override string ToString()
    {
        return
            $"{this.Name} {this.Department} {this.Salary:f2}";
    }
}