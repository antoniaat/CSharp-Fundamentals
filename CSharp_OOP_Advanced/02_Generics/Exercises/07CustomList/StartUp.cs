using System;

public class StartUp
{
    public static Box<string> box = new Box<string>();

    public static void Main()
    {
        string inputLine;
        while ((inputLine = Console.ReadLine()) != "END")
        {
            DispatchCommander(inputLine);
        }
    }

    private static void DispatchCommander(string inputLine)
    {
        var args = inputLine.Split();

        switch (args[0])
        {
            case "Add":
                box.Add(args[1]);
                break;

            case "Remove":
                box.Remove(args[1]);
                break;

            case "Contains":
                Console.WriteLine(box.Contain(args[1]));
                break;

            case "Swap":
                box.Swap(int.Parse(args[1]), int.Parse(args[2]));
                break;

            case "Greater":
                Console.WriteLine(box.CountGreaterThan(args[1]));
                break;

            case "Max":
                Console.WriteLine(box.Max());
                break;

            case "Min":
                Console.WriteLine(box.Min());
                break;

            case "Sort":
                box.Sort();
                break;

            case "Print":
                Console.WriteLine(box.ToString());
                break;
        }
    }
}