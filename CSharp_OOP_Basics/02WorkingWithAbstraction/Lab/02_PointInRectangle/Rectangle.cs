public class Rectangle
{
    private int top;
    private int left;
    private int bottom;
    private int right;

    public Rectangle(int top, int left, int bottom, int right)
    {
        this.Top = top;
        this.Left = left;
        this.Bottom = bottom;
        this.Right = right;
    }

    public int Top { get; set; }
    public int Left { get; set; }
    public int Bottom { get; set; }
    public int Right { get; set; }

    public bool Contains(Point point)
    {
        bool isInHorizontal = this.Top <= point.X && this.Bottom >= point.X;

        bool isInVertical = this.Left <= point.Y && this.Right >= point.Y;

        bool isInRectangle = isInHorizontal && isInVertical;

        return isInRectangle;
    }
}
