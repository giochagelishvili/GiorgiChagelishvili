namespace Forum.Application.Accounts.Requests
{
    public class RegisterRequestModel
    {
        public string Email { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string ConfirmPassword { get; set; } = default!;
    }
}