namespace Logger.Interfaces
{
    public interface IAppender : ILevealble
    {
        void Append(IError error);

        ILayout Layout { get; }
    }
}