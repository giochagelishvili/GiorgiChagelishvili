using PizzaProject.API.Models.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaProject.API.Models.Examples
{
    public class OrderCreateModelExample : IExamplesProvider<OrderCreateModel>
    {
        public OrderCreateModel GetExamples()
        {
            return new OrderCreateModel
            {
                UserId = 1,
                AddressId = 1,
                PizzaIds = new List<int> { 1, 1 }
            };
        }
    }
}
