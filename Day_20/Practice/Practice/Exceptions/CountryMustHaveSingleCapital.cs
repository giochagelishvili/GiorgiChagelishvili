namespace Practice.Exceptions
{
    internal class CountryMustHaveSingleCapital : Exception
    {
        public CountryMustHaveSingleCapital(string? message = "There is more than one capital city in the list.") : base(message)
        {
        }
    }
}
