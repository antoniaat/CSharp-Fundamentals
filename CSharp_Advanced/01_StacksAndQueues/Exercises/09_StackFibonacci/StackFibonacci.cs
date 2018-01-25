namespace _09_StackFibonacci
{
    using System;
    using System.Collections.Generic;

    public class StackFibonacci
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var fibNumbers = new Stack<ulong>();
            fibNumbers.Push(1);
            fibNumbers.Push(1);

            for (var i = 1; i < n; i++)
            {
                var first = fibNumbers.Pop();
                var second = fibNumbers.Pop();

                fibNumbers.Push(first);
                fibNumbers.Push(first + second);
            }

            fibNumbers.Pop();
            Console.WriteLine(fibNumbers.Peek());
        }
    }
}