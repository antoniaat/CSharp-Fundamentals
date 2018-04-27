public class Program
{
    public static void Main()
    {
        IEnergyRepository energyRepository = new EnergyRepository();

        IHarvesterFactory harvesterFactory = new HarvesterFactory();
        IHarvesterController harvesterController = new HarvesterController(energyRepository, harvesterFactory);
        IProviderController providerController = new ProviderController(energyRepository);

        ICommandInterpreter commandInterpreter = new CommandInterpreter(harvesterController, providerController);
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        Engine engine = new Engine(commandInterpreter, reader, writer);
        engine.Run();
    }
}