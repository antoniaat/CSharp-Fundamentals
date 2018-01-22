namespace _01_ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseNumbers
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var numbers = new Stack<int>();

            for (var i = 0; i < input.Count(); i++)
            {
                numbers.Push(input[i]);
            }

            for (var i = 0; i < input.Count(); i++)
            {
                Console.Write(numbers.Pop() + " ");
            }
        }
    }
}