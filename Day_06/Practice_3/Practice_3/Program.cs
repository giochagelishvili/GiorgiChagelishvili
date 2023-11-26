int[] numArray = createArray();

if (numArray == null)
    return;

int[] minMax = findMinMax(numArray);

Console.WriteLine($"The minimum number in the array is: {minMax[0]}");
Console.WriteLine($"The maximum number in the array is: {minMax[1]}");

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

int[] findMinMax(int[] numArray)
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

    return new int[] { min, max };
}