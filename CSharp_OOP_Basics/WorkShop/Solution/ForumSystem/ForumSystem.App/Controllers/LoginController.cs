namespace ForumSystem.App.Controllers
{
    using Controllers.Contracts;
    using CustomExceptions;
    using Enums;
    using ForumSystem.Services.Contracts;
    using ForumSystem.Services.Implementations;
    using UserInterface;
    using UserInterface.Contracts;
    using Views;

    public class LogInController : IController, IReadUserInfoController
    {
        private IUserService userService;

        public LogInController()
        {
            this.userService = new UserService();
            this.ResetLogIn();
        }

        public string Username { get; private set; }

        private string Password { get; set; }

        private bool Error { get; set; }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.ReadUsername:
                    this.ReadUsername();
                    return MenuState.Login;
                case Command.ReadPassword:
                    this.ReadPassword();
                    return MenuState.Login;
                case Command.LogIn:
                    return this.TryToLogIn();
                case Command.Back:
                    this.ResetLogIn();
                    return MenuState.Back;
                default:
                    throw new InvalidCommandException();
            }
        }

        private MenuState TryToLogIn()
        {
            var isLoginSuccessfull = this.userService
                                    .ValidateLoginTrial(this.Username, this.Password);
            if (isLoginSuccessfull)
            {
                return MenuState.SuccessfulLogIn;
            }
            else
            {
                this.Error = true;
                return MenuState.Rerender;
            }
        }

        public IView GetView(string userName)
        {
            return new LogInView(this.Error, this.Username, this.Password.Length);
        }

        public void ReadPassword()
        {
            this.Password = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void ReadUsername()
        {
            this.Username = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        private void ResetLogIn()
        {
            this.Username = string.Empty;
            this.Password = string.Empty;
            this.Error = false;
        }

        private enum Command
        {
            ReadUsername,
            ReadPassword,
            LogIn,
            Back
        }
    }
}
