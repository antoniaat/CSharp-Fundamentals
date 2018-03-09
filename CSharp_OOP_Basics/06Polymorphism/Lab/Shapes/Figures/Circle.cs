using System;

public class Circle : Shape
{
    public double Radius { get; protected set; }

    public Circle(double radius)
    {
        this.Radius = radius;
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * this.Radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * (Math.Pow(this.Radius, 2));
    }
}
