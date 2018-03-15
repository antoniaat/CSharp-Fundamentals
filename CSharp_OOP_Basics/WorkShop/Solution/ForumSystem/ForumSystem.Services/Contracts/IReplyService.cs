using ForumSystem.Services.Models.Reply;
using System.Collections.Generic;

namespace ForumSystem.Services.Contracts
{
    public interface IReplyService
    {
        IEnumerable<ReplyServiceModel> GetReplyModelsByPostId(int postId);

        bool Create(ReplyServiceModel model);
    }
}
