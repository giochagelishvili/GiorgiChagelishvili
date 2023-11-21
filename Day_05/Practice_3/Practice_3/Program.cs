Console.Write("Enter array size: ");
int arraySize;
bool arraySizeInput = int.TryParse(Console.ReadLine(), out arraySize);

if (arraySizeInput == false)
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

int sum = 0;

foreach (int num in numArray)
    sum += num;

Console.WriteLine($"Sum of array elements is: {sum}");
Console.ReadKey();