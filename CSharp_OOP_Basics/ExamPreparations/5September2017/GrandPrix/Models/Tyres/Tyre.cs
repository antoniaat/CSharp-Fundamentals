using System;

public abstract class Tyre
{
    private double _degradation;

    protected Tyre(double hardness)
    {
        this.Hardness = hardness;
        this.Degradation = _degradation;
    }

    public virtual string Name { get; protected set; }

    public double Hardness { get; set; }

    public virtual double Degradation
    {
        get => this._degradation = 100;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format(Constants.BlownTyreFailureMessage));
            }

            this._degradation = value;
        }
    }

    public virtual void ReduceDegradation() { }
    public virtual void ChangeTyres(double hardness, double grid) { }
}