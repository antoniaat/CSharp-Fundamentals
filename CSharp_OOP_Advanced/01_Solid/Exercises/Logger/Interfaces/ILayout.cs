namespace Logger.Interfaces
{
    public interface ILayout
    {
        string FormatError(IError error);
    }
}