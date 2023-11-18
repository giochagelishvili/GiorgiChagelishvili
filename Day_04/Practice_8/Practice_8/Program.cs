Console.WriteLine("Enter a number: ");
int num;
bool userInput = int.TryParse(Console.ReadLine(), out num);

if (userInput == false)
    return;

string binaryValue = "";

while (num > 0)
{
    int remainder = num % 2;
    binaryValue = remainder + binaryValue;
    num /= 2;
}

Console.WriteLine(binaryValue);
Console.ReadKey();