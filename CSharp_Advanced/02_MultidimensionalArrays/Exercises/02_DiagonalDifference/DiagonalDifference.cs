namespace _02_DiagonalDifference
{
    using System;
    using System.Linq;

    public class DiagonalDifference
    {
        public static void Main()
        {
            var sizeOfTheSquareMatrix = int.Parse(Console.ReadLine());
            var intMatrix = new int[sizeOfTheSquareMatrix, sizeOfTheSquareMatrix];

            CreateMatrix(sizeOfTheSquareMatrix, intMatrix);
            var difference = CalculateDifferenceBetweenDiagonals(sizeOfTheSquareMatrix, intMatrix);

            Console.WriteLine(difference);
        }

        public static int CalculateDifferenceBetweenDiagonals(int sizeOfTheSquareMatrix, int[,] intMatrix)
        {
            var primaryDiagonalSum = 0;
            var secondaryDiagonalSum = 0;

            for (var i = 0; i < sizeOfTheSquareMatrix; i++)
            {
                primaryDiagonalSum += intMatrix[i, i];
            }

            for (var row = 0; row < sizeOfTheSquareMatrix; row++)
            {
                secondaryDiagonalSum += intMatrix[row, sizeOfTheSquareMatrix - row - 1];
            }

            var difference = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);

            return difference;
        }

        public static void CreateMatrix(int sizeOfTheSquareMatrix, int[,] intMatrix)
        {
            for (var i = 0; i < sizeOfTheSquareMatrix; i++)
            {
                var currentRow = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (var col = 0; col < sizeOfTheSquareMatrix; col++)
                {
                    intMatrix[i, col] = currentRow[col];
                }
            }
        }
    }
}