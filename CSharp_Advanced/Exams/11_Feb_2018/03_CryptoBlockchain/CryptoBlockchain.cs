namespace _03_CryptoBlockchain
{
    //The Crypto Blockchain is a special sequence of characters, which is comprised of several lines.Each line is always 16 characters long. Inside these lines, there are several Crypto Blocks and some garbage data around them.

    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class CryptoBlockchain
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
                    var currentMatch = matches.Groups[2].ToString();
                    AppendResult(currentMatch, result, lenght);
                }
            }

            Console.WriteLine(result.ToString());
        }

        public static void AppendResult(string matches, StringBuilder result, int lenght)
        {
            var digitRegex = Regex.Match(matches, @"\d+");

            var k = 0;
            var output = digitRegex.ToString()
                .ToLookup(c => Math.Floor(k++ / (double)3))
                .Select(e => new string(e.ToArray()))
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
