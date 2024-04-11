using Forum.Domain.BaseEntities;
using Forum.Domain.Topics;

namespace Forum.Domain.Comments
{
    public class Comment : BaseEntity
    {
        public int TopicId { get; set; } = default!;
        public string Body { get; set; } = default!;

        // Navigation property
        public Topic Topic { get; set; } = default!;
    }
}
