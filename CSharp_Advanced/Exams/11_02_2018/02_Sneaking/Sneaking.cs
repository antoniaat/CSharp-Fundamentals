namespace _02_Sneaking
{
    using System;
    using System.Collections.Generic;

    public class Sneaking
    {
        public static void Main()
        {
            var columns = int.Parse(Console.ReadLine());
            var matrix = CreateMatrix(columns);
            var commands = Console.ReadLine().ToCharArray();

            foreach (var currentCommand in commands)
            {
                MoveEnemies(matrix);
                MoveSam(matrix, currentCommand);
                if(CheckIfHeKillNiki(matrix)) break;
            }

        }

        static bool CheckIfHeKillNiki(char[,] matrix)
        {
            var killed = false;

            for (var col = 1; col < matrix.GetLength(0); col++)
            {
                for (var row = 0; row < matrix.GetLength(1); row++)
                {
                    if (matrix[col, row] == 'N')
                    {
                        Console.WriteLine($"Nikoladze killed!");

                        for (var column = 0; column < matrix.GetLength(0); column++)
                        {
                            for (var r = 0; r < matrix.GetLength(1); r++)
                            {
                                Console.Write($"{matrix[column, row]}");
                            }
                            Console.WriteLine();
                        }

                        killed = true;
                    }
                }
            }

            return killed;
        }

        static void MoveSam(char[,] matrix, char currentCommand)
        {
            var samDimensions = GetSamIndex(matrix);
            var samColumn = samDimensions[0];
            var samRow = samDimensions[1];

            if (currentCommand == 'U')
            {
                matrix[samColumn, samRow] = '.';
                matrix[samColumn - 1, samRow] = 'S';
            }
            else if (currentCommand == 'D')
            {
                matrix[samColumn, samRow] = '.';
                matrix[samColumn + 1, samRow] = 'S';
            }
            else if (currentCommand == 'L')
            {
                matrix[samColumn, samRow] = '.';
                matrix[samColumn, samRow - 1] = 'S';
            }
            else if (currentCommand == 'R')
            {
                matrix[samColumn, samRow] = '.';
                matrix[samColumn, samRow + 1] = 'S';
            }
            //else if (currentCommand == 'W')
            //{

            //}
        }

        static List<int> GetSamIndex(char[,] matrix)
        {
            var dimensions = new List<int>();

            for (var col = 1; col < matrix.GetLength(0); col++)
            {
                for (var row = 0; row < matrix.GetLength(1); row++)
                {
                    if (matrix[col, row] == 'S')
                    {
                        dimensions.Add(col);
                        dimensions.Add(row);
                    }
                }
            }

            return dimensions;
        }

        public static void MoveEnemies(char[,] matrix)
        {
            for (var col = 1; col < matrix.GetLength(0); col++)
            {
                for (var row = 0; row < matrix.GetLength(1); row++)
                {
                    if (row == matrix.GetLength(1) - 1) // Last Row - Change letter
                    {
                        if (matrix[col, row] == 'b')
                        {
                            matrix[col, row] = 'd';
                        }
                        else if (matrix[col, row] == 'd')
                        {
                            matrix[col, row] = 'b';
                        }
                    }
                    else
                    {
                        if (matrix[col, row] == 'b')
                        {
                            for (int i = row; i < matrix.GetLength(1); i++) // Check if Sam is on the same row
                            {
                                if (matrix[col, i] == 'S')
                                {
                                    Console.WriteLine($"Sam died at {col}, {i}");
                                    return;
                                }
                            }

                            matrix[col, row] = '.';
                            matrix[col, row + 1] = 'b';
                            break;
                        }

                        if (matrix[col, row] == 'd')
                        {
                            for (int i = row; i >= 0; i--) // Check if Sam is on the same row
                            {
                                if (matrix[col, i] == 'S')
                                {
                                    Console.WriteLine($"Sam died at {col}, {i}");
                                    return;
                                }
                            }

                            matrix[col, row] = '.';
                            matrix[col, row - 1] = 'd';
                            break;
                        }
                    }
                }
            }
        }

        static char[,] CreateMatrix(int columns)
        {
            var firstLine = Console.ReadLine().ToCharArray();
            var matrix = new char[columns, firstLine.Length];
            for (var i = 0; i < firstLine.Length; i++)
            {
                matrix[0, i] = firstLine[i];
            }

            for (var col = 1; col < columns; col++)
            {
                var currentLine = Console.ReadLine().ToCharArray();

                for (var row = 0; row < firstLine.Length; row++)
                {
                    matrix[col, row] = currentLine[row];
                }
            }

            return matrix;
        }
    }
}
