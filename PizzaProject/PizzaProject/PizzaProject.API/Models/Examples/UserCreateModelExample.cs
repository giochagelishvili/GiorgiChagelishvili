using PizzaProject.API.Models.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaProject.API.Models.Examples
{
    public class UserCreateModelExample : IExamplesProvider<UserCreateModel>
    {
        public UserCreateModel GetExamples()
        {
            return new UserCreateModel
            {
                FirstName = "Zoro",
                LastName = "Roronoa",
                Email = "enmadaio@gmail.com",
                PhoneNumber = "555444333",
                Address = new List<UserAddressRequest>
                {
                    new UserAddressRequest
                    {
                        City = "New York",
                        Country = "U.S.A"
                    }
                }
            };
        }
    }
}
