using PizzaProject.Application.Pizzas;

namespace PizzaProject.Application.Orders
{
    public class OrderResponseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? AddressId { get; set; }
        public List<PizzaResponseModel> Pizzas { get; set; }
    }
}
