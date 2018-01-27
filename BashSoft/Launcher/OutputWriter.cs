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

        }
        public static void WriteEmptyLine()
        {

        }
        public static void DisplayException(string message)
        {

        }
    }
}
