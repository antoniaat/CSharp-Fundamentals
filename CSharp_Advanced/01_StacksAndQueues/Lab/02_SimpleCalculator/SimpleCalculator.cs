namespace _02_SimpleCalculator
{
    using System;
    using System.Linq;

    public class SimpleCalculator
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var sum = 0;

            for (var i = 0; i < input.Count; i++)
            {
                if (i == 0)
                {
                    sum += int.Parse(input[i]);
                }
                else if (i % 2 != 0)
                {
                    if (input[i].Trim() == "+")
                    {
                        sum += int.Parse(input[i+1]);
                    }
                    else if (input[i].Trim() == "-")
                    {
                        sum -= int.Parse(input[i+1]);
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
