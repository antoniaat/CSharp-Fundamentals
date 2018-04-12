using System;
using System.Linq;

public class Launcher
{
    public static Stack<int> stack = new Stack<int>();

    public static void Main()
    {
        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            var tokens = command.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            DispatchCommands(tokens);
        }

        PrintStack();
    }

    private static void PrintStack()
    {
        for (int i = 0; i < 2; i++)
        {
            foreach (var num in stack.Reverse())
            {
                if (num != 0)
                    Console.WriteLine(num);
            }
        }
    }

    private static void DispatchCommands(string[] tokens)
    {
        if (tokens[0] == "Push")
        {
            for (int i = 1; i < tokens.Length; i++)
            {
                stack.Push(int.Parse(tokens[i]));
            }
        }
        else if (tokens[0] == "Pop")
        {
            try
            {
                stack.Pop();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}