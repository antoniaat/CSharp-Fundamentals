public abstract class Bird : Animal
{
    protected Bird(string name, double weight, int foodEaten, double wingSize)
        : base(name, weight, foodEaten)
    {
        this.WingSize = wingSize;
    }

    public double WingSize { get; set; }

    public override string ToString()
    {
        return $"{GetType()} [{this.Name}, {this.WingSize}, {this.Weight}, {FoodEaten}]";
    }
}