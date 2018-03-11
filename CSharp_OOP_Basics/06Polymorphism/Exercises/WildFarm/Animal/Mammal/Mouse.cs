using System;

public class Mouse : Mammal
{
    public Mouse(string name, double weight, int foodEaten, string livingRegion)
        : base(name, weight, foodEaten, livingRegion) { }

    public override void ProduceSound()
    {
        Console.WriteLine("Squeak");
    }

    public override void Eat(Food food)
    {
        if (food.GetType().Name != "Vegetable" && food.GetType().Name != "Fruit")
        {
            throw new ArgumentException($"{base.GetType()} does not eat {food}!");
        }

        base.Weight += food.Quantity * 0.1;
        this.FoodEaten += food.Quantity;
    }
}