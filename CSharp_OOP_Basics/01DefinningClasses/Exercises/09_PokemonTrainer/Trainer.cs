using System.Collections.Generic;

public class Trainer
{
    private string name;
    private int badges;

    public Trainer(string name, int badges)
    {
        this.Name = name;
        this.Badges = badges;
        this.Pokemons = new List<Pokemon>();
    }

    public string Name { get; set; }
    public int Badges { get; set; }
    public List<Pokemon> Pokemons { get; set; }
}