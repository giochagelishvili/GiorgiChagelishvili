namespace PizzaProject.Application.Exceptions
{
    public class AddressNotFoundException : Exception
    {
        public readonly string Code = "AddressNotFound";

        public AddressNotFoundException(string message = "Address not found.") : base(message)
        {
        }
    }
}
