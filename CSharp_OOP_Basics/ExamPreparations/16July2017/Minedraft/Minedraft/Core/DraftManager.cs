using Minedraft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private double totalEnergyStored;

    private double totalOreMined;

    private string currentMode;

    private readonly Dictionary<string, BaseModel> modelsById;

    private readonly Dictionary<string, Harvester> harvestersById;

    private readonly Dictionary<string, Provider> providersById;

    private readonly HarvesterFactory harvesterFactory;

    private readonly ProviderFactory providerFactory;

    public DraftManager()
    {
        this.currentMode = "Full";
        this.modelsById = new Dictionary<string, BaseModel>();
        this.harvestersById = new Dictionary<string, Harvester>();
        this.providersById = new Dictionary<string, Provider>();
        this.harvesterFactory = new HarvesterFactory();
        this.providerFactory = new ProviderFactory();
    }

    private double GetTotalRequiredEnergy()
    {
        double totalEnergyRequirement = 0;

        if (this.currentMode == "Full")
        {
            totalEnergyRequirement = this.harvestersById.Values.Sum(x => x.EnergyRequirement);
        }
        else if (this.currentMode == "Half")
        {
            totalEnergyRequirement = ((this.harvestersById.Values.Sum(x => x.EnergyRequirement)
                * 60) / 100);
        }

        return totalEnergyRequirement;
    }

    private double GetTotalOreOutput(double totalEnergyRequirement)
    {
        double totalOreOutput = 0;

        if (totalEnergyRequirement <= this.totalEnergyStored)
        {
            totalOreOutput = this.harvestersById.Values.Sum(x => x.OreOutput);

            if (this.currentMode == "Half")
            {
                totalOreOutput = ((totalOreOutput * 50) / 100);
            }
            else if (this.currentMode == "Energy")
            {
                totalOreOutput = 0;
            }
        }

        if (totalOreOutput > 0)
        {
            this.totalEnergyStored -= totalEnergyRequirement;
        }

        return totalOreOutput;
    }

    private void AddModel(BaseModel model)
    {
        this.modelsById.Add(model.Id, model);
    }

    public string RegisterHarvester(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double oreOutput = double.Parse(arguments[2]);
        double energyRequirement = double.Parse(arguments[3]);
        int sonicFactor = arguments.Count > 4 ? int.Parse(arguments[4]) : 0;

        Harvester newHarvester = null;

        try
        {
            newHarvester = this.harvesterFactory.ProduceHarvester(type, id, oreOutput, energyRequirement, sonicFactor);
        }
        catch (ArgumentException e)
        {
            string origin = e.TargetSite.Name.Replace("set_", "");
            return string.Format(Constants.RegisterHarvesterFailureMessage, origin);
        }

        this.harvestersById.Add(newHarvester.Id, newHarvester);
        this.AddModel(newHarvester);
        return string.Format(Constants.RegisterHarvesterSuccessMessage, newHarvester.GetType().Name.Replace("Harvester", ""), newHarvester.Id);
    }

    public string RegisterProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double energyOutput = double.Parse(arguments[2]);

        Provider newProvider = null;

        try
        {
            newProvider = this.providerFactory.ProduceProvider(type, id, energyOutput);
        }
        catch (ArgumentException e)
        {
            string origin = e.TargetSite.Name.Replace("set_", "");
            return string.Format(Constants.RegisterProviderFailureMessage, origin);
        }

        this.providersById.Add(newProvider.Id, newProvider);
        this.AddModel(newProvider);
        return string.Format(Constants.RegisterProviderSuccessMessage, newProvider.GetType().Name.Replace("Provider", ""), newProvider.Id);
    }

    public string Day()
    {
        double summedEnergyOutput = this.providersById.Values.Sum(x => x.EnergyOutput);
        this.totalEnergyStored += summedEnergyOutput;

        double totalRequiredEnergy = this.GetTotalRequiredEnergy();
        double summedOreOutput = this.GetTotalOreOutput(totalRequiredEnergy);
        this.totalOreMined += summedOreOutput;

        StringBuilder result =
            new StringBuilder()
                .AppendLine("A day has passed.")
                .AppendLine("Energy Provided: " + summedEnergyOutput)
                .Append("Plumbus Ore Mined: " + summedOreOutput);

        return result.ToString();
    }

    public string Mode(List<string> arguments)
    {
        string mode = arguments[0];
        this.currentMode = mode;

        return string.Format(Constants.ChangeModeMessage, this.currentMode);
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];
        string result = this.modelsById.ContainsKey(id)
                ? this.modelsById[id].ToString()
                : string.Format(Constants.CheckNotFoundMessage, id);

        return result;
    }

    public string ShutDown()
    {
        StringBuilder result =
            new StringBuilder()
            .AppendLine("System Shutdown")
            .AppendLine("Total Energy Stored: " + this.totalEnergyStored)
            .Append("Total Mined Plumbus Ore: " + this.totalOreMined);

        return result.ToString();
    }
}