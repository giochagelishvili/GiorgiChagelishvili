printNumsTail(1, 13);

// head recursion
int printNumsHead(int num)
{
    if (num == 0)
        return 0;
    else
    {
        int result = 1 + printNumsHead(num - 1);
        Console.Write($"{result} ");
        return result;
    }
}

// tail recursion from 13 to 1
int printNumsTailReverse(int num)
{
    Console.Write($"{num} ");

    if (num == 1)
        return 1;
    else
        return printNumsTailReverse(num - 1);
}

// tail recursion from 1 to 13
int printNumsTail(int startNum, int endNum)
{
    Console.WriteLine(startNum);

    if (startNum == endNum)
        return startNum;
    else
        return printNumsTail(startNum + 1, endNum);
}