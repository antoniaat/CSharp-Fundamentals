public class HardTyre : Tyre
{
    public HardTyre(double hardness)
        : base(hardness) { }

    public override string Name
    {
        protected set => this.Name = "Hard";
    }

    public override void ReduceDegradation()
    {
        base.Degradation -= base.Hardness;
    }

    public override void ChangeTyres(double hardness, double grip)
    {
        base.Hardness += hardness;
    }
}