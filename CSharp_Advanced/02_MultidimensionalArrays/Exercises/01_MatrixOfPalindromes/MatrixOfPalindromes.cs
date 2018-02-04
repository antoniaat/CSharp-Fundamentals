namespace _01_MatrixOfPalindromes
{
    using System;
    using System.Linq;

    public class MatrixOfPalindromes
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = inputLine[0];
            var columns = inputLine[1];
            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            var intMatrix = new string[rows, columns];

            CreateMatrix(intMatrix, rows, columns, alphabet);
            PrintMatrix(intMatrix, rows, columns);
        }

        private static void CreateMatrix(string[,] intMatrix, int rows, int columns, char[] alphabet)
        {
            for (var row = 0; row < rows; row++)
            {
                for (var cols = 0; cols < columns; cols++)
                {
                    var curentString = $"{alphabet[row]}{alphabet[row + cols]}{alphabet[row]}";

                    if (IsPalindrome(curentString))
                    {
                        intMatrix[row, cols] = curentString;
                    }
                }
            }
        }

        public static bool IsPalindrome(string myString)
        {
            var first = myString.Substring(0, myString.Length / 2);
            var arr = myString.ToCharArray();
            Array.Reverse(arr);
            var temp = new string(arr);
            var second = temp.Substring(0, temp.Length / 2);
            return first.Equals(second);
        }

        private static void PrintMatrix(string[,] intMatrix, int rows, int columns)
        {
            for (var row = 0; row < rows; row++)
            {
                for (var cols = 0; cols < columns; cols++)
                {
                    Console.Write($"{intMatrix[row, cols]} ");
                }
                Console.WriteLine();
            }
        }
    }
}