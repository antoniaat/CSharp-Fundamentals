namespace _05_AppliedArithmetics
{
    using System;
    using System.Linq;

    public class AppliedArithmetics
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "add")
                    numbers = numbers.Select(x => x + 1).ToList();

                if(command == "multiply")
                    numbers = numbers.Select(x => x * 2).ToList();

                if (command == "subtract")
                    numbers = numbers.Select(x => x - 1).ToList();

                if (command == "print")
                    Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
