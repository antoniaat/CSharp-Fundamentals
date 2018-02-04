namespace _06_ТargetPractice
{
    using System;
    using System.Linq;

    public class ТargetPractice
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
            var snakeName = Console.ReadLine();
            var shotsRowAndColumn = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var shotRow = shotsRowAndColumn[0];
            var shotColumn = shotsRowAndColumn[1];
            var shotRadius = shotsRowAndColumn[2];

            CreateMatrix(rows, columns, matrix, snakeName);
            EliminateSnakes(matrix, shotRow, shotColumn, shotRadius, rows, columns);
            FallingDownCharacter(matrix, rows, columns);
            PrintMatrix(matrix, rows, columns);
        }

        public static void PrintMatrix(char[,] matrix, int rows, int columns)
        {
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < columns; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        public static void FallingDownCharacter(char[,] matrix, int rows, int columns)
        {
            for (var i = 0; i < 100; i++)
            {
                for (var row = 0; row < rows - 1; row++)
                {
                    for (var col = 0; col < columns; col++)
                    {
                        if (matrix[row + 1, col] == ' ')
                        {
                            matrix[row + 1, col] = matrix[row, col];
                            matrix[row, col] = ' ';
                        }
                    }
                }
            }
        }

        public static void EliminateSnakes(char[,] matrix, int shotRow, int shotColumn, int shotRadius, int rows, int columns)
        {
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < columns; col++)
                {
                    if (row == shotRow && col == shotColumn)
                    {
                        if (shotRadius == 0)
                        {
                            matrix[row, col] = ' ';
                            return;
                        }

                        try
                        {
                            matrix[row, col] = ' ';

                            //Remove Up, Down, Left and Right snakes
                            for (var i = 1; i <= shotRadius; i++)
                            {
                                matrix[row - i, col] = ' ';
                                matrix[row + i, col] = ' ';
                                matrix[row, col - i] = ' ';
                                matrix[row, col + i] = ' ';
                            }

                            //Remove snakes at diagonals
                            matrix[row - 1, col + 1] = ' ';
                            matrix[row + 1, col - 1] = ' ';
                            matrix[row + 1, col + 1] = ' ';
                            matrix[row - 1, col - 1] = ' ';

                            return;
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
            }
        }

        public static void CreateMatrix(int rows, int columns, char[,] matrix, string snakeName)
        {
            var copyOfTheName = snakeName;

            for (var row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                if (row % 2 == 0)
                {
                    for (var col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        snakeName = FillMatrix(copyOfTheName, snakeName, matrix, row, col);
                    }
                }
                else
                {
                    for (var col = 0; col < matrix.GetLength(1); col++)
                    {
                        snakeName = FillMatrix(copyOfTheName, snakeName, matrix, row, col);
                    }
                }
            }
        }

        public static string FillMatrix(string copyOfTheName, string snakeName, char[,] matrix, int row, int col)
        {
            if (snakeName.Length == 0)
            {
                snakeName = copyOfTheName;
            }
            matrix[row, col] = snakeName.First();

            return snakeName = snakeName.Substring(1);
        }
    }
}