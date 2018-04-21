using System.Collections.Generic;

public abstract class Command : ICommand
{
    protected Command(IList<string> args)
    {
        this.Arguments = args;
    }

    public IList<string> Arguments { get; protected set; }

    public abstract string Execute();
}