int num = 9;
Console.WriteLine(toBinary(num));

string toBinary(int num)
{
    string result = "";

    while (num > 0)
    {
        int remainder = num % 2;
        result = remainder.ToString() + result;
        num /= 2;
    }

    return result;
}