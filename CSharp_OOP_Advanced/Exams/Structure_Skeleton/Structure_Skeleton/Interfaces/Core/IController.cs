using System.Collections.Generic;

public interface IController
{
    string Register(IList<string> args);

    string Produce();

    IReadOnlyCollection<IEntity> Entities { get; }
}