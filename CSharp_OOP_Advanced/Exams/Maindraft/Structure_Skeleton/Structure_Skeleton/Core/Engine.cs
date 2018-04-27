using System.Linq;

public class Engine
{
    private readonly ICommandInterpreter commandInterpreter;

    private readonly IWriter writer;

    private readonly IReader reader;

    public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
    {
        this.commandInterpreter = commandInterpreter;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        while (true)
        {
            var inputArgs = reader.ReadLine().Split().ToList();
            var result = commandInterpreter.ProcessCommand(inputArgs);

            writer.WriteLine(result);

            if (inputArgs[0] == "Shutdown")
                break;
        }
    }
}