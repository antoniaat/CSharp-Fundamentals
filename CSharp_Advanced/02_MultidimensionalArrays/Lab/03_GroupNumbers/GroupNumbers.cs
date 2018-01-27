namespace _03_GroupNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GroupNumbers
    {
        public static void Main()
        {
            var inputNumbers = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var firstGroup = new List<int>();
            var secondGroup = new List<int>();
            var thirdGroup = new List<int>();
            GetNumbers(inputNumbers, firstGroup, secondGroup, thirdGroup);

            var jaggedArray = new int[3][];
            jaggedArray[0] = firstGroup.ToArray();
            jaggedArray[1] = secondGroup.ToArray();
            jaggedArray[2] = thirdGroup.ToArray();

            Console.WriteLine(string.Join(" ", jaggedArray[0]));
            Console.WriteLine(string.Join(" ", jaggedArray[1]));
            Console.WriteLine(string.Join(" ", jaggedArray[2]));
        }

        public static void GetNumbers(List<int> inputLine, List<int> firstGroup, List<int> secondGroup, List<int> thirdGroup)
        {
            foreach (var num in inputLine)
            {
                var plusNum = num < 0 ? Math.Abs(num) : num;

                switch (plusNum % 3)
                {
                    case 0:
                        firstGroup.Add(num);
                        break;
                    case 1:
                        secondGroup.Add(num);
                        break;
                    case 2:
                        thirdGroup.Add(num);
                        break;
                }
            }
        }
    }
}
