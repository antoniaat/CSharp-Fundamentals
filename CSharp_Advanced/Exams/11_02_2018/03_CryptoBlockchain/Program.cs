namespace _03_CryptoBlockchain
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var rowsNumber = int.Parse(Console.ReadLine());
            var blockchain = new StringBuilder();
            var result = new StringBuilder();

            for (var i = 0; i < rowsNumber; i++)
            {
                var currentLine = Console.ReadLine().Trim();
                blockchain.Append(currentLine);
            }

            var regexOne = Regex.Matches(blockchain.ToString(), @"({|\[).*?(\d+).*?(}|\])"); 

            foreach (Match matches in regexOne)
            {
                if ((matches.Groups[1].ToString() == "{" && matches.Groups[3].ToString() == "}") || (matches.Groups[1].ToString() == "[" && matches.Groups[3].ToString() == "]"))
                {
                    var lenght = matches.ToString().Length;
                    string currentMatch = matches.Groups[2].ToString();
                    AppendResult(currentMatch, result, lenght);
                }
            }

            Console.WriteLine(result.ToString());
        }

        static void AppendResult(string matches, StringBuilder result, int lenght)
        {
            var digitRegex = Regex.Match(matches, @"\d+");

            double parts = 3;
            int k = 0;
            var output = digitRegex.ToString()
                .ToLookup(c => Math.Floor(k++ / parts))
                .Select(e => new String(e.ToArray()))
                .Select(int.Parse)
                .ToList();

            foreach (var symbol in output)
            {
                var currentChar = Convert.ToChar(symbol - lenght);
                result.Append(currentChar);
            }
        }
    }
}
