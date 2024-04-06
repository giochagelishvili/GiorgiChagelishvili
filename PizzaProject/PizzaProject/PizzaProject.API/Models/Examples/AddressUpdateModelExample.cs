using PizzaProject.API.Models.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaProject.API.Models.Examples
{
    public class AddressUpdateModelExample : IExamplesProvider<AddressUpdateModel>
    {
        public AddressUpdateModel GetExamples()
        {
            return new AddressUpdateModel
            {
                City = "Kutaisi",
                Country = "Georgia",
                Region = "Imereti",
                Description = "Bikentias saqababe"
            };
        }
    }
}
