namespace _10_SimpleTextEditor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SimpleTextEditor
    {
        public static void Main()
        {
            var sb = new StringBuilder();
            var operationsNumber = int.Parse(Console.ReadLine());
            var undonedOperations = new List<string>();

            for (var operation = 0; operation < operationsNumber; operation++)
            {
                var command = Console.ReadLine().Trim();

                if (command == "4")
                {
                    var lastOperation = undonedOperations.Last()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    if (lastOperation[0] == "1")
                    {
                        for (var j = 0; j < lastOperation[1].Length; j++)
                        {
                            sb.Remove(sb.Length - 1, 1);
                        }

                        undonedOperations.RemoveAt(undonedOperations.Count - 1);
                    }

                    else if (lastOperation[0] == "2")
                    {
                        sb.Append(lastOperation[1]);
                        undonedOperations.RemoveAt(undonedOperations.Count - 1);
                    }
                }

                else
                {
                    var commandLineArray = command
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    var operationNum = int.Parse(commandLineArray[0]);

                    if (operationNum == 1)
                    {
                        FirstOperation(commandLineArray, sb);
                        undonedOperations.Add(command);
                    }

                    else if (operationNum == 2)
                    {
                        var removedLetterStringBuilder = new StringBuilder();
                        var removedLetters = removedLetterStringBuilder.Append(sb); 
                        command = "2 " + removedLetters;
                        undonedOperations.Add(command);
                        SecondOperation(commandLineArray, sb);
                        removedLetterStringBuilder.Clear();
                    }

                    else if (operationNum == 3)
                    {
                        ThirdOperation(commandLineArray, sb);
                    }
                }
            }
        }

        public static void ThirdOperation(List<string> commandLineArray, StringBuilder sb)
        {
            var index = int.Parse(commandLineArray[1]);
            index--;
            Console.WriteLine(sb[index]);
        }

        public static void SecondOperation(List<string> commandLineArray, StringBuilder sb)
        {
            var count = int.Parse(commandLineArray[1]);

            for (var i = 0; i < count; i++)
            {
                sb.Remove(sb.Length - 1, 1);
            }
        }

        public static void FirstOperation(List<string> commandLineArray, StringBuilder sb)
        {
            var text = commandLineArray[1];
            sb.Append(text);
        }
    }
}