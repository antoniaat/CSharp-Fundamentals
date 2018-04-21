public class InfinityHarvester : Harvester
{
    private double durability;

    public InfinityHarvester(int id, double oreOutput, double energyRequirement)
        : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput /= Constants.OreOutputDivider;
    }

    public override double Durability
    {
        get => this.durability;

        protected set => this.durability = Constants.PermanentDurability;
    }
}