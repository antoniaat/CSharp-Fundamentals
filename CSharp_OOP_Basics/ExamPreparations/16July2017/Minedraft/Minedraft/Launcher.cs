namespace Minedraft
{
    public class Launcher
    {
        public static void Main()
        {
            var manager = new DraftManager();
            var engine = new Engine(manager);
            engine.Run();
        }
    }
}
