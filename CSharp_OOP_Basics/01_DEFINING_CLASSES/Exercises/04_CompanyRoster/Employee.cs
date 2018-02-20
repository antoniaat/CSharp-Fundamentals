public class Employee
{
    private string name;
    private decimal salary;
    private string position;
    private string department;
    private string email;
    private int age;

    public Employee(string name, decimal salary, string position, string department)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
    }

    public Employee(string name, decimal salary, string position, string department, string email)
        : this(name, salary, position, department)
    {
        this.Email = email;
    }

    public Employee(string name, decimal salary, string position, string department, int age)
        : this(name, salary, position, department)
    {
        this.Age = age;
    }

    public Employee(string name, decimal salary, string position, string department, string email, int age)
        : this(name, salary, position, department)
    {
        this.Email = email;
        this.Age = age;
    }

    public Employee(string name, decimal salary, string position, string department, int age, string email)
        : this(name, salary, position, department, email, age)
    {
    }

    public string Name { get; set; }

    public decimal Salary { get; set; }

    public string Position { get; set; }

    public string Department { get; set; }

    public string Email { get; set; }

    public int Age { get; set; }

    public override string ToString()
    {
        return $"{this.Name} {this.Salary:f2} {this.Email} {this.Age}";
    }
}