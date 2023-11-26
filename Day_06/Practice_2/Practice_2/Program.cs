int[] numArray = { 1, 3, 123, 15, 13, 23, 98 };
int[] digitSum = calculateDigitSum(numArray, 6);

if (digitSum == null)
    return;

Console.WriteLine($"The sum of the digits of a number at index {digitSum[0]} is {digitSum[1]}");
Console.ReadKey();

int[] calculateDigitSum(int[] array, int index)
{
    if (index > array.Length - 1 || index < 0)
        return null;

    int num = array[index];
    int sum = 0;

    while (num > 0)
    {
        sum += num % 10;
        num /= 10;
    }

    return new int[] { index, sum };
}