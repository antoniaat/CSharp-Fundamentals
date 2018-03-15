namespace ForumSystem.App.UserInterface.Contracts
{
    using ForumSystem.App;

    public interface ILabel : IPositionable
    {
        string Text { get; }

        bool IsHidden { get; }
    }
}