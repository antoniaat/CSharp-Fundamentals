namespace _04_AddVAT
{
    using System;
    using System.Linq;

    public class AddVAT
    {
        public static void Main()
        {
            Console.ReadLine()
                ?.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(d => d += (d * 20) / 100)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x:f2}"));
        }
    }
}