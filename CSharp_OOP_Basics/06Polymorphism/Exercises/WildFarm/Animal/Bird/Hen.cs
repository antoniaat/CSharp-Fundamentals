using System;

public class Hen : Bird
{
    public Hen(string name, double weight, int foodEaten, double wingSize)
        : base(name, weight, foodEaten, wingSize) { }

    public override void Eat(Food food)
    {
        this.Weight += food.Quantity * 0.35;
        this.FoodEaten += food.Quantity;
    }

    public override void ProduceSound()
    {
        Console.WriteLine("Cluck");
    }
}