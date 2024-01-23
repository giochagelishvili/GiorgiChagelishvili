namespace Chained_Validation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book
            {
                Title = "Dea AI",
                Author = "Dea Chkoidze",
                ISBN = "1234567890123",
                Publisher = "Dea AI Publishing",
                PublicationDate = new DateTime(2024, 1, 13),
                Genre = Genre.Action,
                IsAvailable = false,
            };

            Validator validator = new Validator();
            validator.ValidateBook(book);
        }
    }
}
