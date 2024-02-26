namespace PizzaProject.Domain.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? AddressId { get; set; }
        public List<int>? PizzaIds { get; set; }
        public List<Pizza>? Pizzas { get; set; }
    }
}
