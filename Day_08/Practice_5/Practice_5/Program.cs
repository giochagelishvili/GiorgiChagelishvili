bool ana = isPalindrome("ana");
bool anan = isPalindrome("anana");
bool aa = isPalindrome("aa");
bool empty = isPalindrome("");

Console.WriteLine($"Is palindrome? {ana}"); // input - ana
Console.WriteLine($"Is palindrome? {anan}"); // input - anan
Console.WriteLine($"Is palindrome? {aa}"); // input - aa
Console.WriteLine($"Is palindrome? {empty}"); // input - empty string

static bool isPalindrome(string text)
{
    int length = text.Length;

    if (length == 1 || length == 0)
        return true;

    if (text[0] != text[length - 1])
        return false;

    return isPalindrome(text.Substring(1, length - 2));
}