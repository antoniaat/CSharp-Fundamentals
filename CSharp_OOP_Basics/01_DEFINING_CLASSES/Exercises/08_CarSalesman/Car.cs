internal class Car
{
    private string model;
    private Engine engine;
    private int weight;
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
        return $"{this.Model}: \n  {Engine.Model}: \n    Power: {Engine.Power} \n    Displacement: {Engine.Displacement} \n    Efficiency: {Engine.Efficiency} \n  Weight: {this.Weight} \n  Color: {this.Color}";
    }
}