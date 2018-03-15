namespace ForumSystem.Services.Implementations
{
    using ForumSystem.Data;
    using ForumSystem.Models;
    using ForumSystem.Services.Contracts;
    using System.Linq;

    public class UserService : IUserService
    {
        private const string REGISTRATION_SUCCESSFULL = "Registration successfull";
        private const string DETAILS_ERROR = "Invalid Username or Password!";
        private const string USERNAME_TAKEN_ERROR = "Username already in use!";

        public User GetById(int id)
        {
            using (var db = new ForumSystemDbContext())
            {
                return db.Users.FirstOrDefault(u => u.Id == id);
            }
        }

        public string RegisterUser(string username, string password)
        {
            using (var db = new ForumSystemDbContext())
            {
                var user = new User()
                {
                    Username = username,
                    Password = password
                };

                if (user.IsValid())
                {
                    var isUserExisting = db.Users.Any(u => u.Username == user.Username);

                    if (!isUserExisting)
                    {
                        db.Users.Add(user);
                        db.SaveChanges();
                        return REGISTRATION_SUCCESSFULL;
                    }
                    else
                    {
                        return USERNAME_TAKEN_ERROR;
                    }
                }
                else
                {
                    return DETAILS_ERROR;
                }
            }
        }

        public bool ValidateLoginTrial(string username, string password)
        {
            using (var db = new ForumSystemDbContext())
            {
                return db.Users
                    .Any(u => u.Username == username && u.Password == password);
            }
        }
    }
}
