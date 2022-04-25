using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            News = new HashSet<NewsToUser>();
            Comments = new HashSet<Comment>();
            RefreshTokens = new HashSet<RefreshToken>();
        }

        public ICollection<NewsToUser> News { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}