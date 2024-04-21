﻿using Forum.API.Infrastructure.Authorization;
using Forum.Application.Accounts.Interfaces;
using Forum.Application.Accounts.Requests;
using Forum.Application.Users.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Forum.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        private readonly IConfiguration _config;

        public AccountController(IAccountService accountService, IUserService userService, IConfiguration config)
        {
            _accountService = accountService;
            _userService = userService;
            _config = config;
        }

        [HttpPost("login")]
        public async Task<string> Login(LoginRequestModel model)
        {
            await _accountService.SignInAsync(model);

            var user = await _userService.GetByUsernameAsync(model.Username);

            var userRoles = await _userService.GetUserRolesAsync(user.Id.ToString());

            return JWTHelper.GenerateToken(user, userRoles, _config);
        }

        [HttpPost("register")]
        public async Task Register(RegisterRequestModel model)
        {
            await _accountService.RegisterAsync(model);
        }
    }
}