using PizzaProject.API.Models.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaProject.API.Models.Examples
{
    public class UserAddressRequestModelExample : IExamplesProvider<UserAddressRequest>
    {
        public UserAddressRequest GetExamples()
        {
            return new UserAddressRequest
            {
                City = "Dubai",
                Country = "UAE"
            };
        }
    }
}
