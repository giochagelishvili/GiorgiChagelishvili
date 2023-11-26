int[] numArray = createArray();

if (numArray == null)
    return;

int number = 6;
int fact = lookForNumber(numArray, number);

if (fact == -1)
    Console.WriteLine($"Number {number} was not found in the given array.");
else
    Console.WriteLine($"Factorial of {number} is {fact}.");

int lookForNumber(int[] array, int number)
{
    foreach (int num in array)
    {
        if (num == number)
            return factorial(num);
    }

    // Factorial can't be a negative number
    // So we return -1 if number was not found in the array
    return -1;
}

int factorial(int num)
{
    // 0! = 1
    if (num == 0) 
        return 1;

    int factorial = 1;

    for (int i = 1; i <= num; i++)
    {
        factorial *= i;
    }

    return factorial;
}

int[] createArray()
{
    Console.Write("Enter size of array: ");

    int size;
    bool sizeInput = int.TryParse(Console.ReadLine(), out size);

    if (sizeInput == false || size <= 0)
        return null;

    int[] array = new int[size];

    for (int i = 0; i < size; i++)
    {
        Console.Write($"Enter integer for index {i}: ");

        int num;
        bool numInput = int.TryParse(Console.ReadLine(), out num);

        if (numInput == false)
            return null;

        array[i] = num;
    }

    return array;
}