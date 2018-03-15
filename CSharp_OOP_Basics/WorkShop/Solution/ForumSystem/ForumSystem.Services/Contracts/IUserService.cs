namespace ForumSystem.Services.Contracts
{
    using ForumSystem.Models;

    public interface IUserService
    {
        User GetById(int id);

        bool ValidateLoginTrial(string username, string password);

        string RegisterUser(string username, string password);
    }
}
