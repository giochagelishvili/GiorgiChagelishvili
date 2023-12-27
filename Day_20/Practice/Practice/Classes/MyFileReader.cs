namespace Practice.Classes
{
    public static class MyFileReader
    {
        public static List<City> ReadCities(string path)
        {
            List<City> cities = new List<City>();

            try
            {
                using (StreamReader cityReader = new StreamReader(path))
                {
                    var line = cityReader.ReadLine();

                    while (line != null)
                    {
                        string[] cityDetails = line.Split('|');

                        string name = cityDetails[0];
                        double area = double.Parse(cityDetails[1]);
                        int population = int.Parse(cityDetails[2]);
                        bool isCapital = bool.Parse(cityDetails[3]);
                        string homeLand = cityDetails[4];

                        cities.Add(new City(name, area, population, isCapital, homeLand));

                        line = cityReader.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.Log(ex);
                return null;
            }

            return cities;
        }

        public static List<Country> ReadCountries(string path)
        {
            List<Country> countries = new List<Country>();
            List<string> distinctCountries = DistinctCountries(path);

            foreach (string country in distinctCountries)
            {
                try
                {
                    using (StreamReader lineReader = new StreamReader(path))
                    {
                        List<City> cities = new List<City>();

                        var line = lineReader.ReadLine();

                        while(line != null)
                        {
                            string[] cityDetails = line.Split('|');

                            if (cityDetails[4] == country)
                            {
                                string name = cityDetails[0];
                                double area = double.Parse(cityDetails[1]);
                                int population = int.Parse(cityDetails[2]);
                                bool isCapital = bool.Parse(cityDetails[3]);
                                string homeLand = cityDetails[4];

                                cities.Add(new City(name, area, population, isCapital, homeLand));
                            }

                            line = lineReader.ReadLine();
                        }

                        Country newCountry = new Country(country, cities);
                        countries.Add(newCountry);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Logger.Log(ex);
                }
            }

            return countries;
        }

        private static List<string> DistinctCountries(string path)
        {
            List<string> distinctCountries = new List<string>();

            try
            {
                using (StreamReader lineReader = new StreamReader(path))
                {
                    var line = lineReader.ReadLine();

                    while (line != null)
                    {
                        string[] cityDetails = line.Split('|');
                        string country = cityDetails[4];

                        if (!distinctCountries.Contains(country))
                            distinctCountries.Add(country);

                        line = lineReader.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.Log(ex);
                return null;
            }

            return distinctCountries;
        }
    }
}
