printNumsHead(13); // head

Console.WriteLine();
Console.WriteLine("-------------------------");

printNumsTail(13); // tail from 13 to 1

Console.WriteLine();
Console.WriteLine("-------------------------");

printNumsTailReverse(1, 13); // tail from 1 to 13

// head recursion
void printNumsHead(int num)
{
    if (num == 0)
        return;
    else
        printNumsHead(num - 1);

    Console.Write($"{num} ");
}

// tail recursion from 13 to 1
void printNumsTail(int num)
{
    Console.Write($"{num} ");

    if (num == 1)
        return;
    else
        printNumsTail(num - 1);
}

// tail recursion from 1 to 13
void printNumsTailReverse(int startNum, int endNum)
{
    Console.Write($"{startNum} ");

    if (startNum == endNum)
        return;
    else
        printNumsTailReverse(startNum + 1, endNum);
}