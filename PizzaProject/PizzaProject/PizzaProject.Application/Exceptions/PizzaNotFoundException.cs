namespace PizzaProject.Application.Exceptions
{
    public class PizzaNotFoundException : Exception
    {
        public readonly string Code = "PizzaNotFound";

        public PizzaNotFoundException(string message = "Pizza not found.") : base(message)
        {
        }
    }
}
