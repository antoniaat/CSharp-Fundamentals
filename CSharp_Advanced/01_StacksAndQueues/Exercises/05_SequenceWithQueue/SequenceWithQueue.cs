namespace _05_SequenceWithQueue
{
    using System;
    using System.Collections.Generic;

    public class SequenceWithQueue
    {
        public static void Main()
        {
            var n = long.Parse(Console.ReadLine());
            var seq = new List<long>();
            var s1 = n;
            seq.Add(s1);

            for (var i = 0; i < 50; i++)
            {
                var s2 = seq[i] + 1;
                var s3 = 2 * seq[i] + 1;
                var s4 = seq[i] + 2;

                seq.Add(s2);
                if (seq.Count == 50) break;
                seq.Add(s3);
                if (seq.Count == 50) break;
                seq.Add(s4);
                if (seq.Count == 50) break;
            }

            Console.WriteLine(string.Join(" ", seq));
        }
    }
}