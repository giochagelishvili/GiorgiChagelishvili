namespace Practice_1
{
    public class Rectangle : Shape
    {
        private Point A {  get; set; }
        private Point B { get; set; }
        private Point C { get; set; }
        private Point D { get; set; }

        private double Width { get; set; }
        private double Height { get; set; }

        public Rectangle(Point a, Point b, Point c, Point d)
        {
            A = a;
            B = b;
            C = c;
            D = d;

            Width = CalculateDistance(A, B);
            Height = CalculateDistance(B, C);
        }

        public override double Area()
        {
            return Width * Height;
        }

        public override double Perimeter()
        {
            return (Width * 2) + (Height * 2);
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
            return "Rectangle";
        }
    }
}
