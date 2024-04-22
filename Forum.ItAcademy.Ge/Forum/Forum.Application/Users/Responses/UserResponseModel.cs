namespace Forum.Application.Users.Responses
{
    public class UserResponseModel
    {
        public int Id { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string? Bio { get; set; }
        public bool? Gender { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsBanned { get; set; }
        public DateTime BannedUntil { get; set; }
    }
}
