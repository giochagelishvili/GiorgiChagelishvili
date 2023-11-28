string text = "Hello, world!";

printWithSpaces(text);

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