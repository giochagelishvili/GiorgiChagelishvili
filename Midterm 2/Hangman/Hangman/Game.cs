namespace Hangman
{
    public class Game
    {
        private string Word {  get; set; }
        private bool GameOver = false;
        private List<int> LetterIndex = new List<int>();
        private int Lives = 7;

        public Game(string word)
        {
            Word = word;
            StartGame();
        }

        private void StartGame()
        {
            int wordLength = Word.Length;

            Console.WriteLine(Word);

            for (int i = 0; i < wordLength; i++)
                Console.Write("_");

            Console.WriteLine();

            while (GameOver != true) 
            {
                char letter = GetLetter();

                if (CheckLetter(letter))
                    ShowLetters();
                else
                {
                    Lives--;

                    if(Lives <= 1)
                    {
                        LivesLost();
                        GameOver = true;
                        Console.WriteLine("You lost.");
                    }
                    else
                    {
                        LivesLost();
                    }
                }

                if (LetterIndex.Count == Word.Length)
                {
                    GameOver = true;
                    Console.WriteLine("You win!");
                }

            }
        }

        private void LivesLost()
        {
            switch (Lives)
            {
                case 6:
                    Console.WriteLine("Left Leg");
                    break;
                case 5:
                    Console.WriteLine("Right Leg");
                    break;
                case 4:
                    Console.WriteLine("Body");
                    break;
                case 3:
                    Console.WriteLine("Left Hand");
                    break;
                case 2:
                    Console.WriteLine("Right Hand");
                    break;
                case 1:
                    Console.WriteLine("Head");
                    break;
            }
                
        }

        private void ShowLetters()
        {
            LetterIndex.Sort();
            int listIndexer = 0;
            char[] chars = Word.ToCharArray();

            for (int i = 0; i < Word.Length; i++)
            {
                if (i == LetterIndex[listIndexer])
                {
                    Console.Write(chars[i]);

                    if (listIndexer < LetterIndex.Count - 1)
                        listIndexer++;
                }
                else
                {
                    Console.Write("_");
                }
            }

            Console.WriteLine();
        }

        private bool CheckLetter(char letter)
        {
            bool contains = false;

            char[] charArray = Word.ToCharArray();

            for (int i = 0; i < Word.Length; i++)
            {
                if (char.ToLower(charArray[i]) == char.ToLower(letter))
                {
                    LetterIndex.Add(i);
                    contains = true;
                }
            }

            if (contains == false)
                return false;

            return true;
        }

        private char GetLetter()
        {
            char letter;

            do
            {
                letter = (char)Console.Read();
            } while (!char.IsLetter(letter));

            return letter;
        }
    }
}
