using Mapster;
using Microsoft.AspNetCore.Mvc;
using PizzaProject.API.Models.Requests;
using PizzaProject.Application.Users;

namespace PizzaProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get all users from the database
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<UserResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _userService.GetAll(cancellationToken);
        }

        /// <summary>
        /// Get user using ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<UserResponseModel> Get(int id, CancellationToken cancellationToken)
        {
            return await _userService.Get(id, cancellationToken);
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Post(UserCreateModel user, CancellationToken cancellationToken)
        {
            var requestModel = user.Adapt<UserRequestModel>();

            await _userService.Create(requestModel, cancellationToken);
        }

        /// <summary>
        /// Update user using ID
        /// </summary>
        /// <param name="user"></param>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task Put(UserCreateModel user, int id, CancellationToken cancellationToken)
        {
            var requestModel = user.Adapt<UserRequestModel>();
            requestModel.Id = id;

            await _userService.Update(requestModel, cancellationToken);
        }

        /// <summary>
        /// Delete user using ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _userService.Delete(id, cancellationToken);
        }
    }
}
