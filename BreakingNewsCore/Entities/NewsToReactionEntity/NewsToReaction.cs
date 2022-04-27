namespace Domain.Entities
{
    public class NewsToReaction
    {
        public string ReactionId { get; set; }
        public Reaction Reaction { get; set; }

        public string NewsId { get; set; }
        public News News { get; set; }
    }
}