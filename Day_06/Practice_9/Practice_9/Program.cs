int product = calculateProduct(1, 3, 4, 15, 13, 23, 98);
Console.WriteLine($"The product of array elements is: {product}");

int calculateProduct(params int[] nums)
{
    int result = 1;

    foreach (int num in nums)
        result *= num;

    return result;
}