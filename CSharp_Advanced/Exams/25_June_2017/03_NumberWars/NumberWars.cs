namespace _03_NumberWars
{
    using System;
    using System.Linq;

    public class NumberWars
    {
        public static void Main()
        {
            var matrixDimensions = int.Parse(Console.ReadLine());
            var matrix = CreateMatrix(matrixDimensions);
            Console.WriteLine(KnightGame(matrix, matrixDimensions));
        }

        public static int KnightGame(char[,] matrix, int matrixDimensions)
        {
            var bestPower = 0;
            var removedKnights = 0;
            var bestKnight = string.Empty;

            while (true)
            {
                for (var col = 0; col < matrixDimensions; col++)
                {
                    for (var row = 0; row < matrixDimensions; row++)
                    {
                        if (matrix[col, row] != 'K') continue;
                        var currentPower = 0;

                        if (col + 1 >= 0 && row + 2 >= 0 && col + 1 < matrixDimensions && row + 2 < matrixDimensions)
                        {
                            if(matrix[col + 1, row + 2] == 'K') currentPower++;
                        }
                        if (col + 1 >= 0 && row - 2 >= 0 && col + 1 < matrixDimensions && row - 2 < matrixDimensions)
                        {
                            if(matrix[col + 1, row - 2] == 'K') currentPower++;
                        }
                        if (col + 2 >= 0 && row + 1 >= 0 && col + 2 < matrixDimensions && row + 1 < matrixDimensions)
                        {
                            if(matrix[col + 2, row + 1] == 'K') currentPower++;
                        }
                        if (col + 2 >= 0 && row - 1 >= 0 && col + 2 < matrixDimensions && row - 1 < matrixDimensions)
                        {
                            if(matrix[col + 2, row - 1] == 'K') currentPower++;
                        }
                        if (col - 1 >= 0 && row + 2 >= 0 && col - 1 < matrixDimensions && row + 2 < matrixDimensions)
                        {
                            if(matrix[col - 1, row + 2] == 'K') currentPower++;
                        }
                        if (col - 1 >= 0 && row - 2 >= 0 && col - 1 < matrixDimensions && row - 2 < matrixDimensions)
                        {
                            if(matrix[col - 1, row - 2] == 'K') currentPower++;
                        }
                        if (col - 2 >= 0 && row + 1 >= 0 && col - 2 < matrixDimensions && row + 1 < matrixDimensions)
                        {
                            if(matrix[col - 2, row + 1] == 'K') currentPower++;
                        }
                        if (col - 2 >= 0 && row - 1 >= 0 && col - 2 < matrixDimensions && row - 1 < matrixDimensions)
                        {
                            if(matrix[col - 2, row - 1] == 'K' ) currentPower++;
                        }

                        if (currentPower <= bestPower) continue;
                        bestPower = currentPower;
                        bestKnight = $"{col} {row}";
                    }
                }

                if (bestPower > 0)
                {
                    var tokens = bestKnight.Split(' ').Select(int.Parse).ToArray();
                    matrix[tokens[0], tokens[1]] = '0';
                    removedKnights++;
                    bestPower = 0;
                }

                else return removedKnights;
            }
        }

        public static char[,] CreateMatrix(int matrixDimensions)
        {
            var matrix = new char[matrixDimensions, matrixDimensions];

            for (var col = 0; col < matrixDimensions; col++)
            {
                var currentLine = Console.ReadLine().ToCharArray();

                for (var row = 0; row < matrixDimensions; row++)
                {
                    matrix[col, row] = currentLine[row];
                }
            }

            return matrix;
        }
    }
}
