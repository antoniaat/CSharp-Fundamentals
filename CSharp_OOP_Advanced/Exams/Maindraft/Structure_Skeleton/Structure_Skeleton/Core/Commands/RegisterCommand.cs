using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    private readonly IHarvesterController harvesterController;

    private readonly IProviderController providerController;

    public RegisterCommand(IList<string> args, IHarvesterController harvesterController, IProviderController providerController)
        : base(args)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var entityType = this.Arguments[0];

        string result = null;
        switch (entityType)
        {
            case nameof(Harvester):
                result = this.harvesterController.Register(this.Arguments.Skip(1).ToList());
                break;

            case nameof(Provider):
                result = this.providerController.Register(this.Arguments.Skip(1).ToList());
                break;
        }

        return result;
    }
}