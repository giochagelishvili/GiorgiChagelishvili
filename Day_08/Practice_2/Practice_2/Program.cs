Console.WriteLine(calculateSum(13)); // head

Console.WriteLine("------------------------");

Console.WriteLine(calculateSumTail(13, 0)); // tail

// head recursion
int calculateSum(int num)
{
    if (num == 0)
        return 0;
    else
        return num + calculateSum(num - 1);
}

// tail recursion
int calculateSumTail(int num, int sum)
{
    if (num == 0)
        return sum;
    else
        return calculateSumTail(num - 1, sum + num);
}