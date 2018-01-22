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

            if (input != null)
                for (var i = 0; i < input.Length; i++)
                {
                    if (input.Length % 2 == 0)
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
                        else if (input.First() == '{')
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
                        else if (input.First() == '(')
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
                    else
                    {
                        result = false;
                    }
                }

            Console.WriteLine(result ? "YES" : "NO");
        }
    }
}