namespace _7_LegoBlocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LegoBlocks
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var firstJaggedArray = FillTheRows(n);
            var secondJaggedArray = FillTheRows(n);
            ReverseSecondJaggedArray(secondJaggedArray, n);
            var matrix = MakeMatrixFromJaggedArrays(firstJaggedArray, secondJaggedArray, n);
            var isFit = CheckForFitting(matrix, n);

            if (isFit) PrintMatrix(matrix);
            else Console.WriteLine($"The total number of cells is: {TotalNumberOfCells(matrix)}");
        }

        public static int TotalNumberOfCells(int[][] matrix)
        {
            var count = 0;

            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                count += matrix[i].Length;
            }

            return count;
        }

        public static void PrintMatrix(int[][] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("[");
                Console.Write(string.Join(", ", matrix[i]));
                Console.WriteLine("]");
            }
        }

        public static bool CheckForFitting(int[][] matrix, int n)
        {
            var isFit = false;

            for (var i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                isFit = matrix[i].Length == matrix[i + 1].Length;
            }

            return isFit;
        }

        public static int[][] MakeMatrixFromJaggedArrays(int[][] firstJaggedArray, int[][] secondJaggedArray, int n)
        {
            var matrix = new int[n][];
            var fullLine = new List<int>();

            for (var currentRow = 0; currentRow < n; currentRow++)
            {
                fullLine.AddRange(firstJaggedArray[currentRow]);
                fullLine.AddRange(secondJaggedArray[currentRow]);
                matrix[currentRow] = fullLine.ToArray();
                fullLine.Clear();
            }

            return matrix;
        }

        public static void ReverseSecondJaggedArray(int[][] secondArray, int n)
        {
            for (var i = 0; i < n; i++)
            {
                secondArray[i] = secondArray[i].Reverse().ToArray();
            }
        }

        public static int[][] FillTheRows(int n)
        {
            var currentJaggedArray = new int[n][];

            for (var i = 0; i < n; i++)
            {
                currentJaggedArray[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            return currentJaggedArray;
        }
    }
}