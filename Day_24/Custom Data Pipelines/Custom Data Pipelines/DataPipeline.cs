namespace Custom_Data_Pipelines
{
    public static class DataPipeline<T>
    {
        public static Func<Book, bool> FilterDelegatesChain { get; set; }
        public static Func<Book, BookDto> TransformDelegate { get; set; }

        public static TResult Process<TResult>(IEnumerable<Book> books)
        {
            FilterDelegatesChain = Filter.PublishedAfter;
            FilterDelegatesChain += Filter.AuthorFilter;
            FilterDelegatesChain += Filter.CheaperThan;

            TransformDelegate = Transform.ToBookDto;

            var filteredBooks = books.Where(FilterDelegatesChain);
            var transformedBooks = filteredBooks.Select(TransformDelegate);

            return (TResult)transformedBooks;
        }
    }
}
