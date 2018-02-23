using System;
using System.Linq;

public class JediGalaxy
{
    public static void Main()
    {
        var dimestions = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var cols = dimestions[0];
        var rows = dimestions[1];

        int[,] matrix = CreateMatrix(cols, rows);
        long collectedStars = CountCollectedStars(matrix);

        Console.WriteLine(collectedStars);
    }

    private static long CountCollectedStars(int[,] matrix)
    {
        long collectedStars = 0;

        string command;
        while ((command = Console.ReadLine()) != "Let the Force be with you")
        {
            var ivoS = command
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var evilDimensions = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var evilRow = evilDimensions[0];
            var evilCol = evilDimensions[1];

            CollectStarts(evilRow, evilCol, matrix);

            var personRow = ivoS[0];
            var personCol = ivoS[1];

            collectedStars = DestroyStars(personRow, personCol, matrix, collectedStars);
        }

        return collectedStars;
    }

    private static long DestroyStars(int personRow, int personCol, int[,] matrix, long collectedStars)
    {
        while (personRow >= 0 && personCol < matrix.GetLength(1))
        {
            if (personRow >= 0 && personRow < matrix.GetLength(0) && personCol >= 0 && personCol < matrix.GetLength(1))
            {
                collectedStars += matrix[personRow, personCol];
            }

            personCol++;
            personRow--;
        }

        return collectedStars;
    }

    private static void CollectStarts(int evilRow, int evilCol, int[,] matrix)
    {
        while (evilRow >= 0 && evilCol >= 0)
        {
            if (evilRow >= 0 && evilRow < matrix.GetLength(0) && evilCol >= 0 && evilCol < matrix.GetLength(1))
            {
                matrix[evilRow, evilCol] = 0;
            }
            evilRow--;
            evilCol--;
        }
    }

    private static int[,] CreateMatrix(int cols, int rows)
    {
        var matrix = new int[cols, rows];

        var value = 0;
        for (int col = 0; col < cols; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                matrix[col, row] = value++;
            }
        }

        return matrix;
    }
}