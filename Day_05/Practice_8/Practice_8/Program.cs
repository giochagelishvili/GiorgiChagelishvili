int[,] numArray = new int[8, 8]
{
    { 0, 1, 1, 1, 1, 1, 1, 1 },
    { 0, 0, 1, 1, 1, 1, 1, 1 },
    { 0, 0, 0, 1, 1, 1, 1, 1 },
    { 0, 0, 0, 0, 1, 1, 1, 1 },
    { 0, 0, 0, 0, 0, 1, 1, 1 },
    { 0, 0, 0, 0, 0, 0, 1, 1 },
    { 0, 0, 0, 0, 0, 0, 0, 1 },
    { 0, 0, 0, 0, 0, 0, 0, 0 }
};

int rows = 8;
int columns = 8;
int reverseRows = rows - 1;

printArray(numArray);

// Reverse rows. e.g. first and last row's columns should swap the values
// Meaning that first row becomes last row and last row becomes first row

// First row before swapping - 0, 1, 1, 1, 1, 1, 1, 1
// Last row before swapping - 0, 0, 0, 0, 0, 0, 0, 0

// First row after swapping - 0, 0, 0, 0, 0, 0, 0, 0
// Last row after swapping - 0, 1, 1, 1, 1, 1, 1, 1

// Same goes with 2nd and 2nd from last row & etc.
for (int i = 0; i < rows; i++)
{
    for (int j = 0;  j < columns; j++)
    {
        int firstNum = numArray[reverseRows, j];
        int secondNum = numArray[i, j];

        // Swap values
        numArray[i, j] = firstNum;
        numArray[reverseRows, j] = secondNum;
    }

    reverseRows--;

    // Break the loop in the middle (every row is swapped at this point)
    if (i == reverseRows)
        break;

    Console.WriteLine();
}

printArray(numArray);
Console.ReadKey();

void printArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}, ");
        }
        Console.WriteLine();
    }
}