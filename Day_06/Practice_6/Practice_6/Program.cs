char[] charArray = createCharArray();

if (charArray == null)
    return;

char symbol = 'a';
int counter = lookForSymbol(charArray, symbol);

Console.WriteLine($"'{symbol}' shegvxvda {counter}-jer");

int lookForSymbol(char[] charArray, char symbol)
{
    int counter = 0;
    
    foreach(char c in charArray)
    {
        if (c == symbol)
            counter++;
    }

    return counter;
}
char[] createCharArray()
{
    Console.Write("Enter size of array: ");

    int size;
    bool sizeInput = int.TryParse(Console.ReadLine(), out size);

    if (sizeInput == false || size <= 0)
        return null;

    char[] charArray = new char[size];

    for (int i = 0; i < size; i++)
    {
        Console.Write($"Enter character for index {i}: ");

        char character;
        bool characterInput = char.TryParse(Console.ReadLine(), out character);

        if (characterInput == false)
            return null;

        charArray[i] = character;
    }

    return charArray;
}