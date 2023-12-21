namespace Data_Structures_Practices.Classes
{
    public class BookComparer : IComparer<Book>
    {
        // Compare release year
        //public int Compare(Book? x, Book? y)
        //{
        //    return x.ReleaseYear.CompareTo(y.ReleaseYear);
        //}

        // Compare author name
        //public int Compare(Book? x, Book? y)
        //{
        //    return String.Compare(x.Author, y.Author);
        //}        

        // Compare genres
        public int Compare(Book? x, Book? y)
        {
            string xGenre = x.Genre.ToString();
            string yGenre = y.Genre.ToString();

            return String.Compare(xGenre, yGenre);
        }
    }
}
