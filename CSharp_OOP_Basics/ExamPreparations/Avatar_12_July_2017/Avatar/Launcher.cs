public class Launcher
{
    public static void Main()
    {
        var nation = new NationsBuilder();
        var engine = new Engine(nation);
        engine.Run();
    }
}