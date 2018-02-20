using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var rectanglesList = new List<Rectangle>();

        var inputLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var numberOfRectangles = int.Parse(inputLine[0]);
        var intersectionCheks = int.Parse(inputLine[1]);

        for (int i = 0; i < numberOfRectangles; i++)
        {
            var rectangle = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            rectanglesList.Add(new Rectangle(rectangle[0], double.Parse(rectangle[1]), double.Parse(rectangle[2]), double.Parse(rectangle[3]), double.Parse(rectangle[4])));
        }

        for (int i = 0; i < intersectionCheks; i++)
        {
            var rectangleCheck = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var firstRectangleId = rectangleCheck[0];
            var secondRectangleId = rectangleCheck[1];

            var firstRectangle = rectanglesList.First(r => r.Id == firstRectangleId);
            var secondRectangle = rectanglesList.First(r => r.Id == secondRectangleId);

            Console.WriteLine(firstRectangle.IntersectsWith(secondRectangle) ? "true" : "false");
        }
    }
}