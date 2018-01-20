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
            var beforeLastOperation = string.Empty;

            for (var i = 0; i < operationsNumber; i++)
            {
                var command = Console.ReadLine();

                if (command == "4")
                {
                    sb.Clear();
                    sb.Append(beforeLastOperation);
                }
                else
                {
                    var commandLineArray = command
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    var operationNum = int.Parse(commandLineArray[0]);

                    if (operationNum == 1)
                    {
                        beforeLastOperation = sb.ToString();
                        FirstOperation(commandLineArray, sb);
                    }
                    else if (operationNum == 2)
                    {
                        beforeLastOperation = sb.ToString();
                        SecondOperation(commandLineArray, sb);
                    }
                    else if (operationNum == 3)
                    {
                        ThirdOperation(commandLineArray, sb);
                    }
                }
            }
        }

        public static void UndoesTheLastCommand(string command, StringBuilder sb)
        {

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
