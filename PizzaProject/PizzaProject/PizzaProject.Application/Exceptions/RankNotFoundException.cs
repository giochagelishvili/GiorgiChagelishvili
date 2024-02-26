namespace PizzaProject.Application.Exceptions
{
    public class RankNotFoundException : Exception
    {
        public readonly string Code = "RankNotFound";
        public RankNotFoundException(string message = "No ranks to show.") : base(message)
        {
        }
    }
}
