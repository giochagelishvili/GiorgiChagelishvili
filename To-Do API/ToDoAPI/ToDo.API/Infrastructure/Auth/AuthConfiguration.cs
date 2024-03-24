namespace ToDo.API.Infrastructure.Auth
{
    public class AuthConfiguration
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpInMinutes { get; set; }
    }
}
