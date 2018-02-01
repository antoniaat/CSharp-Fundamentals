namespace _03_CountUppercaseWords
{
    using System;
    using System.Linq;

    public class CountUppercaseWords
    {
        public static void Main()
        {
            Console.ReadLine()
                ?.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => char.IsUpper(x.First()))
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}