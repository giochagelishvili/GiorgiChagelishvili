using Practice.Exceptions;

namespace Practice.Classes
{
    public static class Application
    {
        public static void Start(List<City> cities, List<Country> countries)
        {
            Console.WriteLine("1) Search city");
            Console.WriteLine("2) Search country");

            string searchType = GetSearchInput();

            if (searchType == "City")
                SearchCity(cities);
            else if (searchType == "Country")
                SearchCountry(countries);

        }

        private static void SearchCountry(List<Country> countries)
        {
            Console.Write("Please enter the name of the country: ");

            try
            {
                string countryName = Console.ReadLine();

                if (countryName == null || countryName == "")
                    throw new CityNotFoundException("Country name is not provided.");

                foreach (Country country in countries)
                {
                    if (country.Name == countryName)
                    {
                        DisplayCountry(country);
                        return;
                    }
                }

                throw new CityNotFoundException("Country not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.Log(ex);
            }
        }

        private static void DisplayCountry(Country country)
        {
            Console.WriteLine($"Name: {country.Name}");
            Console.WriteLine($"Area: {country.Area}");
            Console.WriteLine($"Population: {country.Population}");
            Console.Write($"Cities: ");
            
            foreach(City city in country.Cities)
            {
                if (city.IsCapital)
                    Console.Write($"{city.Name} (Capital)");
                else
                    Console.Write($"{city.Name}");

                if (city != country.Cities.Last())
                    Console.Write(", ");
            }
        }

        private static void SearchCity(List<City> cities)
        {
            Console.Write("Please enter the name of the city: ");

            try
            {
                string cityName = Console.ReadLine();

                if (cityName == null || cityName == "")
                    throw new CityNotFoundException("City name is not provided.");

                foreach (City city in cities) 
                {
                    if (city.Name == cityName)
                    {
                        DisplayCity(city);
                        return;
                    }
                }

                throw new CityNotFoundException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.Log(ex);
            }
        }

        private static void DisplayCity(City city)
        {
            Console.WriteLine($"Name: {city.Name}");
            Console.WriteLine($"Area: {city.Area}");
            Console.WriteLine($"Population: {city.Population}");

            if (city.IsCapital)
                Console.WriteLine("Is capital");

            Console.WriteLine($"Homeland: {city.Homeland}");
        }

        private static string GetSearchInput()
        {
            int searchInput = 0;

            while(searchInput < 1 || searchInput > 2)
            {
                try
                {
                    bool userInput = int.TryParse(Console.ReadLine(), out searchInput);

                    if (!userInput)
                        throw new InvalidSearchInputException("Input must be a number.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Logger.Log(ex);
                }
            }

            if (searchInput == 1)
                return "City";
            else
                return "Country";
        }
    }
}
