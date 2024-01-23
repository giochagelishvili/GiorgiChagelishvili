using Practice.Exceptions;

namespace Practice.Classes
{
    public class Country : GeographicEntity
    {
        public List<City> Cities { get; set; }

        public Country(string name, List<City> cities) : base(name)
        {
            if (HasSingleCapital(cities))
            {
                Cities = cities;
                Area = CalculateArea();
                Population = CalculatePopulation();
            }
        }

        private bool HasSingleCapital(List<City> cities)
        {
            int capitalCounter = 0;

            foreach (City city in cities)
                if(city.IsCapital)
                    capitalCounter++;

            if (capitalCounter > 1) 
                throw new CountryMustHaveSingleCapital();

            return true;
        }

        private double CalculateArea()
        {
            try
            {
                if (Cities.Count == 0 || Cities == null)
                    throw new HasNoCitiesException("Couldn't calculate area. City details unavailable.");

                double area = 0;

                foreach (City city in Cities)
                    area += city.Area;

                return area;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.Log(ex);
                return 0;
            }
        }

        private int CalculatePopulation()
        {
            try
            {
                if (Cities == null || Cities.Count == 0)
                    throw new HasNoCitiesException("Couldn't calculate population. City details unavailable.");

                int population = 0;

                foreach (City city in Cities)
                    population += city.Population;

                return population;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.Log(ex);
                return 0;
            }
        }
    }
}
