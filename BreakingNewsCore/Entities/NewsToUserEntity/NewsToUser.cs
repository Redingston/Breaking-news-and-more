using BreakingNewsCore.Entities.NewsEntity;
using BreakingNewsCore.Entities.UserEntity;

namespace BreakingNewsCore.Entities.NewsToUserEntity
{
    public class NewsToUser
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public string NewsId { get; set; }
        public News News { get; set; }
    }
}