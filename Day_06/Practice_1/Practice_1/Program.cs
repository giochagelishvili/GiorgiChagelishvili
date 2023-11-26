int[] numArray = { 1, 3, 4, 15, 13, 23, 98 };

printNum(numArray, 4);
Console.ReadKey();

void printNum(int[] array, int index)
{
    if (index > array.Length - 1 || index < 0)
        return;

    Console.WriteLine($"Number at index {index} in the array is {array[index]}");
}