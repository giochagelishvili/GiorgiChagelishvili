using Practices;

Console.WriteLine("Pow method: ");

int firstNum = GetIntInput("Enter number"); // Get number input from the user
int secondNum = GetIntInput("Enter power"); // Get power input from the user

string status; // Status will be saved in this variable
int result = MathMethods.Pow(firstNum, secondNum, out status); // Call Pow() method and save returned value in result

// Print status and result to the user
Console.Write($"Status: {status} \nResult: {result}\n");

Console.WriteLine("=========================================================="); // Divider

Console.WriteLine("Min method: ");

firstNum = GetIntInput("Enter first number"); // Get first number input from the user
secondNum = GetIntInput("Enter second number"); // Get second number input from the user

result = MathMethods.Min(firstNum, secondNum, out status); // Call Min() method and save value in result variable

// Print status and result
Console.Write($"Status: {status} \nResult: {result}\n");

Console.WriteLine("==========================================================");

Console.WriteLine("Max method: ");

firstNum = GetIntInput("Enter first number"); // Get first input 
secondNum = GetIntInput("Enter second number"); // Get second input

result = MathMethods.Max(firstNum, secondNum, out status); // Call Max() method and save value in result variable

Console.Write($"Status: {status} \nResult: {result}\n");

// Prints the message passed as a parameter
// Prompts the user for input until user enters an integer value
// Returns user input
int GetIntInput(string message)
{
    Console.Write($"{message}: ");

    int num;
    bool userInput;

    do
    {
        userInput = int.TryParse(Console.ReadLine(), out num );
    } while ( userInput != true );

    return num;
}