namespace _06_TrafficJam
{
    using System;
    using System.Collections.Generic;

    public class TrafficJam
    {
        public static void Main()
        {
            var numberOfCars = int.Parse(Console.ReadLine());
            var inputLine = Console.ReadLine();
            var vechicles = new Queue<string>();
            var sumCountOfCars = 0;

            while (inputLine != "end")
            {
                if (inputLine != "green")
                    vechicles.Enqueue(inputLine);

                if (inputLine == "green")
                {
                    if (numberOfCars > vechicles.Count)
                    {
                        for (var i = 0; i < vechicles.Count; i++)
                        {
                            Console.WriteLine($"{vechicles.Dequeue()} passed!");
                            sumCountOfCars++;
                            i--;
                        }
                    }
                    else
                    {
                        for (var i = 0; i < numberOfCars; i++)
                        {
                            Console.WriteLine($"{vechicles.Dequeue()} passed!");
                            sumCountOfCars++;
                        }
                    }
                }

                inputLine = Console.ReadLine();
            }

            Console.WriteLine($"{sumCountOfCars} cars passed the crossroads.");
        }
    }
}
