using Forum.Application.Accounts.Requests;

namespace Forum.Application.Accounts.Interfaces
{
    public interface IAccountService
    {
        Task SignInAsync(LoginRequestModel model);
        Task RegisterAsync(RegisterRequestModel model);
        Task SignOutAsync();
    }
}
