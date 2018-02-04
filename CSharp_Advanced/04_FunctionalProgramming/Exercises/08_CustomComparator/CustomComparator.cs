namespace _08_CustomComparator
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class CustomComparator
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var sortedNumbers = new List<int>();
            sortedNumbers.AddRange(numbers.Where(x => x % 2 == 0).OrderBy(x => x));
            sortedNumbers.AddRange(numbers.Where(x => x % 2 != 0).OrderBy(x => x));
            Console.WriteLine(string.Join(" ", sortedNumbers));
        }
    }
}
