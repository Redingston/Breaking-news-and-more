using BreakingNewsCore.Entities.UserEntity;
using BreakingNewsCore.Interfaces;

namespace BreakingNewsCore.Entities.RefreshTokenEntity
{
    public class RefreshToken : IBaseEntity
    {
        public string Id { get; set; }

        public string Token { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}