namespace Practice_1
{
    public class Circle : IShape
    {
        private Point Center { get; set; }
        private Point CirclePoint { get; set; }
        private double Radius { get; set; }

        public Circle(Point center, Point circlePoint)
        {
            Center = center;
            CirclePoint = circlePoint;

            Radius = CalculateDistance(Center, CirclePoint);
        }

        public double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }

        // Override ToString() method and return the name of the shape
        public override string ToString()
        {
            return "Circle";
        }

        // calculates distance (length) between 2 coordinates on coordinate plane
        // general formula could be looked up in google
        private double CalculateDistance(Point firstCoordinate, Point secondCoordinate)
        {
            int subtractX = secondCoordinate.x - firstCoordinate.x;
            int subtractY = secondCoordinate.y - firstCoordinate.y;

            double sum = Math.Pow(subtractX, 2) + Math.Pow(subtractY, 2);

            double distance = Math.Sqrt(sum);

            return distance;
        }
    }
}
