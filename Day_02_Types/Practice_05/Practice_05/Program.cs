using System.Net.Http.Headers;

Console.WriteLine("Enter your day of birth: ");
var dayInput = Console.ReadLine();
int day;

Console.WriteLine("Enter your month of birth: ");
string? month = Console.ReadLine();

if (
    int.TryParse(dayInput, out day) == false ||
    month == null ||
    month == ""
   )
{
    return;
}

if (
    (month == "March" && (day >= 21 && day <= 31)) ||
    (month == "April" && (day >= 1 && day <= 19))
   )
{
    Console.WriteLine($"{day} {month} is Aries.");
    return;
}

if (
    (month == "April" && (day >= 20 && day <= 30)) ||
    (month == "May" && (day >= 1 && day <= 20))
   )
{
    Console.WriteLine($"{day} {month} is Taurus.");
    return;
}

if (
    (month == "May" && (day >= 21 && day <= 31)) ||
    (month == "June" && (day >= 1 && day <= 20))
   )
{
    Console.WriteLine($"{day} {month} is Gemini.");
    return;
}

if (
    (month == "June" && (day >= 21 && day <= 30)) ||
    (month == "July" && (day >= 1 && day <= 22))
   )
{
    Console.WriteLine($"{day} {month} is Cancer.");
    return;
}

if (
    (month == "July" && (day >= 23 && day <= 31)) ||
    (month == "August" && (day >= 1 && day <= 22))
   )
{
    Console.WriteLine($"{day} {month} is Leo.");
    return;
}

if (
    (month == "August" && (day >= 23 && day <= 31)) ||
    (month == "September" && (day >= 1 && day <= 22))
   )
{
    Console.WriteLine($"{day} {month} is Virgo.");
    return;
}

if (
    (month == "September" && (day >= 23 && day <= 30)) ||
    (month == "October" && (day >= 1 && day <= 22))
   )
{
    Console.WriteLine($"{day} {month} is Libra.");
    return;
}

if (
    (month == "October" && (day >= 23 && day <= 31)) ||
    (month == "November" && (day >= 1 && day <= 21))
   )
{
    Console.WriteLine($"{day} {month} is Scorpio.");
    return;
}

if (
    (month == "November" && (day >= 22 && day <= 30)) ||
    (month == "December" && (day >= 1 && day <= 21))
   )
{
    Console.WriteLine($"{day} {month} is Sagittarius.");
    return;
}

if (
    (month == "December" && (day >= 22 && day <= 31)) ||
    (month == "January" && (day >= 1 && day <= 19))
   )
{
    Console.WriteLine($"{day} {month} is Capricorn.");
    return;
}

if (
    (month == "January" && (day >= 20 && day <= 31)) ||
    (month == "February" && (day >= 1 && day <= 18))
   )
{
    Console.WriteLine($"{day} {month} is Aquarius.");
    return;
}

if (
    (month == "February" && (day >= 19 && day <= 29)) ||
    (month == "March" && (day >= 1 && day <= 20))
   )
{
    Console.WriteLine($"{day} {month} is Pisces.");
    return;
}