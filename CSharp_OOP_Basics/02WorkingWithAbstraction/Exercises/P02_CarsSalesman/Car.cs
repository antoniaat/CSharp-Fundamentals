using System.Text;

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
        this.Weight = -1;
        this.Color = "n/a";
    }

    public Car(string model, Engine engine, int weight) : this(model, engine)
    {
        this.Weight = weight;
    }

    public Car(string model, Engine engine, string color) : this(model, engine)
    {
        this.Weight = -1;
        this.Color = color;
    }

    public Car(string model, Engine engine, int weight, string color) : this(model, engine, weight)
    {
        this.Color = color;
    }

    public string Model { get; set; }
    public Engine Engine { get; set; }
    public int Weight { get; set; }
    public string Color { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendFormat($"{Model}:\n");
        sb.Append($"{Engine}");
        sb.AppendFormat("  Weight: {0}\n", Weight == -1 ? "n/a" : Weight.ToString());
        sb.AppendFormat($"  Color: {Color}");
            
        return sb.ToString();
    }
}