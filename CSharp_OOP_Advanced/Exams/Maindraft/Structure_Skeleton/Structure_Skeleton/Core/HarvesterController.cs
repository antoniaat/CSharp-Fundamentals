using System;
using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private string mode;

    private readonly IEnergyRepository energyRepository;

    private readonly IList<IHarvester> harvesters;

    private readonly IHarvesterFactory factory;

    public HarvesterController(IEnergyRepository energyRepository, IHarvesterFactory factory)
    {
        this.mode = Constants.DefaultMode;
        this.harvesters = new List<IHarvester>();
        this.energyRepository = energyRepository;
        this.factory = factory;
    }

    public double OreProduced { get; private set; }

    public IReadOnlyCollection<IEntity> Entities => (IReadOnlyCollection<IEntity>)this.harvesters;

    public string Register(IList<string> args)
    {
        var harvester = this.factory.GenerateHarvester(args);
        this.harvesters.Add(harvester);

        return string.Format(Constants.SuccessfullRegistration, harvester.GetType().Name);
    }

    public string Produce()
    {
        double neededEnergy = 0;

        foreach (var harvester in this.harvesters)
        {
            switch (this.mode)
            {
                case Constants.DefaultMode:
                    neededEnergy += harvester.EnergyRequirement;
                    break;

                case Constants.HalfMode:
                    neededEnergy += harvester.EnergyRequirement * 50 / 100;
                    break;

                case Constants.EnergyMode:
                    neededEnergy += harvester.EnergyRequirement * 20 / 100;
                    break;
            }
        }

        // Check if we can mine
        double minedOres = 0;
        if (this.energyRepository.TakeEnergy(neededEnergy))
        {
            minedOres += this.harvesters.Sum(harvester => harvester.Produce());
        }

        // Take the mode in mind
        switch (this.mode)
        {
            case Constants.EnergyMode:
                minedOres = minedOres * 20 / 100;
                break;

            case Constants.HalfMode:
                minedOres = minedOres * 50 / 100;
                break;
        }

        this.OreProduced += minedOres;

        return string.Format(Constants.PlumbusOreMinedMessage, minedOres);
    }

    public string ChangeMode(string currentMode)
    {
        this.mode = currentMode;

        var reminder = new List<IHarvester>();

        foreach (var harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch (Exception)
            {
                reminder.Add(harvester);
            }
        }

        foreach (var entity in reminder)
        {
            this.harvesters.Remove(entity);
        }

        return string.Format(Constants.ChangedModeMessage, currentMode);
    }
}