namespace JaggedArrayExample
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var matrix = new int[rows][];

            for (var row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }
        }
    }
}
