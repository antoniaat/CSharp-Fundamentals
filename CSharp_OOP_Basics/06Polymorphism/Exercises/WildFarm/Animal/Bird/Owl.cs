using System;

public class Owl : Bird
{
    public Owl(string name, double weight, int foodEaten, double wingSize)
        : base(name, weight, foodEaten, wingSize) { }

    public override void Eat(Food food)
    {
        if (food.GetType().Name != "Meat")
        {
            throw new ArgumentException($"{base.GetType()} does not eat {food}!");
        }

        base.Weight += food.Quantity * 0.25;
        this.FoodEaten += food.Quantity;
    }

    public override void ProduceSound()
    {
        Console.WriteLine("Hoot Hoot");
    }
}