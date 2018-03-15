namespace ForumSystem.App.Controllers
{
    using ForumSystem.App.Controllers.Contracts;
    using ForumSystem.App.CustomExceptions;
    using ForumSystem.App.Enums;
    using ForumSystem.App.UserInterface;
    using ForumSystem.App.UserInterface.Contracts;
    using ForumSystem.Services.Contracts;
    using ForumSystem.Services.Implementations;

    public class SignUpController : IController, IReadUserInfoController
	{
        private const string REGISTRATION_SUCCESSFULL = "Registration successfull";

        private IUserService userService;

        public SignUpController()
        {
            this.userService = new UserService();
        }

        public string Username { get; private set; }

        private string Password { get; set; }

        private string ErrorMessage { get; set; }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.ReadUsername:
                    this.ReadUsername();
                    return MenuState.Signup;
                case Command.ReadPassword:
                    this.ReadPassword();
                    return MenuState.Signup;
                case Command.SignUp:
                    var registerUserResponse = this.userService
                        .RegisterUser(this.Username, this.Password);

                    if (registerUserResponse.Equals(REGISTRATION_SUCCESSFULL))
                    {
                        return MenuState.SuccessfulLogIn;
                    }
                    else
                    {
                        this.ErrorMessage = registerUserResponse;
                        return MenuState.Rerender;
                    }
                case Command.Back:
                    this.ResetSignUp();
                    return MenuState.Back;
            }

            throw new InvalidCommandException();
        }

        public IView GetView(string userName)
        {
            return new SignUpView(this.ErrorMessage);
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

        private void ResetSignUp()
        {
            this.ErrorMessage = string.Empty;
            this.Username = string.Empty;
            this.Password = string.Empty;
        }

        public enum SignUpStatus
        {
            Success,
            DetailsError,
            UsernameTakenError
        }

        private enum Command
        {
            ReadUsername,
            ReadPassword,
            SignUp,
            Back
        }
    }
}
