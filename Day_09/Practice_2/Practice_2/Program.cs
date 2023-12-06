using Practice_2;

Clock clock = new Clock();

clock.Hours = getIntInput("Enter hours");
clock.Minutes = getIntInput("Enter minutes");
clock.Seconds = getIntInput("Enter seconds");

clock.SubtractSecond();
clock.SubtractSecond();
clock.SubtractSecond();
clock.SubtractSecond();

Console.WriteLine(clock.GetCurrentTime());

// Read, validate and return integer input from the user
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