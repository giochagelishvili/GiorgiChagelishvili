Console.WriteLine(countDigits(999)); // head

Console.WriteLine("------------------------");

Console.WriteLine(countDigitsTail(999)); // tail

// head recursion
int countDigits(int num)
{
    if (num <= 0)
        return 0;
    else
        return 1 + countDigits(num / 10);
}

// tail recursion
int countDigitsTail(int num, int digits = 0)
{
    if (num <= 0)
        return digits;
    else
        return countDigitsTail(num / 10, ++digits);
}