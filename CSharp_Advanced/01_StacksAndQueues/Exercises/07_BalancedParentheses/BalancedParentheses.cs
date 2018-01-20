namespace _07_BalancedParentheses
{
    using System;
    using System.Linq;

    public class BalancedParentheses
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var result = false;

            for (var i = 0; i < input.Length; i++)
            {
                if (input.First() == '[')
                {
                    if (input.Last() == ']')
                    {
                        result = true;
                        input = input.Remove(0, 1);
                        input = input.Remove(input.Length - 1);
                        continue;
                    }
                    result = false;
                }

                if (input.First() == '{')
                {
                    if (input.Last() == '}')
                    {
                        result = true;
                        input = input.Remove(0, 1);
                        input = input.Remove(input.Length - 1);
                        continue;
                    }
                    result = false;
                }

                if (input.First() == '(')
                {
                    if (input.Last() == ')')
                    {
                        result = true;
                        input = input.Remove(0, 1);
                        input = input.Remove(input.Length - 1);
                        continue;
                    }
                    result = false;
                }
            }

            Console.WriteLine(result ? "YES" : "NO");
        }
    }
}
