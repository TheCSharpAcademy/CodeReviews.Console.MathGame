namespace MathGame.alvaromosconi
{
    internal class GameEngine
    {
        private const int QUESTIONS_NUMBER = 5;
        private int score;

        internal int RunGame(string gameChoice)
        {
            switch (gameChoice)
            {
                case "1":
                    return RunAdditionGame("---Addition Game---");
                case "2":
                    return RunSubstractionGame("---Substraction Game---");
                case "3":
                    return RunMultiplicationGame("---Multiplication Game---");
                case "4":
                    return RunDivisionGame("---Division Game---");
                default:
                    return 0;
            }
        }

        private int RunAdditionGame(string message)
        {
            for (int questionNumber = 0; questionNumber < QUESTIONS_NUMBER; questionNumber++)
            {
                MessageHelper.NewGameMessage(message);
                (int firstOperator, int secondOperator) = GetRandomOperators();
                int correctAnswer = firstOperator + secondOperator;
                string question = MessageHelper.GetQuestion(firstOperator, secondOperator, "+");
                int userAnswer = GetUserAnswer(question);
                ManageResult(correctAnswer, userAnswer);
            }

            MessageHelper.PrintFinalScore(score);
            return score;
        }

        private int RunSubstractionGame(string message)
        {
            for (int questionNumber = 0; questionNumber < QUESTIONS_NUMBER; questionNumber++)
            {
                MessageHelper.NewGameMessage(message);
                (int firstOperator, int secondOperator) = GetRandomOperators();
                int correctAnswer = firstOperator - secondOperator;
                string question = MessageHelper.GetQuestion(firstOperator, secondOperator, "-");
                int userAnswer = GetUserAnswer(question);
                ManageResult(correctAnswer, userAnswer);
            }

            MessageHelper.PrintFinalScore(score);
            return score;
        }

        private int RunMultiplicationGame(string message)
        {
            for (int questionNumber = 0; questionNumber < QUESTIONS_NUMBER; questionNumber++)
            {
                MessageHelper.NewGameMessage(message);
                (int firstOperator, int secondOperator) = GetRandomOperators();
                int correctAnswer = firstOperator * secondOperator;
                string question = MessageHelper.GetQuestion(firstOperator, secondOperator, "*");
                int userAnswer = GetUserAnswer(question);
                ManageResult(correctAnswer, userAnswer);
            }

            MessageHelper.PrintFinalScore(score);
            return score;
        }

        private int RunDivisionGame(string message)
        {
            for (int questionNumber = 0; questionNumber < QUESTIONS_NUMBER; questionNumber++)
            {
                MessageHelper.NewGameMessage(message);
                (int firstOperator, int secondOperator) = GetDivisionOperators();
                int correctAnswer = firstOperator / secondOperator;
                string question = MessageHelper.GetQuestion(firstOperator, secondOperator, "/");
                int userAnswer = GetUserAnswer(question);
                ManageResult(correctAnswer, userAnswer);
            }

            MessageHelper.PrintFinalScore(score);
            return score;
        }

        private int GetUserAnswer(string question)
        {
            Console.WriteLine(question);
            string userInput = Console.ReadLine();

            while (!Int32.TryParse(userInput, out _))
            { 
                MessageHelper.ShowErrorMessage("Please enter a number as answer.");
                Console.WriteLine(question);
                userInput = Console.ReadLine();
            }

            return int.Parse(userInput);
        }

        private (int firstOperator, int secondOperator) GetDivisionOperators()
        {
            int dividend;
            int divisor;
            Random random = new Random();
            do
            {
                dividend = random.Next(0, 100);
                divisor = random.Next(1, 100);

            } while (dividend % divisor != 0);

            return (dividend, divisor);
        }

        private (int firstOperator, int secondOperator) GetRandomOperators()
        {
            Random random = new Random();

            int firstOperator = random.Next(1, 9);
            int secondOperator = random.Next(1, 9);

            return (firstOperator, secondOperator);
        }

        private void ManageResult(int result, int answer)
        {

            bool isAnswerCorrect = answer == result;

            if (isAnswerCorrect)
            {
                MessageHelper.ShowCorrectAnswerMessage();
                IncrementScore();
            }
            else
            {
                MessageHelper.ShowIncorrectAnswerMessage();
            }
        }

        private void IncrementScore()
        {
            this.score++;
        }
    }
}
