namespace PizzaProject.API.Models.Requests
{
    public class UserCreateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<UserAddressRequest>? Address { get; set; }
    }
}
