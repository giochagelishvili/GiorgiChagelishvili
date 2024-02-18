namespace CustomList.Exceptions
{
    public class InvalidCapacityException : Exception
    {
        public InvalidCapacityException(string message = "Capacity must be greater or equal to 0.") : base(message)
        {
        }
    }
}
