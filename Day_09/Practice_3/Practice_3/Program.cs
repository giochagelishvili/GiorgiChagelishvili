using Practice_3;

Triangle triangle = new Triangle();

triangle.FirstSide = getIntInput("Enter length of first side");
triangle.SecondSide = getIntInput("Enter length of second side");
triangle.ThirdSide = getIntInput("Enter length of third side");

// Read, validate and return integer input
int getIntInput(string message)
{
    bool userInput;
    int value;

    do
    {
        Console.Write($"{message}: ");
        userInput = int.TryParse(Console.ReadLine(), out value);
    } while (userInput != true);

    return value;
}