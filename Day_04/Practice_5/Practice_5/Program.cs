Console.Write("Enter a number: ");
int rows;
bool userInput = int.TryParse(Console.ReadLine(), out rows);

if (userInput == false || rows == 0)
    return;

for (int i = 0; i < rows; i++)
{
    // First row is always 1 in Floyd's triangle
    if (i == 0)
        Console.Write("1");

    // Print columns
    for (int j = 0; j < i + 1; j++)
    {
        // If row is odd, odd columns are 1s and even columns are 0s
        // If row is even, odd columns are 0s and even columns are 1s
        if (i % 2 != 0)
        {
            if (j % 2 != 0)
                Console.Write("1");
            else
                Console.Write("0");
        }
        else if (i % 2 == 0 && i != 0)
        {
            if (j % 2 != 0)
                Console.Write("0");
            else
                Console.Write("1");
        }
    }

    Console.WriteLine();
}

Console.ReadKey();