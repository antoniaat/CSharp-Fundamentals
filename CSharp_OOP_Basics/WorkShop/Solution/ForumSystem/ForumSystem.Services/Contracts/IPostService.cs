using ForumSystem.Services.Models.Post;

namespace ForumSystem.Services.Contracts
{
    public interface IPostService
    {
        PostServiceModel GetById(int id);

        bool Create(PostServiceModel model);
    }
}
