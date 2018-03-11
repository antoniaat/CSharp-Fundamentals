using System;

public class Tiger : Feline
{
    public Tiger(string name, double weight, int foodEaten, string livingRegion, string breed)
        : base(name, weight, foodEaten, livingRegion, breed) { }

    public override void ProduceSound()
    {
        Console.WriteLine("ROAR!!!");
    }

    public override void Eat(Food food)
    {
        if (food.GetType().Name != "Meat")
        {
            throw new ArgumentException($"{base.GetType()} does not eat {food}!");
        }

        base.Weight += food.Quantity * 1;
        this.FoodEaten += food.Quantity;
    }
}