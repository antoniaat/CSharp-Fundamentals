using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _01_Regeh
{
    using System;

    public class Regeh
    {
        public  static void Main()
        {
            var inputLine = Console.ReadLine();
            var regex = Regex.Matches(inputLine, @"(\[[a-zA-Z]+<(\d+)REGEH(\d+)>[a-zA-Z]+\])");
            var extractNumbers = new List<int>();
            var result = new StringBuilder();

            foreach (Match matches in regex)
            {
                var firstNum = int.Parse(matches.Groups[2].ToString());
                var secondNum = int.Parse(matches.Groups[3].ToString());
                extractNumbers.Add(firstNum);
                extractNumbers.Add(secondNum);
            }

            var index = 0;

            foreach (var num in extractNumbers)
            {
                index += num;
                if (index > inputLine.Length) index = index - inputLine.Length + 1;
                result.Append(inputLine[index]);
            }

            Console.WriteLine(result.ToString());
        }
    }
}
