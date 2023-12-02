using Practice_1;

Console.WriteLine("Creating cat object...");

Cat cat = new Cat();

cat.Name = getStringInput("Enter name");
cat.Breed = getStringInput("Enter breed");
cat.Gender = getStringInput("Enter sex");
cat.Age = getIntInput("Enter age");

Console.WriteLine("Cat object created.");

int foodWeight = getIntInput("Enter food weight in grams");

Console.WriteLine($"{cat.Name} started eating.");

cat.Eat(foodWeight);

Console.WriteLine($"{cat.Name} finished eating.");

int meowCount = getIntInput("Enter meowing count");
cat.Meow(meowCount);

string getStringInput(string message)
{
    string? userInput;

    do
    {
        Console.Write($"{message}: ");
        userInput = Console.ReadLine();
    } while (userInput == null || userInput == "");

    return userInput;
}

int getIntInput(string message)
{
    bool userInput;
    int value;

    do
    {
        Console.Write($"{message}: ");
        userInput = int.TryParse(Console.ReadLine(), out value);
    } while (userInput != true);

    return value;
}