namespace _03_SquaresInMatrix
{
    using System;
    using System.Linq;

    public class SquaresInMatrix
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = inputLine[0];
            var columns = inputLine[1];
            var matrix = new char[rows, columns];
            CreateMatrix(rows, columns, matrix);

            var numberOfAllSquareMatrixes = FindSquaresCount(rows, columns, matrix);
            Console.WriteLine(numberOfAllSquareMatrixes);
        }

        public static int FindSquaresCount(int rows, int columns, char[,] matrix)
        {
            var numberOfAllSquareMatrixes = 0;

            for (var currentRow = 0; currentRow < rows - 1; currentRow++)
            {
                for (var currentColumn = 0; currentColumn < columns - 1; currentColumn++)
                {
                    if (matrix[currentRow, currentColumn] == matrix[currentRow + 1, currentColumn] &&
                        matrix[currentRow, currentColumn] == matrix[currentRow, currentColumn + 1] &&
                        matrix[currentRow, currentColumn] == matrix[currentRow + 1, currentColumn + 1])
                    {
                        numberOfAllSquareMatrixes++;
                    }
                }
            }

            return numberOfAllSquareMatrixes;
        }

        public static void CreateMatrix(int rows, int columns, char[,] intMatrix)
        {
            for (var currentRow = 0; currentRow < rows; currentRow++)
            {
                var currentLine = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (var col = 0; col < columns; col++)
                {
                    intMatrix[currentRow, col] = currentLine[col];
                }
            }
        }
    }
}