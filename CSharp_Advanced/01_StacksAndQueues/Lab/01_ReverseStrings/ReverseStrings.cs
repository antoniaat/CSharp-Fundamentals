namespace _01_ReverseStrings
{
    using System;
    using System.Collections.Generic;

    public class ReverseStrings
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var stackString = new Stack<char>();

            foreach (char t in input)
            {
                stackString.Push(t);
            }

            Console.WriteLine(string.Join("", stackString));
        }
    }
}
