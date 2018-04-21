using System.Collections.Generic;

public class RepairCommand : Command
{
    private readonly IProviderController providerController;

    public RepairCommand(IList<string> args, IProviderController providerController)
        : base(args)
    {
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var value = double.Parse(this.Arguments[1]);
        var result = this.providerController.Repair(value);
        return result;
    }
}