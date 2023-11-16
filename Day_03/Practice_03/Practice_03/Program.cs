Console.WriteLine("Enter number: ");

int num;
bool userInput = int.TryParse(Console.ReadLine(), out num);

if (userInput == true)
{
    int pow = (int)Math.Pow(num, 2);
    Console.WriteLine($"The pow of the entered number is: {pow}");
    Console.ReadKey();
}