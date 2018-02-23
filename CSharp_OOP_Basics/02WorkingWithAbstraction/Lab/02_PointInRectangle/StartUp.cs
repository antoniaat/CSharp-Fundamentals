using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var rectangleCoordinates = Console.ReadLine()
            .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        var topLeftX = rectangleCoordinates[0];
        var topLeftY = rectangleCoordinates[1];
        var bottomRightX = rectangleCoordinates[2];
        var bottomRightY = rectangleCoordinates[3];

        var rectangle = new Rectangle(topLeftX, topLeftY, bottomRightX, bottomRightY);

        var nLines = int.Parse(Console.ReadLine());
        ReadLinesAndPrintResult(nLines, rectangle);
    }

    private static void ReadLinesAndPrintResult(int nLines, Rectangle rectangle)
    {
        for (int i = 0; i < nLines; i++)
        {
            var currentSquare = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var square = new Point(currentSquare[0], currentSquare[1]);
            Console.WriteLine(rectangle.Contains(square));
        }
    }
}
