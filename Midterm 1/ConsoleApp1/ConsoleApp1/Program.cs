int[] numArray = new int[] { 0, 1, 2, 3, 4 };
showPairs(4, numArray);

void showPairs(int number, int[] array)
{
    int length = array.Length;

    if (length <= 1)
        return;

    if (length == 2)
    {
        if (array[0] + array[1] == number)
        {
            Console.WriteLine($"{array[0]}, {array[1]}");
            return;
        }
        else
            return;
    }

    for (int i = 0, j = i + 1; i < length; j++)
    {
        if (j < length)
        {
            if (array[i] + array[j] == number)
            {
                Console.WriteLine($"{array[i]}, {array[j]}");

                if (j == length - 1)
                {
                    i++;

                    if (i == length - 1)
                        j = i - 1;
                    else
                        j = i;
                }
            }
            else if (j == length - 1)
            {
                i++;

                if (i == length - 1)
                    j = i - 1;
                else
                    j = i;
            }
        }
    }
}