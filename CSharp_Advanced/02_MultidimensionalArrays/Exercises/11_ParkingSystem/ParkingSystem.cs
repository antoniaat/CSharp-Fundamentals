namespace _11_ParkingSystem
{
    using System;
    using System.Linq;

    public class ParkingSystem
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var columns = dimensions[0];
            var rows = dimensions[1];
            var matrix = new bool[columns, rows];

            CreateAndFillTheMatrix(matrix, columns, rows);
            ReadLines(matrix);

            Console.WriteLine();
        }

        public static void ReadLines(bool[,] matrix)
        {
            string currentLine;
            while ((currentLine = Console.ReadLine()) != "stop")
            {
                var tokens = currentLine.Split(new char[] {' '})
                    .Select(int.Parse)
                    .ToList();

                var entryCol = tokens[0];
                var parkingColumn = tokens[1];
                var parkingRow = tokens[2];

                Parking(matrix, entryCol, parkingColumn, parkingRow);
            }
        }

        public static void Parking(bool[,] matrix, int entryCol, int parkingColumn, int parkingRow)
        {
            var counter = 0;

            for (var col = entryCol; col < parkingColumn; col++)
            {
                counter++;
            }

            for (var row = 0; row < parkingRow; row++)
            {
                counter++;

                if (row == parkingRow && matrix[parkingColumn, row])
                {
                    matrix[parkingColumn, parkingRow] = false;
                }
                else if (matrix[parkingColumn, row-1])
                {
                    row--;
                }
                else if (matrix[parkingColumn, row + 1])
                {
                    row++;
                }
            }
        }

        public static void CreateAndFillTheMatrix(bool[,] matrix, int columns, int rows)
        {
            // free = true

            for (var col = 0; col < columns; col++)
            {
                for (var row = 0; row < rows; row++)
                {
                    if (row == 0) matrix[col, row] = false;
                    else matrix[col, row] = true;
                }
            }
        }
    }
}