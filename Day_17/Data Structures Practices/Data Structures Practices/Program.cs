using Data_Structures_Practices.Classes;

namespace Data_Structures_Practices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //-------------------------//
            //-- Balancing Brackets --//
            //-----------------------//
            string brackets = "(){([])}";

            Console.WriteLine(Bracket.IsBalanced(brackets) ? $"Brackets are balanced: {brackets}" : $"Brackets are unbalanced: {brackets}");

            //-------------------------//
            //-- Point Calculations --//
            //-----------------------//
            Tuple<double, double> firstPoint = new Tuple<double, double>(3.5, -2.2);
            Tuple<double, double> secondPoint = new Tuple<double, double>(-3.5, 9.2);

            double distance = Point.CalculateDistance(firstPoint, secondPoint);

            Console.WriteLine($"Distance between two points is: { distance.ToString("F2") }");

            //-----------------------------//
            //-- Multiple Return Values --//
            //---------------------------//
            Tuple<int, bool> findMin = MultipleReturnValues.findMin(-5, 5);

            Console.WriteLine(findMin.Item2 ? $"Lesser number is: {findMin.Item1}" : "Passed numbers are equal.");

            //---------------------//
            //-- Custom Sorting --//
            //-------------------//
            Book martinEden = new Book("Jack London", "Martin Eden", 1909, "1234567890123", Genres.Fiction);
            Book sherlockHolmes = new Book("Arthut Conan Doyle", "A Case of Identyty", 1891, "3214560123456", Genres.Detective);
            Book davidCopperfield = new Book("Charles Dickens", "David Copperfield", 1850, "3214560123999", Genres.Novel);

            List<Book> bookList = new List<Book>();

            bookList.Add(martinEden);
            bookList.Add(sherlockHolmes);
            bookList.Add(davidCopperfield);

            Console.Write("Before sorting: ");

            foreach (Book book in bookList)
                if (book == bookList.Last())
                    Console.Write($"{book.Genre}\n");
                else
                    Console.Write($"{book.Genre}, ");

            bookList.Sort(new BookComparer());

            Console.Write("After sorting: ");

            foreach( Book book in bookList )
                if (book == bookList.Last())
                    Console.Write($"{book.Genre}\n");
                else
                    Console.Write($"{book.Genre}, ");

            //-------------------//
            //-- Swap Numbers --//
            //-----------------//
            Tuple<double, double> toSwap = new Tuple<double, double>(5.25, -1.2);

            Console.WriteLine($"Before swapping: {toSwap.Item1}, {toSwap.Item2}");

            toSwap = toSwap.Swap();

            Console.WriteLine($"After swapping: {toSwap.Item1}, {toSwap.Item2}");
        }

        enum Genres
        {
            Novel,
            Fiction,
            Thriller,
            Mystery,
            Narrative,
            Science,
            Detective
        }
    }
}
