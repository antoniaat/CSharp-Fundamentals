using System.Text;

public class Rectangle : Shape
{
    public double Height { get; protected set; }
    public double Width { get; protected set; }

    public Rectangle(double height, double width)
    {
        this.Height = height;
        this.Width = width;
    }

    public override double CalculatePerimeter()
    {
        return 2 * (this.Height + this.Width);
    }

    public override double CalculateArea()
    {
        return this.Height * this.Width;
    }

    public override string Draw()
    {
        var drawing = new StringBuilder();

        for (int col = 0; col < this.Height; col++)
        {
            drawing.AppendLine(new string('*', (int)this.Width));
        }

        return drawing.ToString();
    }
}
