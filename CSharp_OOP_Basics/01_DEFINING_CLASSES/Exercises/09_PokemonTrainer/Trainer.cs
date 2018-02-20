using System.Collections.Generic;

public class Trainer
{
    private string name;
    private int badges;
    private List<Pokemon> pokemons;

    public Trainer(string name, int badges, List<Pokemon> pokemons)
    {
        this.Name = name;
        this.Badges = badges;
        this.Pokemons = pokemons;
    }

    public string Name { get; set; }
    public int Badges { get; set; }
    public List<Pokemon> Pokemons = new List<Pokemon>();
}
