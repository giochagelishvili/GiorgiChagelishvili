namespace Practice.Exceptions
{
    public class CityNotFoundException : Exception
    {
        public CityNotFoundException(string? message = "City not found.") : base(message)
        {
        }
    }
}
