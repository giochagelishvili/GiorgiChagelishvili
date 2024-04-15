using Forum.Application.Comments.Responses;
using Forum.Application.Profiles.Responses;
using Forum.Domain;

namespace Forum.Application.Topics.Responses
{
    public class TopicResponseNewsFeedModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int CommentsCount { get; set; }
        public Status Status { get; set; }
        public UserResponseModel Author { get; set; } = default!;
    }
}
