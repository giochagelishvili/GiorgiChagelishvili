string text = "Hello, world!";
string reversedText = reverseText(text);

Console.WriteLine(reversedText) ;
string reverseText(string text)
{
    // transform string into char array and reverse it
    char[] textAsChars = text.ToCharArray();
    Array.Reverse(textAsChars);

    // create new string from char array and return it
    return new string(textAsChars);
}