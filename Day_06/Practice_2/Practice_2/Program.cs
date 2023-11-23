int[] numArray = { 1, 3, 123, 15, 13, 23, 98 };

calculateDigitSum(numArray, 6);

Console.ReadKey();

void calculateDigitSum(int[] array, int index)
{
    if (index > array.Length - 1 || index < 0)
        return;

    int num = array[index];
    int sum = 0;

    while (num > 0)
    {
        sum += num % 10;
        num /= 10;
    }

    Console.WriteLine($"The sum of the digits of a number at index {index} is {sum}");
}