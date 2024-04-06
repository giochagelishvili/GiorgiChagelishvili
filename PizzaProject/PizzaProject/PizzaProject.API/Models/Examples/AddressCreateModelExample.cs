using PizzaProject.API.Models.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaProject.API.Models.Examples
{
    public class AddressCreateModelExample : IExamplesProvider<AddressCreateModel>
    {
        public AddressCreateModel GetExamples()
        {
            return new AddressCreateModel
            {
                UserId = 1,
                City = "Rustavi",
                Country = "Georgia",
                Region = "Kvemo Kartli",
                Description = "Shota rustaveli rustaveli ar iyo"
            };
        }
    }
}
