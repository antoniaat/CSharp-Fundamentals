namespace _06_ТargetPractice
{
    using System;
    using System.Linq;

    public class ТargetPractice
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine().Split();
            var snake = Console.ReadLine();
            var shotParameters = Console.ReadLine().Split();

            var numberOfRows = int.Parse(dimensions[0]);
            var numberOfColumns = int.Parse(dimensions[1]);

            var impactRow = int.Parse(shotParameters[0]);
            var impactCol = int.Parse(shotParameters[1]);
            var shotRadius = int.Parse(shotParameters[2]);

            var matrix = new char[numberOfRows][];

            FillMatrix(snake, matrix, numberOfColumns);

            FireAShot(matrix, impactRow, impactCol, shotRadius);

            DropCharacters(matrix);

            PrintMatrix(matrix);
        }

        private static void FillMatrix(string snake, char[][] matrix, int matrixWidth)
        {
            for (var i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new char[matrixWidth];
            }

            var isMovingLeft = true;
            var currentSymbolIndex = 0;

            for (var row = matrix.Length - 1; row >= 0; row--)
            {
                var col = isMovingLeft ? matrixWidth - 1 : 0;
                var colUpdate = isMovingLeft ? -1 : 1;

                while (0 <= col && col < matrixWidth)
                {
                    if (currentSymbolIndex >= snake.Length)
                    {
                        currentSymbolIndex = 0;
                    }

                    matrix[row][col] = snake[currentSymbolIndex];

                    currentSymbolIndex++;
                    col += colUpdate;
                }

                isMovingLeft = !isMovingLeft;
            }
        }

        private static void FireAShot(char[][] matrix, int impactRow, int impactCol, int shotRadius)
        {
            var matrixWidth = matrix[0].Length;

            for (var row = 0; row < matrix.Length; row++)
            {
                for (var col = 0; col < matrixWidth; col++)
                {
                    if (IsInsideRadius(row, col, impactRow, impactCol, shotRadius))
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }
        }

        private static bool IsInsideRadius(int checkRow, int checkCol, int impactRow, int impactCol, int shotRadius)
        {
            var deltaRow = checkRow - impactRow;
            var deltaCol = checkCol - impactCol;
            var isInRadius = deltaRow * deltaRow + deltaCol * deltaCol <= shotRadius * shotRadius;

            return isInRadius;
        }

        private static void DropCharacters(char[][] matrix)
        {
            var width = matrix[0].Length;

            for (var row = matrix.Length - 1; row >= 0; row--)
            {
                for (var column = 0; column < width; column++)
                {
                    if (matrix[row][column] != ' ')
                    {
                        continue;
                    }

                    int currentRow = row - 1;
                    while (currentRow >= 0)
                    {
                        if (matrix[currentRow][column] != ' ')
                        {
                            matrix[row][column] = matrix[currentRow][column];
                            matrix[currentRow][column] = ' ';
                            break;
                        }

                        currentRow--;
                    }
                }
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            var matrixWidth = matrix[0].Length;

            foreach (var ch in matrix)
            {
                for (var col = 0; col < matrixWidth; col++)
                {
                    Console.Write(ch[col]);
                }

                Console.WriteLine();
            }
        }
    }
}