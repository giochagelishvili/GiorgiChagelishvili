using Forum.Application.Users.Interfaces;
using Forum.Application.Users.Responses;

namespace Forum.Workers.Bans
{
    public class BanService
    {
        private readonly IUserService _userService;

        public BanService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<List<UserResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _userService.GetAllAsync(cancellationToken);
        }

        public async Task UnbanUser(string id)
        {
            await _userService.UnbanUser(id);
        }
    }
}
