using Hangman.Exceptions;

namespace Hangman.Classes
{
    public class Game
    {
        private int Lives { get; set; } = 6;
        private bool GameOver { get; set; } = false;
        private string? Word { get; set; }

        private List<char> Letters = new List<char>();

        public void Start()
        {
            Word = GetRandomWord();
            DisplayLetters();

            do
            {
                try
                {
                    char letter = GetLetterInput();
                    CheckLetter(letter);
                }
                catch(InvalidInputException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (GameOver != true);
        }

        private void CheckLetter(char letter)
        {
            string lowerCaseWord = Word.ToLower();
            char lowerCaseLetter = Char.ToLower(letter);

            if (!lowerCaseWord.Contains(lowerCaseLetter))
            {
                WrongLetter();
                return;
            }

            ReplaceUnderscores(letter);
        }

        private void ReplaceUnderscores(char letter)
        {
            List<int> indexList = new List<int>();
            char[] letters = Word.ToLower().ToCharArray();

            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i] == letter)
                    indexList.Add(i);
            }

            foreach(int index in indexList) 
                Letters[index] = letter;

            if (!Letters.Contains('_'))
            {
                YouWin();
                return;
            }

            DisplayLetters();
        }

        private void YouWin()
        {
            Console.WriteLine(Word);
            Console.WriteLine("Congrats, you win!");
            GameOver = true;
        }

        private void WrongLetter()
        {
            Console.WriteLine("Wrong letter...");

            Lives -= 1;

            if (Lives < 0)
            {
                Console.WriteLine("Out of lives... You lost...");
                GameOver = true;
                return;
            }

            Console.WriteLine($"Lives left: {Lives}");
        }

        private char GetLetterInput()
        {
            Console.Write("Guess the letter: ");

            char letter = Console.ReadKey().KeyChar;

            Console.WriteLine("\n");

            if (Char.IsDigit(letter))
                throw new InvalidInputException("Word doesn't contain digits. Please provide a letter.");

            return letter;
        }

        private void DisplayLetters()
        {
            foreach (char letter in Letters)
                Console.Write(letter);

            Console.WriteLine("\n");
        }

        private string GetRandomWord()
        {
            string[] words = { "Apple", "Juice", "Man", "Woman", "Tea", "Meat" };

            Random random = new Random();
            int index = random.Next(0, words.Length - 1);

            for (int i = 0; i < words[index].Length; i++)
                Letters.Add('_');

            return words[index];
        }
    }
}
