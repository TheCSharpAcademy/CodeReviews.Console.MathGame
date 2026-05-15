
using MathGame.src.enums;
using MathGame.src.utility;

namespace MathGame.src
{

    class Game
    {
        private static Dictionary<String, List<String>> previousGames = [];
        private Question question = new();
        private Score score = new();


        public void StartGame()
        {
            int Qcount = question.QuestionsCount();
            for (int count = 0; count < Qcount; count++)
            {
                String _question = question.GenerateQuestion();
                Console.WriteLine(_question);
                string? input = Console.ReadLine();
                int answer;
                while (!int.TryParse(input, out answer))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    input = Console.ReadLine();
                }
                if (question.EvaluateAnswer(answer)) score.IncrementScore();
            }
            Console.WriteLine(StringLiterals.GameOver);
            Console.WriteLine(score.GetScore() == Qcount ? StringLiterals.Congratulations : "");
            Console.WriteLine("You have scored: {0}", score.GetScore());
            UpdatePrevListAndReset();
        }
        private void UpdatePrevListAndReset()
        {
            previousGames.Add(DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), question.GetUserAnsweredQuestions());
            score.ResetScore();
        }

        public void GetPrevQuestions()
        {
            if (previousGames.Count == 0)
            {
                Console.WriteLine("No Records");
            }

            foreach (var questions in previousGames.Values)
            {
                foreach (String question in questions)
                {
                    Console.WriteLine(question);
                }
            }
        }


    }
}