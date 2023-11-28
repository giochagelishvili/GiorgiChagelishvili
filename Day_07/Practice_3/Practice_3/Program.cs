string text = "Hello, world!";

printWithSpaces(text);

Console.WriteLine();
Console.WriteLine();

printWithSpacesJoin(text);

void printWithSpaces(string text)
{
    char[] textAsChars = text.ToCharArray();

    foreach(char c in textAsChars)
    {
        // print out everything except for spaces (space's ascii value = 32)
        if (c != 32)
            Console.Write($"{c} ");
    }
}

// this method is using .Join built-in method
// problem with "printWithSpacesJoin" is that it will treat
// spaces as symbols and it will print double spaces
void printWithSpacesJoin(string text)
{
    char[] textAsChars = text.ToCharArray();

    string result = String.Join(" ", textAsChars);

    Console.WriteLine(result);
}