namespace _05_HotPotato
{
    using System;
    using System.Collections.Generic;

    public class HotPotato
    {
        public static void Main()
        {
            var children = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var toss = int.Parse(Console.ReadLine());
            var queue = new Queue<string>(children);

            while (queue.Count != 1)
            {
                for (var tossCounter = 1; tossCounter < toss; tossCounter++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
