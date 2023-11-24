Console.Write("Enter array size: ");
int arraySize;
bool arraySizeInput = int.TryParse(Console.ReadLine(), out arraySize);

if (arraySizeInput == false || arraySize <= 0)
    return;

int[] numArray = new int[arraySize];

for (int i = 0; i < arraySize; i++)
{
    Console.Write($"Enter a number for index {i}: ");

    int num;
    bool numInput = int.TryParse(Console.ReadLine(), out num);

    if (numInput == false) 
        return;

    numArray[i] = num;
}

Console.WriteLine("Here is your array!");

foreach (int num in numArray)
    Console.WriteLine(num);

Console.ReadKey();