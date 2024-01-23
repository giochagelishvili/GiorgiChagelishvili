namespace Chained_Validation
{
    public delegate bool ValidateBook(Book book);
    public class Validator
    {
        public void ValidateBook(Book book)
        {
            ValidateBook validator = ValidateTitle;
            validator += ValidateAuthor;
            validator += ValidateISBN;
            validator += ValidatePublisher;
            validator += ValidateDate;
            validator += ValidateGenre;
            validator += ValidatePages;
            validator += ValidateAvailability;
            validator += ValidatePrice;

            foreach (var item in validator.GetInvocationList())
            {
                bool isValidProperty = (bool)item.DynamicInvoke(book);

                if (!isValidProperty)
                    Console.WriteLine($"{item.Method.Name.Substring(8)}");
            }
        }

        private bool ValidateTitle(Book book) => !string.IsNullOrEmpty(book.Title) && ValidateLength(book.Title, 1, 255) && ValidateLetters(book.Title);

        private bool ValidateAuthor(Book book) => !string.IsNullOrEmpty(book.Author) && ValidateLength(book.Author, 3, 128) && ValidateLetters(book.Author);

        private bool ValidateISBN(Book book) => !string.IsNullOrEmpty(book.ISBN) && book.ISBN.Length == 13 && book.ISBN.All(char.IsDigit);

        private bool ValidatePublisher(Book book) => !string.IsNullOrEmpty(book.Publisher) && ValidateLength(book.Publisher, 2, 64);

        private bool ValidateDate(Book book) => book.PublicationDate == null || book.PublicationDate < DateTime.Now;

        private bool ValidateGenre(Book book) => book.Genre != null;

        private bool ValidatePages(Book book) => book.NumberOfPages != null && book.NumberOfPages > 0;

        private bool ValidateAvailability(Book book) => book.IsAvailable != null;

        private bool ValidatePrice(Book book) => book.Price == null || book.Price > 0;

        private bool ValidateLetters(string text) => text.All(c => Char.IsLetterOrDigit(c) || c == 32);

        private bool ValidateLength(string text, int minLength, int maxLength) => text.Length > minLength && text.Length < maxLength;
    }
}
