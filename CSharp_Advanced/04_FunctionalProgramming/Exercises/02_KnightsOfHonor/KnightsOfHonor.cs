namespace _02_KnightsOfHonor
{
    using System;
    using System.Linq;

    public class KnightsOfHonor
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<string> print = (x) => Console.WriteLine(x);

            foreach (var item in input)
            {
                print($"Sir {item}");
            }
        }
    }
}
