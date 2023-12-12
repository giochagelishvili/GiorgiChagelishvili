using Practice_1;

Shape[] shapes = new Shape[2];

shapes[0] = CreateTriangle();
shapes[1] = CreateRectangle();

// Circle implements an interface therefore I couldn't add it into "shapes" array
Circle circle = CreateCircle();

foreach (Shape shape in shapes)
{
    string shapeName = shape.ToString();
    string perimeter = shape.Perimeter().ToString("F1");
    string area = shape.Area().ToString("F1");

    Console.WriteLine($"Perimeter of the {shapeName} is: {perimeter}");
    Console.WriteLine($"Area of the {shapeName} is: {area}");
}

string circlePerimeter = circle.Perimeter().ToString("F1");
string circleArea = circle.Area().ToString("F1");

Console.WriteLine($"Perimeter of the circle is: {circlePerimeter}");
Console.WriteLine($"Area of the circle is: {circleArea}");

// Creates and returns circle object
Circle CreateCircle()
{
    Console.WriteLine("Creating circle");
    Console.WriteLine("--------------------------");

    Console.WriteLine("Enter coordinates of the center of the circle:");
    Point center = CreatePoint();

    Console.WriteLine("Enter coordinates of the point on the circle:");
    Point point = CreatePoint();

    return new Circle(center, point);
}

// Creates and returns rectangle object
Rectangle CreateRectangle()
{
    Console.WriteLine("Creating rectangle");
    Console.WriteLine("--------------------------");

    Console.WriteLine("Enter point A coordinates:");
    Point a = CreatePoint();

    Console.WriteLine("Enter point B coordinates:");
    Point b = CreatePoint();

    Console.WriteLine("Enter point C coordinates:");
    Point c = CreatePoint();

    Console.WriteLine("Enter point D coordinates:");
    Point d = CreatePoint();

    return new Rectangle(a, b, c, d);
}


// Creates and returns triangle object
Triangle CreateTriangle()
{
    Console.WriteLine("Creating triangle");
    Console.WriteLine("--------------------------");

    Console.WriteLine("Enter point A coordinates:");
    Point a = CreatePoint();

    Console.WriteLine("Enter point B coordinates:");
    Point b = CreatePoint();

    Console.WriteLine("Enter point C coordinates:");
    Point c = CreatePoint();

    return new Triangle(a, b, c);
}


// Creates and returns point object
Point CreatePoint()
{
    int x;
    bool xInput;

    do
    {
        Console.Write("X: ");
        xInput = int.TryParse(Console.ReadLine(), out x);
    } while (xInput != true);

    int y;
    bool yInput;

    do
    {
        Console.Write("Y: ");
        yInput = int.TryParse(Console.ReadLine(), out y);
    } while (yInput != true);

    return new Point(x, y);
}