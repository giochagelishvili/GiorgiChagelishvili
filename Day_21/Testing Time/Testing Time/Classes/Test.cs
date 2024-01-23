using Testing_Time.Exceptions;

namespace Testing_Time.Classes
{
    public class Test
    {
        private int CorrectAnswers { get; set; } = 0;

        public void Run()
        {
            Console.WriteLine("1) Start test");
            Console.WriteLine("2) Add test");

            int userInput = 0;

            while(userInput < 1 || userInput > 2)
            {
                try
                {
                    userInput = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (userInput == 1)
                StartTest();
            else if (userInput == 2)
                AddTest();
        }

        private void StartTest()
        {
            List<Question> questions = ReadQuestions();

            foreach(Question question in questions) 
            {
                question.DisplayQuestion();
                char answer = GetAnswer();

                if (question.CheckAnswer(answer))
                    CorrectAnswers++;
            }

            Console.WriteLine($"Your result is: {CorrectAnswers}/{questions.Count}");
        }

        private char GetAnswer()
        {
            Console.Write("Please choose answer: ");

            char answer = '0';

            while (answer != 'a' && answer != 'b' && answer != 'c' && answer != 'd')
            {
                try
                {
                    answer = Console.ReadKey().KeyChar;

                    Console.WriteLine("\n");

                    if (answer != 'a' && answer != 'b' && answer != 'c' && answer != 'd')
                        throw new InvalidAnswerInputException();
                }
                catch(InvalidAnswerInputException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return answer;
        }

        private List<Question> ReadQuestions()
        {
            string path = "C:\\Users\\user\\Desktop\\Tests.txt";

            List<Question> questions = new List<Question>();

            using (StreamReader sr = new StreamReader(path))
            {
                var line = sr.ReadLine();

                while (line != null)
                {
                    string[] lineArray = line.Split('|');

                    string question = lineArray[0];
                    string a = lineArray[1];
                    string b = lineArray[2];
                    string c = lineArray[3];
                    string d = lineArray[4];

                    questions.Add(new Question(question, a, b, c, d));

                    line = sr.ReadLine();
                }
            }

            return questions;
        }

        private void AddTest()
        {
            Console.Write("Enter a question: ");
            string question = GetStringInput();

            Console.WriteLine("Please mark correct answer with '*' symbol.");

            Console.Write("Answer A) ");
            string answerA = GetStringInput();

            Console.Write("Answer B) ");
            string answerB = GetStringInput();

            Console.Write("Answer C) ");
            string answerC = GetStringInput();

            Console.Write("Answer D) ");
            string answerD = GetStringInput();

            string formattedQuestion = $"{question}|a){answerA}|b){answerB}|c){answerC}|d){answerD}";

            WriteQuestion(formattedQuestion);
        }

        private void WriteQuestion(string question)
        {
            string path = "C:\\Users\\user\\Desktop\\Tests.txt";
            string[] lines = File.ReadAllLines(path);
            int numberOfLines = lines.Length;

            using (StreamWriter sw = File.AppendText(path))
            {
                if(numberOfLines > 0)
                    sw.Write(Environment.NewLine);

                sw.Write($"{numberOfLines + 1}){question}");
            }
        }

        private string GetStringInput()
        {
            string text = "";

            while (text == "" || text == null)
            {
                try
                {
                    text = Console.ReadLine();

                    if (text == "" || text == null)
                        throw new MustHaveTextException();
                }
                catch (MustHaveTextException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return text;
        }
    }
}
