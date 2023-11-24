Console.Write("Enter a number: ");
int num;
bool userInput = int.TryParse(Console.ReadLine(), out num);

if (userInput == false)
    return;

int sum = 0;

for (int i = 1; i <= num; i++)
{
    if (i % 2 != 0)
        sum += i;
}

Console.WriteLine($"Sum of odd numbers from 1 to {num} is {sum}");
Console.ReadKey();