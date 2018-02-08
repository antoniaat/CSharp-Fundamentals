using System;

namespace Launcher
{
    public static class OutputWriter
    {
        public static void WriteMessage(string message)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }

        public static void WriteMessageOnNewLine(string message)
        {
            Console.WriteLine(message);
        }
        public static void WriteEmptyLine()
        {
            Console.WriteLine();
        }
        public static void DisplayException(string message)
        {
            Console.WriteLine(message);
        }
    }
}
