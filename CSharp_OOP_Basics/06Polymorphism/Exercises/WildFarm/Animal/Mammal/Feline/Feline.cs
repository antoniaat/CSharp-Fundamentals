public abstract class Feline : Mammal
{
    public string Breed { get; set; }

    protected Feline(string name, double weight, int foodEaten, string livingRegion, string breed)
        : base(name, weight, foodEaten, livingRegion)
    {
        this.Breed = breed;
    }

    public override string ToString()
    {
        return $"{GetType()} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}