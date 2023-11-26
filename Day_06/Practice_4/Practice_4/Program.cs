int[] numArray = createArray();

if (numArray == null)
    return;

float average = calculateAverage(numArray);
string roundedAverage = average.ToString("#.##");

Console.WriteLine($"Arithmetic average of array is: {roundedAverage}");
Console.ReadKey();

float calculateAverage(int[] array)
{
    int length = array.Length;
    int sum = 0;

    foreach (int num in array)
        sum += num;

    // Round float value to 2 decimal points
    float average = (float)sum / length;

    return average;
}

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