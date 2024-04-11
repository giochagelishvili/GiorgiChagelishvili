using Forum.Application.Comments.Responses;
using Forum.Application.Profiles.Responses;
using Forum.Domain;

namespace Forum.Application.Topics.Responses
{
    public class TopicResponseModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Status Status { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public UserResponseModel Author { get; set; } = default!;
        public State State { get; set; }
        public List<CommentResponseModel> Comments { get; set; } = default!;
    }
}
