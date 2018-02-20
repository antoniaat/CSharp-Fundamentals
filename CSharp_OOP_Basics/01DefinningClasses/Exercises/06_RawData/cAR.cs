internal class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private Tire[] tires;

    public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
    {
        this.Model = model;
        this.Engine = engine;
        this.Cargo = cargo;
        this.tires = tires;
    }

    public string Model { get => model; set => model = value; }
    public Engine Engine { get => engine; set => engine = value; }
    public Cargo Cargo { get => cargo; set => cargo = value; }
    public Tire[] Tires { get => tires; set => tires = value; }
}