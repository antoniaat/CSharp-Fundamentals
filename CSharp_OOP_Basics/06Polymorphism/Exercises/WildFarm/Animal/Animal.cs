public abstract class Animal
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public int FoodEaten { get; set; }

    protected Animal(string name, double weight, int foodEaten)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = foodEaten;
    }

    public abstract void Eat(Food food);

    public abstract void ProduceSound();
}