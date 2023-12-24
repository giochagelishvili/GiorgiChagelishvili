using Exception_Practice.Classes;

namespace Exception_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User Giorgi = new User("Giorgi", "Chagelishvili");
            Giorgi.StartATM();
        }
    }
}
