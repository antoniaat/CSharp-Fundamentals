using System;

public class StartUp
{
    public static ListyIterator<string> List = new ListyIterator<string>();

    public static void Main()
    {
        string inputLine;
        while ((inputLine = Console.ReadLine()) != "END")
        {
            var tokens = inputLine?.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);
            DispatchCommands(tokens);
        }
    }

    private static void DispatchCommands(string[] tokens)
    {
        if (tokens[0] == "Create")
        {
            List.Create(tokens);
        }

        else if (tokens[0] == "Move")
        {
            Console.WriteLine(List.MoveNext());
        }
            
        else if (tokens[0] == "Print")
        {
            try
            {
                Console.WriteLine(List.Print());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        else if (tokens[0] == "HasNext")
        {
            Console.WriteLine(List.HasNext());
        }
    }
}