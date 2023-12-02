Console.WriteLine(calculatePower(2, 10)); // head

Console.WriteLine("-------------------------");

Console.WriteLine(calculatePowerTail(2, 2)); // tail

// head recursion
int calculatePower(int num, int degree)
{
    if (degree <= 1)
        return num;
    else
        return num * calculatePower(num, degree - 1);
}

// tail recursion
int calculatePowerTail(int num, int degree, int result = 1)
{
    if (degree < 1)
        return result;
    else
        return calculatePowerTail(num, degree - 1, result * num);
}