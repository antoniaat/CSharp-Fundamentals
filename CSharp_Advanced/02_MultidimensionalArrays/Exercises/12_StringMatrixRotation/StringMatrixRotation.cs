using System.Collections.Generic;
using System.Linq;

namespace _12_StringMatrixRotation
{
    using System;

    public class StringMatrixRotation
    {
        public static void Main()
        {
            var command = Console.ReadLine()
                .Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var rotateDegrees = int.Parse(command[1]);
            var listOfInputLines = new List<string>();
            string inputLines;
            while ((inputLines = Console.ReadLine()) != "END") listOfInputLines.Add(inputLines);
            var matrix = CreateAndFillMatrix(listOfInputLines);

            Console.WriteLine();
        }

        private static char[,] CreateAndFillMatrix(List<string> listOfInputLines)
        {
            var rowsLenght = listOfInputLines.OrderByDescending(s => s.Length).First();
            var matrix = new char[listOfInputLines.Count, rowsLenght.Length];

            foreach (var line in listOfInputLines)
            {
                
                for (var col = 0; col < listOfInputLines.Count; col++)
                {
                    for (var row = 0; row < rowsLenght.Length; row++)
                    {
                        var word = line.Trim().ToCharArray();
                        var diff = rowsLenght.Length - word.Length;

                        foreach (var c in word)
                        {
                            matrix[col, row] = word[row];
                        }
                        for (var i = 0; i < diff; i++)
                        {
                            matrix[col, row] = ' ';
                        }
                    }
                }
            }

            return matrix;
        }
    }
}
