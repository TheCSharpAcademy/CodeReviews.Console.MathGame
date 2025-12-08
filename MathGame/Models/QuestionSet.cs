namespace MathGame.Models
{
    internal class QuestionSet
    {
        public string Question { get; set; }
        public int Answer { get; set; }

        public QuestionSet(string question, int answer)
        {
            Question = question;
            Answer = answer;
        }
    }

}
