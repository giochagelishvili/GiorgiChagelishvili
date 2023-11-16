Console.WriteLine("Enter your birth year: ");

int birthYear;
bool userInput = int.TryParse(Console.ReadLine(), out birthYear);

// Stop further code execution if user input is not an integer
if (userInput == false)
{
    return;
}

switch (birthYear % 12)
{
    case 4:
        Console.WriteLine($"{birthYear} was a Rat year!");
        break;
    case 5:
        Console.WriteLine($"{birthYear} was a Ox year!");
        break;
    case 6:
        Console.WriteLine($"{birthYear} was a Tiger year!");
        break;
    case 7:
        Console.WriteLine($"{birthYear} was a Rabbit year!");
        break;
    case 8:
        Console.WriteLine($"{birthYear} was a Dragon year!");
        break;
    case 9:
        Console.WriteLine($"{birthYear} was a Snake year!");
        break;
    case 10:
        Console.WriteLine($"{birthYear} was a Horse year!");
        break;
    case 11:
        Console.WriteLine($"{birthYear} was a Sheep year!");
        break;
    case 0:
        Console.WriteLine($"{birthYear} was a Monkey year!");
        break;
    case 1:
        Console.WriteLine($"{birthYear} was a Rooster year!");
        break;
    case 2:
        Console.WriteLine($"{birthYear} was a Dog year!");
        break;
    case 3:
        Console.WriteLine($"{birthYear} was a Pig year!");
        break;
}