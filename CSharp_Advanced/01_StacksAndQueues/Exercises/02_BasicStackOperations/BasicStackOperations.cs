namespace _02_BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicStackOperations
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var n = input[0];
            var s = input[1];
            var x = input[2];

            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var numbersStack = new Stack<int>();

            PushNumbers(numbersStack, n, numbers);
            PopNumbers(numbersStack, s);
            PrintResult(numbersStack, x);
        }

        public static void PushNumbers(Stack<int> numbersStack, int n, int[] numbers)
        {
            for (var i = 0; i < n; i++)
            {
                numbersStack.Push(numbers[i]);
            }
        }

        public static void PopNumbers(Stack<int> numbersStack, int s)
        {
            for (var i = 0; i < s; i++)
            {
                numbersStack.Pop();
            }
        }

        public static void PrintResult(Stack<int> numbersStack, int x)
        {
            if (numbersStack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (numbersStack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numbersStack.Min());
            }
        }
    }
}
