int[][] numArray = new int[][]
{
    new int[] {0, 1, 1, 1, 1, 1, 1, 1},
    new int[] {0, 0, 1, 1, 1, 1, 1, 1},
    new int[] {0, 0, 0, 1, 1, 1, 1, 1},
    new int[] {0, 0, 0, 0, 1, 1, 1, 1},
    new int[] {0, 0, 0, 0, 0, 1, 1, 1},
    new int[] {0, 0, 0, 0, 0, 0, 1, 1},
    new int[] {0, 0, 0, 0, 0, 0, 0, 1},
    new int[] {0, 0, 0, 0, 0, 0, 0, 0},
};

int length = numArray.Length;
int reverseRows = length - 1;

printArray(numArray);

for (int i = 0; i < length; i++)
{
    // i'th array length
    int currentArrayLength = numArray[i].Length;

    for (int j = 0; j < currentArrayLength; j++)
    {
        int firstNum = numArray[i][j];
        int secondNum = numArray[reverseRows][j];

        // Swap values
        numArray[i][j] = secondNum;
        numArray[reverseRows][j] = firstNum;
    }

    reverseRows--;
    
    // Break the loop in the middle (every row is swapped at this point)
    if (i == reverseRows)
        break;

    Console.WriteLine();
}

printArray(numArray);
Console.ReadKey();

void printArray(int[][] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        for (int j = 0; j < array[i].Length; j++)
        {
            Console.Write($"{array[i][j]}, ");
        }
        Console.WriteLine();
    }
}