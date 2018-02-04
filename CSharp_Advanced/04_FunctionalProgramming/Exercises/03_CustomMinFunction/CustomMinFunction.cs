namespace _03_CustomMinFunction
{
    using System;
    using System.Linq;

    public class CustomMinFunction
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Func<string, int> nums = x => int.Parse(x);
            var bestNum = int.MaxValue;

            foreach (var str in numbers)
            {
                var currentNum = nums(str);
                if (currentNum < bestNum)
                {
                    bestNum = currentNum;
                }
            }

            Console.WriteLine(bestNum);
        }
    }
}
