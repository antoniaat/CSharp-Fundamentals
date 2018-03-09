public class SpecialisedSoldier : Private
{
    private string corps;

    public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
    {
        this.Corps = corps;
    }

    public string Corps {
        get => this.corps;
        set
        {
            if (value == "Airforces" || value == "Marines")
            {
                this.corps = value;
            }
        }
    }
}
