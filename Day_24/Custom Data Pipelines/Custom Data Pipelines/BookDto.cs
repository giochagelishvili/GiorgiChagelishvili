namespace Custom_Data_Pipelines
{
    public class BookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public Genre Genre { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }

        public BookDto(string title, string author, Genre genre, bool isAvailable, decimal price)
        {
            Title = title;
            Author = author;
            Genre = genre;
            IsAvailable = isAvailable;
            Price = price;
        }
    }
}
