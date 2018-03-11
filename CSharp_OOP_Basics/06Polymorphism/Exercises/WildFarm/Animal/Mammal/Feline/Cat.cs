using System;

public class Cat : Feline
{
    public Cat(string name, double weight, int foodEaten, string livingRegion, string breed)
        : base(name, weight, foodEaten, livingRegion, breed) { }

    public override void Eat(Food food)
    {
        if (food.GetType().Name != "Vegetable" && food.GetType().Name != "Meat")
        {
            throw new ArgumentException($"{base.GetType()} does not eat {food}!");
        }

        base.Weight += food.Quantity * 0.3;
        this.FoodEaten += food.Quantity;
    }

    public override void ProduceSound()
    {
        Console.WriteLine("Meow");
    }
}