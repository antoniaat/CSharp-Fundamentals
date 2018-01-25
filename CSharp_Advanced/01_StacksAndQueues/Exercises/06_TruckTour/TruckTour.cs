namespace _06_TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TruckTour
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var queue = new Queue<int[]>();

            for (var i = 0; i < n; i++)
            {
                var pairOfIntegers = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                queue.Enqueue(pairOfIntegers);
            }

            for (var currentStart = 0; currentStart < n - 1; currentStart++)
            {
                var fuel = 0;
                var isSolution = true;

                for (var pumpsPassed = 0; pumpsPassed < n; pumpsPassed++)
                {
                    var currentPump = queue.Dequeue();
                    var amountOfPetrol = currentPump[0];
                    var distance = currentPump[1];

                    queue.Enqueue(currentPump);

                    fuel += amountOfPetrol - distance;

                    if (fuel < 0)
                    {
                        currentStart += pumpsPassed;
                        isSolution = false;
                        break;
                    }
                }

                if (isSolution)
                {
                    Console.WriteLine(currentStart);
                    Environment.Exit(0);
                }
            }
        }
    }
}