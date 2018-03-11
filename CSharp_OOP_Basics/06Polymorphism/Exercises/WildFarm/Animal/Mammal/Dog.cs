using System;

public class Dog : Mammal
{
    public Dog(string name, double weight, int foodEaten, string livingRegion)
        : base(name, weight, foodEaten, livingRegion) { }

    public override void ProduceSound()
    {
        Console.WriteLine("Woof!");
    }

    public override void Eat(Food food)
    {
        if (food.GetType().Name != "Meat")
        {
            throw new ArgumentException($"{base.GetType()} does not eat {food}!");
        }

        base.Weight += food.Quantity * 0.4;
        this.FoodEaten += food.Quantity;
    }
}