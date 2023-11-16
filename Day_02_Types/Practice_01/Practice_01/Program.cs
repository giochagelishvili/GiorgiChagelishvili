Console.WriteLine("Enter integer number: ");

int num;

// Try parsing user input into integer
bool userInput = int.TryParse(Console.ReadLine(), out num);

if (userInput == true)
{
    isOdd(num);
}

// Check if passed number is even or odd
static void isOdd(int num)
{
    if (num % 2 == 0)
        Console.WriteLine($"Entered number {num} is even.");
    else
        Console.WriteLine($"Entered number {num} is odd.");
}

Console.ReadKey();