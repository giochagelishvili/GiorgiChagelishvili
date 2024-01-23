namespace Testing_Time.Classes
{
    public class Question
    {
        public string? QuestionText { get; set; }
        public string? AnswerA { get; set; }
        public string? AnswerB { get; set; }
        public string? AnswerC { get; set; }
        public string? AnswerD { get; set; }
        private string? CorrectAnswer { get; set; }

        public Question(string? questionText, string? answerA, string? answerB, string? answerC, string? answerD)
        {
            QuestionText = questionText;

            if (answerA.Contains('*'))
            {
                AnswerA = answerA.Remove(answerA.Length - 1);
                CorrectAnswer = AnswerA;
            }
            else
                AnswerA = answerA;

            if (answerB.Contains('*'))
            {
                AnswerB = answerB.Remove(answerB.Length - 1);
                CorrectAnswer = AnswerB;
            }
            else
                AnswerB = answerB;

            if (answerC.Contains('*'))
            {
                AnswerC = answerC.Remove(answerC.Length - 1);
                CorrectAnswer = AnswerC;
            }
            else
                AnswerC = answerC;

            if (answerD.Contains('*'))
            {
                AnswerD = answerD.Remove(answerD.Length - 1);
                CorrectAnswer = AnswerD;
            }
            else
                AnswerD = answerD;
        }

        public void DisplayQuestion()
        {
            Console.WriteLine(QuestionText);
            Console.WriteLine(AnswerA);
            Console.WriteLine(AnswerB);
            Console.WriteLine(AnswerC);
            Console.WriteLine(AnswerD);
        }

        public bool CheckAnswer(char answer)
        {
            answer = Char.ToLower(answer);

            Console.WriteLine($"Correct answer: {CorrectAnswer} \n");

            if (answer == 'a' && CorrectAnswer == AnswerA)
                return true;

            if (answer == 'b' && CorrectAnswer == AnswerB)
                return true;

            if (answer == 'c' && CorrectAnswer == AnswerC)
                return true;

            if (answer == 'd' && CorrectAnswer == AnswerD)
                return true;

            return false;
        }
    }
}
