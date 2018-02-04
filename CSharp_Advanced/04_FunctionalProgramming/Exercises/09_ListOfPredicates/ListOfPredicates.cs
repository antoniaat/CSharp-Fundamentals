namespace _09_ListOfPredicates
{
    using System;
    using System.Linq;

    public class ListOfPredicates
    {
        public static void Main()
        {
            var n = long.Parse(Console.ReadLine());
            var dividers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();

            for (var i = 1; i <= n; i++)
            {
                var isDivisible = false;

                foreach (var divider in dividers)
                {
                    isDivisible = i % divider == 0;
                }

                if(isDivisible) Console.Write($"{i} ");
            } 
        }
    }
}
