using System.Collections.Generic;

internal class Car
{
    private string model;
    private int engineSpeed;
    private int enginePower;
    private int cargoWeight;
    private string cargoType;
    private List<Tire> tires;

    public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, List<Tire> tires)
    {
        this.Model = model;
        this.EngineSpeed = engineSpeed;
        this.EnginePower = enginePower;
        this.CargoWeight = cargoWeight;
        this.CargoType = cargoType;
        this.Tires = new List<Tire>();
    }

    public string Model { get; set; }
    public int EngineSpeed { get; set; }
    public int EnginePower { get; set; }
    public int CargoWeight { get; set; }
    public string CargoType { get; set; }
    public List<Tire> Tires { get; set; }
}
