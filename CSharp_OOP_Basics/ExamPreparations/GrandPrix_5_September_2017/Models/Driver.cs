public abstract class Driver
{
    private const double boxDefaultTime = 20;

    protected Driver(string name, Car car, double fuelConsumption)
    {
        this.Name = name;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumption;
        this.TotalTime = 0d;
        this.IsRacing = true;
    }

    public string Name { get; }

    public double TotalTime { get; set; }

    public Car Car { get; }

    public double FuelConsumptionPerKm { get; }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public string FailureReason { get; private set; }

    public bool IsRacing { get; private set; }

    private string Status => IsRacing ? this.TotalTime.ToString("f3") : this.FailureReason;

    private void Box()
    {
        this.TotalTime += boxDefaultTime;
    }

    internal void Refuel(string[] methodArgs)
    {
        this.Box();

        double fuelAmount = double.Parse(methodArgs[0]);

        this.Car.Refuel(fuelAmount);
    }

    internal void ChangeTyres(Tyre tyre)
    {
        this.Box();

        this.Car.ChangeTyres(tyre);
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Status}";
    }

    internal void CompleteLap(int trackLength)
    {
        this.TotalTime += 60 / (trackLength / this.Speed);

        this.Car.CompleteLap(trackLength, this.FuelConsumptionPerKm);
    }

    internal void Fail(string message)
    {
        this.IsRacing = false;
        this.FailureReason = message;
    }
}