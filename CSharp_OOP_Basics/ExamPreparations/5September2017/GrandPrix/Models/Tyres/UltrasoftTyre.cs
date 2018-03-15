using System;

public class UltrasoftTyre : Tyre
{
    private double _grip;
    private double _degradation;

    public UltrasoftTyre(double hardness, double grip)
        : base( hardness)
    {
        this.Grip = grip;
    }

    public override string Name
    {
        protected set => this.Name = "Ultrasoft";
    }
    public override double Degradation
    {
        get => this._degradation;
        set
        {
            if (value < 30)
            {
                throw new ArgumentException(Constants.BlownTyreFailureMessage);
            }

            this._degradation = value;
        }
    }

    public double Grip
    {
        get => this._grip;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Cannot be less than 0.");
            }
            this._grip = value;
        }
    }

    public override void ReduceDegradation()
    {
        base.Degradation -= base.Hardness + this.Grip;
    }

    public override void ChangeTyres(double hardness, double grip)
    {
        base.Hardness += hardness;
        this.Grip += grip;
    }
}