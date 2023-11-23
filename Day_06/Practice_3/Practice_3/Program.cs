int[] numArray = createArray();

if (numArray == null)
    return;

findMinMax(numArray);
Console.ReadKey();

int[] createArray()
{
    Console.Write("Enter size of array: ");

    int size;
    bool sizeInput = int.TryParse(Console.ReadLine(), out size);

    if (sizeInput == false || size <= 0)
        return null;

    int[] numArray = new int[size];

    for (int i = 0; i < size; i++)
    {
        Console.Write($"Enter integer for index {i}: ");

        int num;
        bool numInput = int.TryParse(Console.ReadLine(), out num);

        if (numInput == false)
            return null;

        numArray[i] = num;
    }

    return numArray;
}

void findMinMax(int[] numArray)
{
    int min = numArray[0];
    int max = numArray[0];

    foreach (int num in numArray)
    {
        if (num < min)
            min = num;
        else if (num > max)
            max = num;
    }

    Console.WriteLine($"The minimum number in the array is: {min}");
    Console.WriteLine($"The maximum number in the array is: {max}");
}