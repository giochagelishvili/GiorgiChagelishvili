int[] numArray = new int[] { 1, 2, 3, 4, 5, 7 };
Console.WriteLine(findElement(numArray));

int findElement(int[] array)
{
    int length = array.Length;
    int maxNum = length + 1;
    bool isMissing = true;
    
    for (int i = 0; i < length; i++)
    {
        for (int j = 0; j < length; j++)
        {
            if (array[j] == maxNum)
            {
                isMissing = false;
                i++;
                j = 0;
                maxNum -= 1;
                continue;
            }
        }
        isMissing = true;
    }

    if (isMissing == true)
        return maxNum;

    return 0;
}