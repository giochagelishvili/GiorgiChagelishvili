namespace Practice_1
{
    public class Rectangle : Shape
    {
        private Point A {  get; set; }
        private Point B { get; set; }
        private Point C { get; set; }
        private Point D { get; set; }

        private int Width { get; set; }
        private int Height { get; set; }

        public Rectangle(Point a, Point b, Point c, Point d)
        {
            A = a;
            B = b;
            C = c;
            D = d;

            Width = CalculateWidth(a, b);
            Height = CalculateHeight(b, c);
        }

        public override double Area()
        {
            return Width * Height;
        }

        public override double Perimeter()
        {
            return (Width * 2) + (Height * 2);
        }

        // Calculate width of the rectangle (distance between X coordinates)
        private int CalculateWidth(Point firstCoordinate, Point secondCoordinate)
        {
            int firstX = firstCoordinate.x;
            int secondX = secondCoordinate.x;

            if (firstX < 0)
                firstX *= -1;

            if (secondX < 0)
                secondX *= -1;

            return firstX + secondX;
        }
        
        // Calculate height of the rectangle (distance between Y coordinates)
        private int CalculateHeight(Point firstCoordinate, Point secondCoordinate)
        {
            int firstY = firstCoordinate.y;
            int secondY = secondCoordinate.y;

            if (firstY < 0)
                firstY *= -1;

            if (secondY < 0)
                secondY *= -1;

            return firstY + secondY;
        }

        // Override ToString() method and return the name of the shape
        public override string ToString()
        {
            return "Triangle";
        }
    }
}
