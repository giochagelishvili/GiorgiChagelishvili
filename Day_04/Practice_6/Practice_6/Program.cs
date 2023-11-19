Console.Write("Enter a number: ");
int num;
bool userInput = int.TryParse(Console.ReadLine(), out num);

if (userInput == false)
    return;

// First divisor of every number is 1
string divisors = "1";

for (int i = 1; i <= num; i++)
{
    if (num % i == 0 && i != 1)
        divisors += $", {i}";
}

Console.WriteLine($"Divisors of {num} are: {divisors}");
Console.ReadKey();