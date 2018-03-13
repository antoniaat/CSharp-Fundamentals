using System;
using System.Collections.Generic;
using System.Linq;

public class DraftManager
{
    //TODO: FIX EVERYTHING!!!

    List<Harvester> harvesters = new List<Harvester>();
    List<Provider> providers = new List<Provider>();

    public string RegisterHarvester(List<string> arguments)
    {
        string message;

        var type = arguments[1];
        var id = arguments[2];
        var oreOutput = double.Parse(arguments[3]);
        var energyRequirement = double.Parse(arguments[4]);

        try
        {
            if (type == "Sonic")
            {
                var sonicFactor = double.Parse(arguments[5]);
                harvesters.Add(new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor));
            }

            else if (type == "Hammer")
            {
                harvesters.Add(new HammerHarvester(id, oreOutput, energyRequirement));
            }

            message = $"Successfully registered {type} Harvester – {id}";
        }
        catch (Exception e)
        {
            string propertyName = e.TargetSite.Name.Replace("set_", "");
            message = $"Harvester is not registered, because of it's {propertyName}";
        }

        return message;
    }

    public string RegisterProvider(List<string> arguments)
    {
        var type = arguments[1];
        var id = arguments[2];
        var energyOutput = double.Parse(arguments[3]);

        string message;
        try
        {
            if (type == "Solar")
            {
                providers.Add(new SolarProvider(id, energyOutput));
            }

            else if (type == "Pressure")
            {
                providers.Add(new PressureProvider(id, energyOutput));
            }

            message = $"Successfully registered {type} Provider – {id}";
        }
        catch (Exception ex)
        {
            string propertyName = ex.TargetSite.Name.Replace("set_", "");
            message = $"Provider is not registered, because of it's {propertyName}";
        }

        return message;
    }

    string Day()
    {
        return ";";
    }

    public string Mode(List<string> arguments)
    {
        var mode = arguments[1];

        if (mode == "Full" ) // || mode == "Energy"
        {

        }

        else if (mode == "Half")
        {

        }

        return $"Successfully changed working mode to {mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[1];

        var provider = providers.FirstOrDefault(x => x.Id == id);
        var harvester = harvesters.FirstOrDefault(x => x.Id == id);

        string message;
        if (provider != null) message = $"{provider.GetType()} Provider – {provider.Id}";
        else if (harvester != null) message = $"{harvester.GetType()} Provider – {harvester.Id}";
        else message = $"No element found with id – {id}";
           
        return message;
    }

    public string ShutDown()
    {
        return "System Shutdown";
    }
}
