string text = "Hello 1 !";

int letters = countLetters(text);
int numbers = countNumbers(text);

printStringDetails(text, letters, numbers);

// prints details of string
// e.g. Hello 1 ! - > letters: 5 , numbers: 1, Others: 3
void printStringDetails(string text, int letters, int numbers)
{
    char[] textToChars = text.ToCharArray();
    int counter = 0;

    // count symbols and spaces in the string
    foreach(char c in textToChars)
    {
        if (Char.IsLetter(c) == false && Char.IsDigit(c) == false)
            counter++;
    }

    Console.WriteLine($"\"{text}\" -> Letters: {letters}, Numbers: {numbers}, Others: {counter}");
}

// returns count of digits in the string
int countNumbers(string text)
{
    char[] textToChars = text.ToCharArray();
    int counter = 0;

    foreach (char c in textToChars)
    {
        if (Char.IsDigit(c))
            counter++;
    }

    return counter;
}

// returns count of letters in the string
int countLetters(string text)
{
    char[] textToChars = text.ToCharArray();
    int counter = 0;

    foreach (char c in textToChars)
    {
        if (Char.IsLetter(c))
            counter++;
    }

    return counter;
}