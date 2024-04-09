namespace Forum.Application.Accounts.Updates
{
    public class PasswordRequestPutModel
    {
        public string? OldPassword { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
