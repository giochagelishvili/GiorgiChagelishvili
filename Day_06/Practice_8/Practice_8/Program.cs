int num = getNumber();

if (num == 0)
    return;

powersOfTen(num);

void powersOfTen(int num)
{
    // Power indicator
    int power = 0;

    // Save copy of num for output
    int numCopy = num;

    // Initialize the string for displaying num in powers of ten
    string powersOfTen = "";

    while (num > 0)
    {
        int currentDigit = num % 10;
        num /= 10;

        // e.g. if num = 1230, currentDigit = 0, power = 0
        // powerOfTen = 0 * 10^0
        string powerOfTen = $"{currentDigit} * 10^{power}";

        if (power != 0)
            powerOfTen += " + ";

        powersOfTen = powerOfTen + powersOfTen;

        power++;
    }

    Console.WriteLine($"{numCopy} = {powersOfTen}");
}

int getNumber()
{
    Console.Write("Enter positive number: ");

    int num;
    bool numInput = int.TryParse(Console.ReadLine(), out num);

    if (numInput == false || num <= 0)
        return 0;

    return num;
}