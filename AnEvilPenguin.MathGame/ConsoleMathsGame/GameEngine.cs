namespace ConsoleMathsGame
{
    using Models;

    internal class GameEngine
    {
        internal void AdditionGame(string message, GameDifficulty difficulty)
        {
            int score = 0;
            int attempts = 5;

            int firstNumber;
            int secondNumber;

            for (int i = 0; i < attempts; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                firstNumber = Helpers.GetRandomInt(difficulty);
                secondNumber = Helpers.GetRandomInt(difficulty);

                Console.WriteLine($"{firstNumber} + {secondNumber}");

                var result = firstNumber + secondNumber;

                var answer = Helpers.GetUserAnswer();

                if (Helpers.CheckAnswer(answer, result))
                {
                    score++;
                }

                Helpers.HoldForEnter();
            }

            Console.WriteLine();
            Console.WriteLine($"Your final score was: {score}/{attempts}");

            Helpers.AddToHistory(score, GameType.Addition, difficulty);

            Helpers.PauseToMenu();
        }

        internal void SubtractionGame(string message, GameDifficulty difficulty)
        {
            int score = 0;
            int attempts = 5;

            int firstNumber;
            int secondNumber;

            for (int i = 0; i < attempts; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                firstNumber = Helpers.GetRandomInt(difficulty);
                secondNumber = Helpers.GetRandomInt(difficulty);

                Console.WriteLine($"{firstNumber} - {secondNumber}");

                var result = firstNumber - secondNumber;

                var answer = Helpers.GetUserAnswer();

                if (Helpers.CheckAnswer(answer, result))
                {
                    score++;
                }

                Helpers.HoldForEnter();
            }

            Console.WriteLine();
            Console.WriteLine($"Your final score was: {score}/{attempts}");

            Helpers.AddToHistory(score, GameType.Subtraction, difficulty);

            Helpers.PauseToMenu();
        }

        internal void MultiplicationGame(string message, GameDifficulty difficulty)
        {
            int score = 0;
            int attempts = 5;

            int firstNumber;
            int secondNumber;

            for (int i = 0; i < attempts; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                firstNumber = Helpers.GetRandomInt(difficulty);
                secondNumber = Helpers.GetRandomInt(difficulty);

                Console.WriteLine($"{firstNumber} * {secondNumber}");

                var result = firstNumber * secondNumber;

                var answer = Helpers.GetUserAnswer();

                if (Helpers.CheckAnswer(answer, result))
                {
                    score++;
                }

                Helpers.HoldForEnter();
            }

            Console.WriteLine();
            Console.WriteLine($"Your final score was: {score}/{attempts}");

            Helpers.AddToHistory(score, GameType.Multiplication, difficulty);

            Helpers.PauseToMenu();
        }

        internal void DivisionGame(string message, GameDifficulty difficulty)
        {
            int score = 0;
            int attempts = 5;

            int firstNumber;
            int secondNumber;

            for (int i = 0; i < attempts; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                var divisionNumbers = Helpers.GetDivisionNumbers(difficulty);
                firstNumber = divisionNumbers[0];
                secondNumber = divisionNumbers[1];

                Console.WriteLine($"{firstNumber} / {secondNumber}");

                var result = firstNumber / secondNumber;

                var answer = Helpers.GetUserAnswer();

                if (Helpers.CheckAnswer(answer, result))
                {
                    score++;
                }

                Helpers.HoldForEnter();
            }

            Console.WriteLine();
            Console.WriteLine($"Your final score was: {score}/{attempts}");

            Helpers.AddToHistory(score, GameType.Division, difficulty);

            Helpers.PauseToMenu();
        }
    }
}
