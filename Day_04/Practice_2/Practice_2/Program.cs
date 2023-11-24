Console.Write("Enter a number: ");
int num;
bool userInput = int.TryParse(Console.ReadLine(), out num);

if (userInput == false)
    return;

int sum = 0;

for (int i = 0; i <= num; i++)
{
    sum += i;
}

Console.WriteLine($"Sum from 0 to {num} is {sum}");
Console.ReadKey();