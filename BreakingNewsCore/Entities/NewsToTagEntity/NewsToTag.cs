namespace Domain.Entities
{
    public class NewsToTag
    {
        public string TagId { get; set; }
        public Tag Tag { get; set; }

        public string NewsId { get; set; }
        public News News { get; set; }
    }
}