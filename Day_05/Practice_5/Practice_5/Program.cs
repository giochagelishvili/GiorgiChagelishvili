Console.Write("Enter array size: ");
int arraySize;
bool arraySizeInput = int.TryParse(Console.ReadLine(), out arraySize);

if (arraySizeInput == false || arraySize <= 0)
    return;

int[] numArray = new int[arraySize];

for (int i = 0; i < arraySize; i++)
{
    Console.Write($"Enter number for index {i}: ");

    int num;
    bool numInput = int.TryParse(Console.ReadLine(), out num);

    if (numInput == false) 
        return;

    numArray[i] = num;
}

Console.WriteLine("Unique elements of array are: ");

for (int i = 0; i < arraySize; i++)
{
    int currentNum = numArray[i];
    bool unique = true;

    for (int j = 0; j < arraySize; j++)
    {
        if (numArray[j] == currentNum && j != i)
            unique = false;
    }

    if (unique == true)
        Console.WriteLine(currentNum);
}

Console.ReadKey();