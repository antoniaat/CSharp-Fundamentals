namespace _03.Word_Count
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class WordCount
    {
        public static void Main()
        {
            var wordsCount = new Dictionary<string, int>();

            using (var reader = new StreamReader("words.txt"))
            {
                while (true)
                {
                    var word = reader.ReadLine();
                    if (word == null) break;

                    word = word.ToLower();

                    if (!wordsCount.ContainsKey(word)) wordsCount[word] = 0;
                }
            }

            using (var reader = new StreamReader("text.txt"))
            {
                while (true)
                {
                    var line = reader.ReadLine();

                    if (line == null) break;

                    var currentWords = line
                        .Split(" .,?!:;-[]{}()".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.ToLower())
                        .ToArray();

                    foreach (var word in currentWords)
                    {
                        if (wordsCount.ContainsKey(word)) wordsCount[word]++;
                    }
                }
            }

            using (var writer = new StreamWriter("result.txt"))
            {
                var result = wordsCount
                    .OrderByDescending(w => w.Value)
                    .Select(w => $"{w.Key} - {w.Value}");

                foreach (var res in result)
                {
                    writer.WriteLine(res);
                }
            }
        }
    }
}