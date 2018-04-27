using System.Collections.Generic;

public class ModeCommand : Command
{
    private readonly IHarvesterController harvesterController;

    public ModeCommand(IList<string> args, IHarvesterController harvesterController)
        : base(args)
    {
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        var mode = this.Arguments[0];

        return
            this.harvesterController.ChangeMode(mode);
    }
}