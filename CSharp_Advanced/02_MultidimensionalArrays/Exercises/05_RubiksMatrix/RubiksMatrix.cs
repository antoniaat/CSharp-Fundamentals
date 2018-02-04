namespace _05_RubiksMatrix
{
    using System;
    using System.Linq;

    public class RubiksMatrix
    {
        public static void Main()
        {
            var rubikSizes = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var numberOfCommands = int.Parse(Console.ReadLine());

            var matrix = new int[rubikSizes[0]][];
            var counter = 1;

            CreateMatrix(matrix, rubikSizes, counter);
            ReadCommands(matrix, numberOfCommands);
            PrintResult(matrix);
        }

        public static void CreateMatrix(int[][] matrix, int[] rubikSizes, int counter)
        {
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row] = new int[rubikSizes[1]];

                for (var col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = counter++;
                }
            }
        }

        public static void ReadCommands(int[][] matrix, int numberOfCommands)
        {
            for (var i = 0; i < numberOfCommands; i++)
            {
                var currentCommand = Console.ReadLine().Split().ToArray();

                var startIndex = int.Parse(currentCommand[0]);
                var direction = currentCommand[1];
                var moves = int.Parse(currentCommand[2]);

                switch (direction)
                {
                    case "up":
                        MoveUp(matrix, startIndex, moves);
                        break;

                    case "down":
                        MoveDown(matrix, startIndex, moves);
                        break;

                    case "left":
                        MoveLeft(matrix, startIndex, moves);
                        break;

                    case "right":
                        MoveRight(matrix, startIndex, moves);
                        break;
                }
            }
        }

        public static void MoveRight(int[][] rubik, int startIndex, int moves)
        {
            for (int index = 0; index < moves % rubik.Length; index++)
            {
                for (int col = rubik.Length - 1; col > 0; col--)
                {
                    var temp = rubik[startIndex][col];
                    var next = rubik[startIndex][col - 1];
                    rubik[startIndex][col - 1] = temp;
                    rubik[startIndex][col] = next;
                }
            }
        }

        private static void MoveLeft(int[][] rubik, int startIndex, int moves)
        {
            for (var index = 0; index < moves % rubik.Length; index++)
            {
                for (var col = 0; col < rubik.Length - 1; col++)
                {
                    var temp = rubik[startIndex][col];
                    rubik[startIndex][col] = rubik[startIndex][col + 1];
                    rubik[startIndex][col + 1] = temp;
                }
            }
        }

        private static void MoveDown(int[][] rubik, int startIndex, int moves)
        {
            for (var index = 0; index < moves % rubik.Length; index++)
            {
                for (var row = rubik.Length - 1; row > 0; row--)
                {
                    var temp = rubik[row][startIndex];
                    rubik[row][startIndex] = rubik[row - 1][startIndex];
                    rubik[row - 1][startIndex] = temp;
                }
            }
        }

        private static void MoveUp(int[][] rubik, int startIndex, int moves)
        {
            for (var index = 0; index < moves % rubik.Length; index++)
            {
                for (var row = 0; row < rubik.Length - 1; row++)
                {
                    var temp = rubik[row][startIndex];
                    rubik[row][startIndex] = rubik[row + 1][startIndex];
                    rubik[row + 1][startIndex] = temp;
                }
            }
        }

        public static void PrintResult(int[][] matrix)
        {
            var numberToCheck = 1;

            for (var row = 0; row < matrix.Length; row++)
            {
                for (var col = 0; col < matrix.Length; col++)
                {
                    if (matrix[row][col] == numberToCheck)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        var swapRow = 0;
                        var swapCol = 0;

                        for (var r = row; r < matrix.Length; r++)
                        {
                            for (var c = 0; c < matrix.Length; c++)
                            {
                                if (matrix[r][c] == numberToCheck)
                                {
                                    swapRow = r;
                                    swapCol = c;
                                    var tempElement = matrix[r][c];
                                    matrix[r][c] = matrix[row][col];
                                    matrix[row][col] = tempElement;
                                }
                            }
                        }
                        Console.WriteLine($"Swap ({row}, {col}) with ({swapRow}, {swapCol})");
                    }

                    numberToCheck++;
                }
            }
        }
    }
}