using System.Collections.Generic;
using BreakingNewsCore.Entities.CommentEntity;
using BreakingNewsCore.Entities.NewsToUserEntity;
using BreakingNewsCore.Entities.RefreshTokenEntity;
using Microsoft.AspNetCore.Identity;

namespace BreakingNewsCore.Entities.UserEntity
{
    public class User : IdentityUser
    {
        public List<NewsToUser> News { get; set; }
        public List<Comment> Comments { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}