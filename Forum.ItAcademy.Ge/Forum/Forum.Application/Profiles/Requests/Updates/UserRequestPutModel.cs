namespace Forum.Application.Profiles.Requests.Updates
{
    public class UserRequestPutModel
    {
        public string? Email { get; set; }
        public string? CurrentUsername { get; set; }
        public string? UpdatedUsername { get; set; }
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}
