internal class Rectangle
{
    public string Id { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public double Horizontal { get; set; }

    public double Vertical { get; set; }

    public Rectangle(string id, double width, double height, double horizontal, double vertical)
    {
        this.Id = id;
        this.Width = width;
        this.Height = height;
        this.Horizontal = horizontal;
        this.Vertical = vertical;
    }

    public bool IntersectsWith(Rectangle r2)
    {
        return r2.Horizontal + r2.Width >= this.Horizontal &&
               r2.Horizontal <= this.Horizontal + this.Width &&
               r2.Vertical >= this.Vertical - this.Height &&
               r2.Vertical - r2.Height <= this.Vertical;
    }
}