namespace Custom_Data_Pipelines
{
    public static class Transform
    {
        public static BookDto ToBookDto(this Book book) => new BookDto(book.Title, book.Author, book.Genre, book.IsAvailable, book.Price);
    }
}
