namespace Custom_Data_Pipelines
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public DateTime PublicationDate { get; set; }
        public Genre Genre { get; set; }
        public int NumberOfPages { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }

        public Book(string title, string author, string isbn, string publisher, DateTime publicationDate, Genre genre, int numberOfPages, bool isAvailable, decimal price)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Publisher = publisher;
            PublicationDate = publicationDate;
            Genre = genre;
            NumberOfPages = numberOfPages;
            IsAvailable = isAvailable;
            Price = price;
        }
    }

    public enum Genre
    {
        Thriller,
        Action,
        Detective,
        Roman,
        Documentary
    }
}
