namespace Custom_Data_Pipelines
{
    public static class Filter
    {
        public static bool PublishedAfter(Book book) => book.PublicationDate < new DateTime(2023, 1, 1);

        public static bool AuthorFilter(Book book) => book.Author == "F. Scott Fitzgerald";

        public static bool CheaperThan(Book book) => book.Price < 4.99M;
    }
}
