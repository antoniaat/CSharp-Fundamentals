using System;

internal class Box
{
    private decimal length;
    private decimal width;
    private decimal height;

    public Box(decimal length, decimal width, decimal height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public decimal SurfaceArea()
    {
        return (2 * Length * Width) + (2 * Length * Height) + (2 * Width * Height);
    }

    public decimal LateralSurfaceArea()
    {
        return 2 * Length * Height + 2 * Width * Height;
    }

    public decimal Volume()
    {
        return Height * Length * Width;
    }

    public decimal Length
    {
        get => this.length;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
            this.length = value;
        }
    }

    public decimal Width
    {
        get => this.width;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
            this.width = value;
        }
    }

    public decimal Height
    {
        get => this.height;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
            this.height = value;
        }
    }

    public override string ToString()
    {
        return $"Surface Area - {SurfaceArea():f2} \n" +
               $"Lateral Surface Area - {LateralSurfaceArea():f2} \n" +
               $"Volume - {Volume():f2}";
    }
}