namespace PizzaProject.API.Models.Requests
{
    public class UserAddressRequest
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string? Region { get; set; }
        public string? Description { get; set; }
    }
}
