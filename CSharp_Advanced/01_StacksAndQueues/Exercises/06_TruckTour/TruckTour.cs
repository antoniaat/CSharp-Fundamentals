namespace _06_TruckTour
{
    using System;
    using System.Linq;

    public class TruckTour
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var pairOfIntegers = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                var amountOfPetrol = pairOfIntegers[0];
                var distance = pairOfIntegers[1];


            }


        }
    }
}
