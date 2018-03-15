namespace ForumSystem.App.Controllers.Contracts
{
    using Enums;
    using UserInterface.Contracts;

    public interface IController
    {
        MenuState ExecuteCommand(int index);

        IView GetView(string userName);
    }
}
