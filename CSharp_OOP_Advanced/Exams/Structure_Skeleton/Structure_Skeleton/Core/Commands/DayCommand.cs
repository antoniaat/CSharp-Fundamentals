using System;
using System.Collections.Generic;

public class DayCommand : Command
{
    private readonly IHarvesterController harvesterController;

    private readonly IProviderController providerController;

    public DayCommand(IList<string> args, IHarvesterController harvesterController, IProviderController providerController)
        : base(args)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var providerResult = this.providerController.Produce();
        var harvestersResult = this.harvesterController.Produce();

        return providerResult + Environment.NewLine + harvestersResult;
    }
}