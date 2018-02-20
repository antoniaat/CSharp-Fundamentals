public class Car
{
    private string model;
    private double amount;
    private double consumption;
    private double distance;

    public string Model
    {
        get => this.model;
        set => this.model = value;
    }

    public double Amount
    {
        get => this.amount;
        set => this.amount = value;
    }

    public double Consumption
    {
        get => this.consumption;
        set => this.consumption = value;
    }

    public double Distance
    {
        get => this.distance;
        set => this.distance = value;
    }

    public Car(string model, double amount, double consumption)
    {
        this.Model = model;
        this.Amount = amount;
        this.Consumption = consumption;
    }

    public override string ToString()
    {
        return $"{this.Model} {this.amount:f2} {this.Distance}";
    }
}