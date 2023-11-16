Console.WriteLine("Enter a year: ");
int year;
bool yearInput = int.TryParse(Console.ReadLine(), out year);

if (yearInput == true)
{
    bool isLeapYear = checkLeapYear(year);
    Console.WriteLine(isLeapYear);
}

static bool checkLeapYear(int year)
{
    if (year % 4 == 0 && year % 100 != 0)
        return true;

    if (year % 4 == 0 && year % 100 == 0 && year % 400 == 0)
        return true;

    return false;
}