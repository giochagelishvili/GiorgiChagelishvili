﻿namespace Forum.Application.Profiles.Requests.Updates
{
    public class PasswordRequestPutModel
    {
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}