namespace PizzaProject.API.Models.Requests
{
    public class OrderCreateModel
    {
        public int UserId { get; set; }
        public int? AddressId { get; set; }
        public List<int> PizzaIds { get; set; }
    }
}
