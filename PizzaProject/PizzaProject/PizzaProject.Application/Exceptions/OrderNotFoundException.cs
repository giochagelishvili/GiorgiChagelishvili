namespace PizzaProject.Application.Exceptions
{
    public class OrderNotFoundException : Exception
    {
        public readonly string Code = "OrderNotFound";
        public OrderNotFoundException(string message = "Order not found.") : base(message)
        {
        }
    }
}
