namespace _02_SquareWithMaximumSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SquareWithMaximumSum
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var columns = matrixSize[0];
            var rows = matrixSize[1];
            var intMatrix = new int[columns, rows];
            var biggestNumbersInSquare = new List<int>();

            FillingMatrix(intMatrix, columns, rows, 0);
            var bestSum = BiggestTopLeftSquare(intMatrix, 0, biggestNumbersInSquare); ;
            PrintMatrix(biggestNumbersInSquare, bestSum);
        }

        public static void FillingMatrix(int[,] intMatrix, int columns, int rows, int sum)
        {
            for (var cols = 0; cols < columns; cols++)
            {
                var inputNumbers = Console.ReadLine()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (var row = 0; row < rows; row++)
                {
                    intMatrix[cols, row] = inputNumbers[row];
                    sum += intMatrix[cols, row];
                }
            }
        }

        public static int BiggestTopLeftSquare(int[,] intMatrix, int sum, List<int> biggestNumbersInSquare)
        {
            var bestSum = 0;

            for (var col = 0; col < intMatrix.GetLength(0) - 1; col++)
            {
                for (var row = 0; row < intMatrix.GetLength(1) - 1; row++)
                {
                    sum = intMatrix[col, row] + intMatrix[col + 1, row] + intMatrix[col, row + 1] + intMatrix[col + 1, row + 1];

                    if (bestSum >= sum) continue;
                    bestSum = sum;
                    biggestNumbersInSquare.Clear();
                    biggestNumbersInSquare.Add(intMatrix[col, row]);
                    biggestNumbersInSquare.Add(intMatrix[col + 1, row]);
                    biggestNumbersInSquare.Add(intMatrix[col, row + 1]);
                    biggestNumbersInSquare.Add(intMatrix[col + 1, row + 1]);
                }
            }
            return bestSum;
        }

        public static void PrintMatrix(List<int> biggestNumbersInSquare, int bestSum)
        {
            Console.WriteLine($"{biggestNumbersInSquare[0]} {biggestNumbersInSquare[2] }");
            Console.WriteLine($"{biggestNumbersInSquare[1]} {biggestNumbersInSquare[3] }");
            Console.WriteLine(bestSum);
        }
    }
}