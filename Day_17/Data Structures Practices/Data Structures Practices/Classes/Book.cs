namespace Data_Structures_Practices.Classes
{
    public class Book
    {
        public string? Author { get; set; }
        public string? Title { get; set; }
        public int ReleaseYear { get; set; }
        public string? ISBN { get; set; }
        public Enum? Genre { get; set; }

        public Book(string author, string title, int releaseYear, string ISBN, Enum genre)
        {
            Author = author;
            Title = title;
            ReleaseYear = releaseYear;
            this.ISBN = ISBN;
            Genre = genre;
        }
    }
}
