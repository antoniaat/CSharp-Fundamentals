using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

internal class Person
{
    private string name;
    private Company company;
    private Car car;
    private List<Pokemon> pokemons;
    private List<Relative> parents;
    private List<Relative> children;

    public Person(string name)
    {
        this.Pokemons = new List<Pokemon>();
        this.Parents = new List<Relative>();
        this.Children = new List<Relative>();
        this.Name = name;
    }

    public string Name { get; set; }
    public Company Company { get; set; }
    public Car Car { get; set; }
    public List<Pokemon> Pokemons { get; set; }
    public List<Relative> Parents { get; set; }
    public List<Relative> Children { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(this.Name);

        sb.AppendLine("Company:");
        if (this.Company != null)
        {
            sb.AppendLine(this.Company.ToString());
        }

        sb.AppendLine("Car:");
        if (this.Car != null)
        {
            sb.AppendLine(this.Car.ToString());
        }

        sb.AppendLine("Pokemon:");
        if (this.Pokemons.Count > 0)
        {
            sb.AppendLine(string.Join(Environment.NewLine, this.Pokemons));
        }

        sb.AppendLine("Parents:");
        if (this.Parents.Count > 0)
        {
            sb.AppendLine(string.Join(Environment.NewLine, this.Parents.Select(par => par.ToString())));
        }

        sb.AppendLine("Children:");
        if (this.Children.Count > 0)
        {
            sb.AppendLine(string.Join(Environment.NewLine, this.Children.Select(c => c.ToString())));
        }

        return sb.ToString();
    }
}