namespace _04_MaximalSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaximalSum
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = inputLine[0];
            var columns = inputLine[1];
            var matrix = new int[rows, columns];
            var biggestNums = new List<string>();

            CreateMatrix(rows, columns, matrix);
            var squareMaxSum = FindSquaresMaxSum(rows, columns, matrix, biggestNums);

            Console.WriteLine($"Sum = {squareMaxSum}");
            Console.WriteLine(string.Join("\n", biggestNums));
        }

        public static int FindSquaresMaxSum(int rows, int columns, int[,] matrix, List<string> biggestNums)
        {
            var squareMaxSum = 0;

            for (var row = 0; row < rows - 2; row++)
            {
                for (var col = 0; col < columns - 2; col++)
                {
                    var currentSquareSum = matrix[row, col] + matrix[row + 1, col] + matrix[row + 2, col] + matrix[row, col + 1] + matrix[row + 1, col + 1] + matrix[row + 2, col + 1] + matrix[row, col + 2] + matrix[row + 1, col + 2] + matrix[row + 2, col + 2];

                    if (currentSquareSum <= squareMaxSum) continue;
                    squareMaxSum = currentSquareSum;
                    biggestNums.Clear();
                    biggestNums.Add($"{matrix[row, col]} {matrix[row, col + 1]} {matrix[row, col + 2]}");
                    biggestNums.Add($"{matrix[row + 1, col]} {matrix[row + 1, col + 1]} {matrix[row + 1, col + 2]}");
                    biggestNums.Add($"{matrix[row + 2, col]} {matrix[row + 2, col + 1]} {matrix[row + 2, col + 2]}");
                }
            }

            return squareMaxSum;
        }

        public static void CreateMatrix(int rows, int columns, int[,] intMatrix)
        {
            for (var currentRow = 0; currentRow < rows; currentRow++)
            {
                var currentLine = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (var col = 0; col < columns; col++)
                {
                    intMatrix[currentRow, col] = currentLine[col];
                }
            }
        }
    }
}