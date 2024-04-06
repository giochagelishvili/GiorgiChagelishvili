namespace Forum.Application.Accounts
{
    public class LoginRequestModel
    {
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public bool RememberLogin { get; set; }
    }
}
