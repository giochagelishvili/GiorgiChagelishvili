using PizzaProject.API.Models.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaProject.API.Models.Examples
{
    public class PizzaCreateModelExample : IExamplesProvider<PizzaCreateModel>
    {
        public PizzaCreateModel GetExamples()
        {
            return new PizzaCreateModel
            {
                Name = "Margherita",
                Price = 14.99M,
                Description = "Pizza margherita, as the Italians call it, is a simple pizza hailing from Naples.",
                CaloryCount = 209
            };
        }
    }
}
