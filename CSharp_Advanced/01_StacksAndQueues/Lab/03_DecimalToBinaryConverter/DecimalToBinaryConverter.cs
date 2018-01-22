namespace _03_DecimalToBinaryConverter
{
    using System;
    using System.Collections.Generic;

    public class DecimalToBinaryConverter
    {
        public static void Main()
        {
            var inputNumber = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            if (inputNumber == 0)
            {
                Console.WriteLine(0);
            }

            while (inputNumber != 0)
            {
                var reminder = inputNumber % 2;
                stack.Push(reminder);
                inputNumber /= 2;
            }

            while (stack.Count != 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
