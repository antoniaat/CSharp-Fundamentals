public class StartUp
{
    private static readonly IReader reader = new ConsoleReader();
    private static readonly IWriter writer = new ConsoleWriter();

    public static void Main()
    {
        var manager = new StorageMaster.Core.StorageMaster();
        var engine = new Engine(reader, writer);
        engine.Run();
    }
}