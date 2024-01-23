namespace Custom_Data_Pipelines
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = GenerateBooks();
            var filteredBooks = DataPipeline<Book>.Process<IEnumerable<BookDto>>(books).ToList();
        }

        public static List<Book> GenerateBooks()
        {
            List<Book> list = new();

            string[] bookNames = { "The Great Gatsby", "To Kill a Mockingbird", "1984", "Pride and Prejudice", "The Catcher in the Rye", "Animal Farm", "Brave New World", "Fahrenheit 451", "The Hobbit", "The Lord of the Rings", "Harry Potter and the Sorcerer's Stone", "The Hunger Games", "The Da Vinci Code", "The Alchemist", "The Shining", "The Great Expectations", "Wuthering Heights", "Moby-Dick", "The Odyssey", "War and Peace" };

            string[] authors = { "F. Scott Fitzgerald", "Harper Lee", "George Orwell", "Jane Austen", "J.D. Salinger", "George Orwell", "Aldous Huxley", "Ray Bradbury", "J.R.R. Tolkien", "J.R.R. Tolkien", "J.K. Rowling", "Suzanne Collins", "Dan Brown", "Paulo Coelho", "Stephen King", "Charles Dickens", "Emily Brontë", "Herman Melville", "Homer", "Leo Tolstoy" };

            Random random = new();

            for (int i = 0; i < bookNames.Length; i++)
            {
                Book book = new(bookNames[i], authors[i], "1234567890123", "Dea Chkoidze Inc.", new DateTime(2023, 12, i + 1), Genre.Detective, 50 * i, true, i + 0.99M);
                list.Add(book);
            }

            return list;
        }
    }
}
