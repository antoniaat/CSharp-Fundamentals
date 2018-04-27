using System.Collections.Generic;
using System.Text;

public class ShutdownCommand : Command
{
    private readonly IHarvesterController harvesterController;

    private readonly IProviderController providerController;

    public ShutdownCommand(IList<string> args, IHarvesterController harvesterController, IProviderController providerController)
        : base(args)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        return new StringBuilder()
            .AppendLine(Constants.ShutDownMessage)
            .AppendLine(string.Format(Constants.TotalEnergyMessage, this.providerController.TotalEnergyProduced))
            .Append(string.Format(Constants.TotalMinedPlumbsMessage, this.harvesterController.OreProduced))
            .ToString();
    }
}