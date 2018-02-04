namespace _04_FindEvensOrOdds
{
    using System;
    using System.Linq;

    public class FindEvensOrOdds
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var minNumber = input[0];
            var maxNumber = input[1];

            var command = Console.ReadLine();
            Predicate<int> isEven = a => a % 2 == 0;

            for (var num = minNumber; num <= maxNumber; num++)
            {
                if (command == "even")
                {
                    if (isEven(num)) Console.Write($"{num} ");
                }
                    
                else if (command == "odd")
                {
                    if (!isEven(num)) Console.Write($"{num} ");
                }
            }
        }
    }
}
