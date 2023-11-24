Console.WriteLine("Enter a number: ");
int num;
bool userInput = int.TryParse(Console.ReadLine(), out num);

if(userInput == false)
    return;

int counter = 0;

int firstNum = 0;
int secondNum = 1;
int sum;

while (counter <= num)
{
    Console.Write(firstNum);
    
    if (counter != num)
        Console.Write(", ");

    sum = firstNum + secondNum;
    firstNum = secondNum;
    secondNum = sum;

    counter++;
}