namespace ForumSystem.App.Controllers.Contracts
{
    public interface IReadUserInfoController
    {
        void ReadUsername();

        void ReadPassword();

        string Username { get; }
    }
}
