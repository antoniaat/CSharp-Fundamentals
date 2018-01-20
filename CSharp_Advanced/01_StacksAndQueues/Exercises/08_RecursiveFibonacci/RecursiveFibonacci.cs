namespace _08_RecursiveFibonacci
{
    using System;

    public class RecursiveFibonacci
    {
        static long[] numbers;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            numbers = new long[n + 1];
            Console.WriteLine(recursiveFibonacci(n));
        }

        private static long recursiveFibonacci(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            if (numbers[n] != 0)
            {
                return numbers[n];
            }

            numbers[n] =
                recursiveFibonacci(n - 1) +
                recursiveFibonacci(n - 2);
            return numbers[n];
        }
    }
}
