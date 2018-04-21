using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class HarvesterFactory : IHarvesterFactory
{
    public IHarvester GenerateHarvester(IList<string> args)
    {
        var type = args[0];

        var id = int.Parse(args[1]);
        var oreOutput = double.Parse(args[2]);
        var energyReq = double.Parse(args[3]);

        var currentType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == type + "Harvester");

        var ctors = currentType.GetConstructors(BindingFlags.Public | BindingFlags.Instance);

        var harvester = (IHarvester)ctors[0]
            .Invoke(new object[] { id, oreOutput, energyReq });

        return harvester;
    }
}