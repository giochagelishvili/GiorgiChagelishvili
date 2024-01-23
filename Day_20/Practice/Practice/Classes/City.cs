namespace Practice.Classes
{
    public class City : GeographicEntity
    {
        public bool IsCapital { get; set; }
        public string Homeland { get; set; }

        public City(string name, double area, int population, bool isCapital, string homeland) : base(name, area, population)
        {
            IsCapital = isCapital;
            Homeland = homeland;
        }
    }
}
