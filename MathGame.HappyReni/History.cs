namespace MathGame
{
    internal class History
    {
        public History(DateTime time, string question, int correctAnswer, int answer, string result)
        {
            Time = time;
            Question = question;
            CorrectAnswer = correctAnswer;
            Answer = answer;
            Result = result;
        }

        public DateTime Time { get; set; }
        public String Question { get; set; }
        public int CorrectAnswer { get; set; }

        public int Answer { get; set; }
        public string Result { get; set; }

    }
}
