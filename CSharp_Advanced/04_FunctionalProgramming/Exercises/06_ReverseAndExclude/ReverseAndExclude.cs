namespace _06_ReverseAndExclude
{
    using System;
    using System.Linq;

    public class ReverseAndExclude
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var divider = int.Parse(Console.ReadLine());
            numbers.Where(num => num % divider != 0).Reverse().ToList().ForEach(x => Console.Write($"{x} "));
        }
    }
}
