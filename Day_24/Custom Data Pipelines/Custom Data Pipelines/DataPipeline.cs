namespace Custom_Data_Pipelines
{
    public static class DataPipeline
    {
        public static List<Func<Book, bool>> FilterDelegates { get; set; } = new();
        public static Func<Book, BookDto>? TransformDelegate { get; set; }

        public static IEnumerable<BookDto> Process(IEnumerable<Book> books)
        {
            FilterDelegates.Add(Filter.PublishedAfter);
            FilterDelegates.Add(Filter.AuthorFilter);
            FilterDelegates.Add(Filter.CheaperThan);
            TransformDelegate = Transform.ToBookDto;

            var filteredBooks = books.Where(books => FilterDelegates.All(filter => filter(books)));
            var transformedBooks = filteredBooks.Select(TransformDelegate);

            return transformedBooks;
        }
    }
}
