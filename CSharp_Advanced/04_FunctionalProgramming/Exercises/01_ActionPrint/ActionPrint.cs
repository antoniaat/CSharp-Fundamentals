namespace _01_ActionPrint
{
    using System;
    using System.Linq;

    public class ActionPrint
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<string> print = (x) => Console.WriteLine(x);

            foreach (var item in input)
            {
                print(item);
            }
        }
    }
}
