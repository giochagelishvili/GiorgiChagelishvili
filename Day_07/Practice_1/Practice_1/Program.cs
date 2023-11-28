string text = "Hello, world!";

string vowelIdentifier = "Vowels";
string consonantIdentifier = "Consonants";

Console.WriteLine($"Vowel count: {countVowsOrCons(text, vowelIdentifier)}");
Console.Write("Vowels: ");
printVowsOrCons(text, vowelIdentifier);

Console.WriteLine();
Console.WriteLine();

Console.WriteLine($"Consonants count: {countVowsOrCons(text, consonantIdentifier)}");
Console.Write("Consonants: ");
printVowsOrCons(text, consonantIdentifier);

Console.WriteLine();
Console.WriteLine();


int countVowsOrCons(string text, string identifier)
{
    string vowels = "aeiouAEIOU";

    // transform string into char array
    char[] textAsChars = text.ToCharArray();

    int counter = 0;

    if (identifier == "Consonants")
    {
        foreach (char c in textAsChars)
        {
            if (vowels.Contains(c) == false && Char.IsLetter(c))
                counter++;
        }
    }
    else
    {
        foreach (char c in textAsChars)
        {
            if (vowels.Contains(c))
                counter++;
        }
    }

    return counter;
}

void printVowsOrCons(string text, string identifier)
{
    string vowels = "aeiouAEIOU";
    char[] textAsChars = text.ToCharArray();

    string result = "";

    if (identifier == "Consonants")
        foreach (char c in textAsChars)
        {
            if (vowels.Contains(c) == false && Char.IsLetter(c))
                result += $"{c} ";
        }
    else
        foreach (char c in textAsChars)
        {
            if (vowels.Contains(c))
                result += $"{c} ";
        }

    Console.Write(result);
}