namespace PizzaProject.Application.Orders
{
    public class OrderRequestModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? AddressId { get; set; }
        public List<int> PizzaIds { get; set; }
    }
}
