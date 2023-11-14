Console.WriteLine("Enter integer number: ");

// Prompt the user for input
var userInput = Console.ReadLine();
int num;

// Check if user input is integer
if (int.TryParse(userInput, out num) == true)
{
    // Check if number is odd or even
    if (num % 2 == 0)
    {
        Console.WriteLine($"Entered number {num} is even.");
    }
    else
    {
        Console.WriteLine($"Entered number {num} is odd.");
    }
}

Console.ReadKey();