namespace Forum.Application.Topics.Requests
{
    public class TopicRequestPostModel
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int AuthorId { get; set; } = default!;
    }
}