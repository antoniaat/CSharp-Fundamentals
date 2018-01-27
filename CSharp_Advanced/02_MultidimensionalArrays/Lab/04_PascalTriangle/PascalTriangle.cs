using System.Collections.Generic;
using System.Linq;

namespace _04_PascalTriangle
{
    using System;

    public class PascalTriangle
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var pascalTriangle = new long[n][];

            for (var cols = 0; cols < n; cols++)
            {
                pascalTriangle[cols] = new long[cols + 1];
            }

            for (var cols = 0; cols < n; cols++)
            {
                for (var index = 0; index < pascalTriangle[cols].Length; index++)
                {
                    if (index == 0 || index == pascalTriangle[cols].Length - 1)
                    {
                        pascalTriangle[cols][0] = 1;
                        pascalTriangle[cols][pascalTriangle[cols].Length - 1] = 1;
                    }
                    else
                    {
                        pascalTriangle[cols][index] = pascalTriangle[cols - 1][index - 1] + pascalTriangle[cols - 1][index];
                    }
                }
            }

            foreach (var index in pascalTriangle)
            {
                Console.WriteLine(string.Join(" ", index));
            }
        }
    }
}
