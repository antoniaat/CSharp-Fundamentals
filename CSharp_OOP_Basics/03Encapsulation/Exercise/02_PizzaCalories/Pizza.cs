using System.Collections.Generic;
using System.Linq;

internal class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings = new List<Topping>();

    public Pizza(string name)
    {
        this.Name = name;
    }

    public Pizza(string name, Dough dough, List<Topping> toppings) : this(name)
    {
        this.Dough = dough;
        this.Toppings = toppings;
    }

    public double CalcucateCalories()
    {
        var totalCalories = this.Dough.CalculateCalories();
        totalCalories += this.Toppings.Select(x => x.CalculateCalories()).Sum();
        return totalCalories;
    }

    public string Name { get; set; }
    public Dough Dough { get; set; }
    public List<Topping> Toppings { get; set; }

    public override string ToString()
    {
        return $"{this.Name} - {CalcucateCalories():f2} Calories.";
    }
}