using PizzaProject.Application.Addresses;

namespace PizzaProject.Application.Users
{
    public class UserResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<AddressRequestModel>? Address { get; set; }
    }
}
