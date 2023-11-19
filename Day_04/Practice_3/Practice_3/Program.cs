Console.Write("Enter a number: ");
int num;
bool userInput = int.TryParse(Console.ReadLine(), out num);

if (userInput == false)
    return;

for (int i = 1; i <= num; i++)
{
    int cube = (int)Math.Pow(i, 3);
    Console.WriteLine($"{i} cubed is {cube}");
}

Console.ReadKey();