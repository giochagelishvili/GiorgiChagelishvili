namespace Chained_Validation
{
    public class Book
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public string? Publisher { get; set; }
        public DateTime? PublicationDate { get; set; }
        public Genre? Genre { get; set; }
        public int? NumberOfPages { get; set; }
        public bool? IsAvailable { get; set; }
        public decimal? Price { get; set; }
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
