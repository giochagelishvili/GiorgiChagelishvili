using Practice_1;

namespace Practice_1
{
    public class Triangle : Shape
    {
        private Point? A { get; set; }
        private Point? B { get; set; }
        private Point? C { get; set; }

        private double FirstSide { get; set; }
        private double SecondSide { get; set; }
        private double ThirdSide { get; set; }

        public Triangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;

            FirstSide = CalculateDistance(A, B);
            SecondSide = CalculateDistance(A, C);
            ThirdSide = CalculateDistance(B, C);
        }

        public override double Area()
        {
            // semi-perimeter
            double s = (FirstSide + SecondSide + ThirdSide) / 2;

            // area
            return Math.Sqrt(s * (s - FirstSide) * (s - SecondSide) * (s - ThirdSide));
        }

        public override double Perimeter()
        {
            return FirstSide + SecondSide + ThirdSide;
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

        // Override ToString() method and return the name of the shape
        public override string ToString()
        {
            return "Triangle";
        }
    }
}
