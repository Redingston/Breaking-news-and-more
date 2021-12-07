using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class NewsToUser
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public string NewsId { get; set; }
        public News News { get; set; }
    }
}