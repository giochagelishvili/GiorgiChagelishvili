string text = "Hello, world!";

printNum(countWords(text));

void printNum(int num)
{
    Console.WriteLine(num);
}

int countWords(string text)
{
    if (text == "")
        return 0;

    string[] words = text.Split(' ');

    return words.Length;
}