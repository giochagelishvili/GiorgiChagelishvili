﻿namespace Forum.Application.Accounts
{
    public class LoginRequestModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool RememberLogin { get; set; }
    }
}
