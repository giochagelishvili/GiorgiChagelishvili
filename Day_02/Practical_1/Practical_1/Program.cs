Console.WriteLine("Enter first number: ");
int firstNum;
bool firstInput = int.TryParse(Console.ReadLine(), out firstNum);

Console.WriteLine("Enter second number: ");
int secondNum;
bool secondInput = int.TryParse(Console.ReadLine(), out secondNum);

if (firstInput == true && secondInput == true)
{
    swapNumbers(firstNum, secondNum);
}

Console.ReadKey();

static void swapNumbers(int firstNum, int secondNum)
{
    firstNum += secondNum;
    secondNum = firstNum - secondNum;
    firstNum = firstNum - secondNum;

    Console.WriteLine($"First number: {firstNum}");
    Console.WriteLine($"Second number: {secondNum}");
}

static void swapWithThirdVar(int firstNum, int secondNum)
{
    int temp = firstNum;
    firstNum = secondNum;
    secondNum = temp;

    Console.WriteLine($"First number: {firstNum}");
    Console.WriteLine($"Second number: {secondNum}");
}