public abstract class Driver
{
    private double _speed;
    private double _totalTime;
    private double _fuelConsumptionPerKm;

    public string Name { get; set; }
    public Car Car { get; set; }

    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
        this.Speed = _speed;
        this.TotalTime = _totalTime;
        this.FuelConsumptionPerkm = _fuelConsumptionPerKm;
    }

    public double TotalTime { get; set; }

    public virtual double FuelConsumptionPerkm { get; protected set; }
   
    public virtual double Speed
    {
        get => this._speed = (this.Car.HorsePower + this.Car.Tyre.Degradation) / this.Car.FuelAmount;
        protected set => this._speed = value;
    }
}