﻿using Forum.Application.Exceptions;
using Forum.Application.Profiles.Interfaces;
using Forum.Application.Profiles.Requests.Updates;
using Forum.Application.Profiles.Responses;
using Forum.Domain;
using Forum.Domain.Users;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace Forum.Application.Profiles
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<UserResponseModel> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                throw new UserNotFoundException();

            return user.Adapt<UserResponseModel>();
        }

        public async Task<UserResponseModel> GetByUsernameAsync(string username)
        {
            var result = await _userManager.FindByNameAsync(username);

            if (result == null || result.Status == Status.Inactive)
                throw new UserNotFoundException();

            return result.Adapt<UserResponseModel>();
        }

        public async Task UpdateUsernameAsync(UserRequestPutModel model)
        {
            if (await UsernameExists(model.UpdatedUsername))
                throw new UsernameAlreadyExistsException();

            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null || user.Status == Status.Inactive)
                throw new UserNotFoundException();

            user.UserName = model.UpdatedUsername;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                throw new ErrorWhileProcessingException();

            await _signInManager.RefreshSignInAsync(user);
        }

        public async Task UpdateEmailAsync(UserRequestPutModel model)
        {
            if (await EmailExists(model.Email))
                throw new EmailAlreadyExistsException();

            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null || user.Status == Status.Inactive)
                throw new UserNotFoundException();

            user.Email = model.Email;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                throw new ErrorWhileProcessingException();

            await _signInManager.RefreshSignInAsync(user);
        }

        public async Task UpdatePasswordAsync(UserRequestPutModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null || user.Status == Status.Inactive)
                throw new UserNotFoundException();

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

            if (!result.Succeeded)
                throw new ErrorWhileProcessingException();

            await _signInManager.RefreshSignInAsync(user);
        }

        public async Task<bool> UsernameExists(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null || user.Status == Status.Inactive)
                return false;

            return true;
        }

        public async Task<bool> EmailExists(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                return false;

            return true;
        }
    }
}
