namespace Practice.Classes
{
    public abstract class GeographicEntity
    {
        public string Name { get; set; }
        public double Area { get; set; }
        public int Population { get; set; }

        public GeographicEntity(string name, double area = 0, int population = 0) 
        {
            Name = name;
            Area = area;
            Population = population;
        }
    }
}
