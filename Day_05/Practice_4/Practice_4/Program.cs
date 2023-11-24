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

int product = 1;

foreach (int num in numArray)
    product *= num;

Console.WriteLine($"Product of array elements is: {product}");
Console.ReadKey();