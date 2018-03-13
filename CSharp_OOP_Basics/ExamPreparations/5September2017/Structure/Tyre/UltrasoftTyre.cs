using System;

public class UltrasoftTyre : Tyre
{
    private double grip;
    private double degradation;

    public UltrasoftTyre(string name, double hardness, double grip)
        : base(name, hardness)
    {
        this.Grip = grip;
        this.Name = "Ultrasoft";
    }

    public override double Degradation
    {
        get => this.degradation;
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Degradation drops can not be below 30 points.");
            }

            this.degradation = value;
        }
    }

    public double Grip
    {
        get => this.grip;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Cannot be less than 0.");
            }
            this.grip = value;
        }
    }
}