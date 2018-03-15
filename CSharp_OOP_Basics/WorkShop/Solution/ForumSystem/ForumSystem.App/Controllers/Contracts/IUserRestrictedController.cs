namespace ForumSystem.App.Controllers.Contracts
{
    public interface IUserRestrictedController
    {
        bool LoggedInUser { get; }

        void UserLogIn();

        void UserLogOut();
    }
}
