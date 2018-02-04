namespace _01.Odd_Lines
{
    using System;
    using System.IO;

    public class OddLines
    {
        public static void Main()
        {
            using (var reader = new StreamReader("words.txt"))
            {
                var numberLine = 0;

                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null) break;
                    if (numberLine % 2 != 0) Console.WriteLine($"Line {numberLine}: {line}");
                    numberLine++;
                }
            }
        }
    }
}