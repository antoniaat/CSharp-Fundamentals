using System;

public class UltrasoftTyre : Tyre
{
    public UltrasoftTyre(double hardness, double grip)
        : base("Ultrasoft", hardness)
    {
        this.Grip = grip;
    }

    public double Grip { get; }

    public override double Degradation
    {
        get => base.Degradation;
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException(OutputMessages.BlownTyre);
            }

            base.Degradation = value;
        }
    }

    public override void CompleteLap()
    {
        base.CompleteLap();

        this.Degradation -= this.Grip;
    }
}