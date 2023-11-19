Console.Write("Enter a number: ");
int rows;
bool userInput = int.TryParse(Console.ReadLine(), out rows);

if (userInput == false || rows == 0)
    return;

// First row is always 1 in Floyd's triangle
int firstNum = 1;
Console.WriteLine(firstNum);

for (int i = 0; i < rows - 1; i++)
{
    // If row is odd first number is 1 else it's 0
    if (i % 2 != 0)
        firstNum = 1;
    else
        firstNum = 0;

    Console.Write(firstNum);

    // Print the columns
    for (int j = 0; j < i + 1; j++)
    {
        // If row is even, even columns are 1s, odd columns are 0s
        // If row is odd, even columns are 0s, odd columns are 1s
        if (firstNum == 0)
        {
            if (j % 2 == 0)
                Console.Write("1");
            else
                Console.Write("0");
        }
        else
        {
            if (j % 2 == 0)
                Console.Write("0");
            else
                Console.Write("1");
        }
    }

    Console.WriteLine();
}

Console.ReadKey();