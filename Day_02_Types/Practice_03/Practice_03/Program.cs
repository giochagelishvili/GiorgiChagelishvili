Console.WriteLine("Enter number: ");

var userInput = Console.ReadLine();
int num;

if (int.TryParse(userInput, out num) == true)
{
    int pow = (int)Math.Pow(num, 2);
    Console.WriteLine($"The pow of the entered number is: {pow}");
}