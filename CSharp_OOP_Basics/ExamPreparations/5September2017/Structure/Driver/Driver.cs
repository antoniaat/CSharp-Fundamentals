public abstract class Driver
{
    public string Name { get; set; }
    public double TotalTime { get; set; }
    public Car Car { get; set; }
    public double FuelConsumptionPerKm { get; set; }
    public double Speed { get; set; }

    public Driver(string name, Car car, double time)
    {
        this.Name = name;
        this.TotalTime = time;
        this.Car = car;
        this.Speed  = (this.Car.HorsePower + this.Car.Tyre.Degradation) / this.Car.FuelAmount;
    }

    //public virtual double FuelConsumptionPerkm { get; protected set; }
}