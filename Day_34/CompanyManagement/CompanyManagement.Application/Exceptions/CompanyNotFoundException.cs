namespace CompanyManagement.Application.Exceptions
{
    public class CompanyNotFoundException : Exception
    {
        public string Code = "CompanyNotFound";

        public CompanyNotFoundException(string message = "Company not found.") : base(message) { }
    }
}
