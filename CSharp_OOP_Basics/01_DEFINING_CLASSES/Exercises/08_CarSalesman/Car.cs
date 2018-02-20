internal class Car
{
    private string model;
    private Engine engine;
    private string weight;
    private string color;

    public Car(string model, Engine engine)
    {
        this.Model = model;
        this.Engine = engine;
    }

    public Car(string model, Engine engine, int weight, string color) : this(model, engine)
    {
        this.Weight = weight;
        this.Color = color;
    }

    public Car(string model, Engine engine, int weight) : this(model, engine)
    {
        this.Weight = weight;
    }

    public Car(string model, Engine engine, string color) : this(model, engine)
    {
        this.Color = color;
    }

    public Car(string model, Engine engine, string color, int weight) : this(model, engine)
    {
        this.Color = color;
        this.Weight = weight;
    }

    public string Model { get; set; }
    public Engine Engine { get; set; }
    public int Weight { get; set; }
    public string Color { get; set; }

    public override string ToString()
    {
        var weightStr = Weight == 0 ? "n/a" : this.Weight.ToString();
        var displacement = Engine.Displacement == 0 ? "n/a" : Engine.Displacement.ToString();
        var color = Color ?? "n/a";
        var efficiency = Engine.Efficiency ?? "n/a";

        return $"{this.Model}: \n  {Engine.Model}: \n    Power: {Engine.Power} \n    Displacement: {displacement} \n    Efficiency: {efficiency} \n  Weight: {weightStr} \n  Color: {color}";
    }
}