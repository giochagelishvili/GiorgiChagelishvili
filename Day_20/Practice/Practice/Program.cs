using Practice.Classes;

namespace Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\user\Desktop\Cities.txt";
            List<City> cities = MyFileReader.ReadCities(path);
            List<Country> countries = MyFileReader.ReadCountries(path);

            Application.Start(cities, countries);
        }
    }
}
