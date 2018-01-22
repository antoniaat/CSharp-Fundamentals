namespace _03_MaximumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaximumElement
    {
        public static void Main()
        {
            var numbersStack = new Stack<int>();
            var n = long.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var currentCommand = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                CheckType(currentCommand, numbersStack);
            }
        }

        public static void CheckType(List<int> currentCommand, Stack<int> numbersStack)
        {
            if (currentCommand[0] == 1)
            {
                var element = currentCommand[1];
                numbersStack.Push(element);
            }
            else if (currentCommand[0] == 2)
            {
                numbersStack.Pop();
            }
            else if (currentCommand[0] == 3)
            {
                Console.WriteLine(numbersStack.Max());
            }
        }
    }
}