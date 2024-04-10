using Forum.Domain;

namespace Forum.Application.Profiles.Responses
{
    public class UserResponseModel
    {
        public string Id { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public Status Status { get; set; } = default!;
    }
}
