namespace Practice.Exceptions
{
    internal class HasNoCitiesException : Exception
    {
        public HasNoCitiesException(string? message = "This country has no cities.") : base(message)
        {
        }
    }
}
