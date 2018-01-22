namespace _04_MatchingBrackets
{
    using System;
    using System.Collections.Generic;

    public class MatchingBrackets
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var stackOpenBracketsIndex = new Stack<int>();

            for (var counter = 0; counter < input.Length; counter++)
            {
                if (input[counter] == '(')
                {
                    stackOpenBracketsIndex.Push(counter);
                }
                if (input[counter] == ')')
                {
                    var openBracketIndex = stackOpenBracketsIndex.Pop();
                    var lenght = counter - openBracketIndex + 1;
                    Console.WriteLine(input.Substring(openBracketIndex, lenght));
                }
            }
        }
    }
}
