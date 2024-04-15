using Forum.Domain;

namespace Forum.Application.Profiles.Responses
{
    public class UserResponseModel
    {
        public int Id { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
