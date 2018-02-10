namespace _11_ParkingSystem
{
    using System;

    public class ParkingSystem
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var rows = int.Parse(input[0]);
            var columns = int.Parse(input[1]);
            var matrix = new byte[rows][];             
            var command = string.Empty;

            ReadCommands(command, matrix, input, rows, columns);
        }

        private static void ReadCommands(string command, byte[][] matrix, string[] input, int rows, int columns)
        {
            while ((command = Console.ReadLine()) != "stop")
            {
                var data = command.Split();
                var entrance = int.Parse(data[0]);
                var row = int.Parse(data[1]);
                var col = int.Parse(data[2]);

                var steps = Math.Abs(entrance - row) + 1;                            // initial steps in first (0) column
                if (matrix[row] == null) matrix[row] = new byte[columns];                // if current array is empty

                if (matrix[row][col] == 0)
                {
                    matrix[row][col] = 1;
                    steps += col;                           // add steps in the row to the initial steps
                    Console.WriteLine(steps);
                }
                else
                {
                    var cnt = 1;                            // counter for cells
                    while (true)
                    {
                        var lowerCell = col - cnt;
                        var upperCell = col + cnt;

                        if (lowerCell < 1 && upperCell > columns - 1)  // if cells are out of bounds
                        {
                            Console.WriteLine($"Row {row} full");
                            break;
                        }
                        if (lowerCell > 0 && matrix[row][lowerCell] == 0)       // if cell is inside of the row
                        {                                                       // and free
                            matrix[row][lowerCell] = 1;
                            steps += lowerCell;
                            Console.WriteLine(steps);
                            break;
                        }
                        if (upperCell < columns && matrix[row][upperCell] == 0) // if cell is inside of the row
                        {                                                        // and is free
                            matrix[row][upperCell] = 1;
                            steps += upperCell;
                            Console.WriteLine(steps);
                            break;
                        }
                        cnt++;
                    }
                }
            }
        }
    }
}