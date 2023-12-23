namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] wordArray = new string[] { "Apple", "Banana", "Wakanda", "Tea", "Fight" };

            Random random = new Random();
            int wordIndex = random.Next(0, wordArray.Length - 1);

            Game game = new Game(wordArray[wordIndex]);
        }
    }
}
