namespace _01_SumMatrixElements
{
    using System;
    using System.Linq;

    public class SumMatrixElements
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var columns = matrixSize[0]; // 3
            var rows = matrixSize[1]; // 6
            var intMatrix = new int[columns, rows]; //int[3,6]
            var sum = 0;

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

            Console.WriteLine(columns);
            Console.WriteLine(rows);
            Console.WriteLine(sum);
        }
    }
}