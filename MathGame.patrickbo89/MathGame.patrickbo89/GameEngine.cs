namespace MathGame.patrickbo89;

internal class GameEngine
{
    internal void StartAdditionGame(int numberOfQuestions, Difficulty difficulty)
    {
        int score = 0;

        int[] numbers;

        char operatorSymbol = '+';

        var startTime = DateTime.UtcNow;
        DateTime endTime;

        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine($"Addition Game ({difficulty}) - Round {i + 1} of {numberOfQuestions}");

            numbers = Helpers.GetAdditionNumbers(difficulty);

            Console.Write($"{numbers[0]} {operatorSymbol} {numbers[1]} = ");

            var result = Console.ReadLine();
            result = Helpers.ValidateResultInput(result, numbers[0], numbers[1], operatorSymbol);

            int correctResult = Helpers.CalculateResult(GameType.Addition, numbers[0], numbers[1]);

            if (int.Parse(result) == correctResult)
            {
                Console.WriteLine("Correct! Press any key for the next question.");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Incorrect! Press any key for the next question.");
                Console.ReadLine();
            }

            if (i == numberOfQuestions - 1)
            {
                endTime = DateTime.UtcNow;
                var elapsedSeconds = ((endTime - startTime).TotalSeconds).ToString(string.Format(".00"));
                Helpers.AddToHistory(GameType.Addition, difficulty, score, numberOfQuestions, elapsedSeconds);

                Console.WriteLine($"The game is over. You had {score} of {numberOfQuestions} correct answers. You took {elapsedSeconds} seconds. Press any key to return to the main menu.");
                Console.ReadLine();
            }
        }
    }

    internal void StartSubtractionGame(int numberOfQuestions, Difficulty difficulty)
    {
        int score = 0;

        int[] numbers;

        char operatorSymbol = '-';

        var startTime = DateTime.UtcNow;
        DateTime endTime;

        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine($"Subtraction Game ({difficulty}) - Round {i + 1} of {numberOfQuestions}");

            numbers = Helpers.GetSubtractionNumbers(difficulty);

            Console.Write($"{numbers[0]} {operatorSymbol} {numbers[1]} = ");

            var result = Console.ReadLine();
            result = Helpers.ValidateResultInput(result, numbers[0], numbers[1], operatorSymbol);

            int correctResult = Helpers.CalculateResult(GameType.Subtraction, numbers[0], numbers[1]);

            if (int.Parse(result) == correctResult)
            {
                Console.WriteLine("Correct! Press any key for the next question.");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Incorrect! Press any key for the next question.");
                Console.ReadLine();
            }

            if (i == numberOfQuestions - 1)
            {
                endTime = DateTime.UtcNow;
                var elapsedSeconds = ((endTime - startTime).TotalSeconds).ToString(string.Format(".00"));
                Helpers.AddToHistory(GameType.Subtraction, difficulty, score, numberOfQuestions, elapsedSeconds);

                Console.WriteLine($"The game is over. You had {score} of {numberOfQuestions} correct answers. You took {elapsedSeconds} seconds. Press any key to return to the main menu.");
                Console.ReadLine();
            }
        }
    }

    internal void StartMultiplicationGame(int numberOfQuestions, Difficulty difficulty)
    {
        int score = 0;

        int[] numbers;

        char operatorSymbol = '*';

        var startTime = DateTime.UtcNow;
        DateTime endTime;

        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine($"Multiplication Game ({difficulty}) - Round {i + 1} of {numberOfQuestions}");

            numbers = Helpers.GetMultiplicationNumbers(difficulty);

            Console.Write($"{numbers[0]} {operatorSymbol} {numbers[1]} = ");

            var result = Console.ReadLine();
            result = Helpers.ValidateResultInput(result, numbers[0], numbers[1], operatorSymbol);

            int correctResult = Helpers.CalculateResult(GameType.Multiplication, numbers[0], numbers[1]);

            if (int.Parse(result) == correctResult)
            {
                Console.WriteLine("Correct! Press any key for the next question.");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Incorrect! Press any key for the next question.");
                Console.ReadLine();
            }

            if (i == numberOfQuestions - 1)
            {
                endTime = DateTime.UtcNow;
                var elapsedSeconds = ((endTime - startTime).TotalSeconds).ToString(string.Format(".00"));
                Helpers.AddToHistory(GameType.Multiplication, difficulty, score, numberOfQuestions, elapsedSeconds);

                Console.WriteLine($"The game is over. You had {score} of {numberOfQuestions} correct answers. You took {elapsedSeconds} seconds. Press any key to return to the main menu.");
                Console.ReadLine();
            }
        }
    }

    internal void StartDivisionGame(int numberOfQuestions, Difficulty difficulty)
    {
        int score = 0;

        int[] numbers;

        char operatorSymbol = '/';

        var startTime = DateTime.UtcNow;
        DateTime endTime;

        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine($"Division Game ({difficulty}) - Round {i + 1} of {numberOfQuestions}");

            numbers = Helpers.GetDivisionNumbers(difficulty);

            Console.Write($"{numbers[0]} {operatorSymbol} {numbers[1]} = ");

            var result = Console.ReadLine();
            result = Helpers.ValidateResultInput(result, numbers[0], numbers[1], operatorSymbol);

            int correctResult = Helpers.CalculateResult(GameType.Division, numbers[0], numbers[1]);

            if (int.Parse(result) == correctResult)
            {
                Console.WriteLine("Correct! Press any key for the next question.");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Incorrect! Press any key for the next question.");
                Console.ReadLine();
            }

            if (i == numberOfQuestions - 1)
            {
                endTime = DateTime.UtcNow;
                var elapsedSeconds = ((endTime - startTime).TotalSeconds).ToString(string.Format(".00"));
                Helpers.AddToHistory(GameType.Division, difficulty, score, numberOfQuestions, elapsedSeconds);

                Console.WriteLine($"The game is over. You had {score} of {numberOfQuestions} correct answers. You took {elapsedSeconds} seconds. Press any key to return to the main menu.");
                Console.ReadLine();
            }
        }
    }

    internal void StartRandomGame(int numberOfQuestions, Difficulty difficulty)
    {
        Random random = new Random();

        int score = 0;

        int[] numbers = new int[2];

        char operatorSymbol = ' ';

        var startTime = DateTime.UtcNow;
        DateTime endTime;

        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine($"Random Game ({difficulty}) - Round {i + 1} of {numberOfQuestions}");

            var operationSelector = random.Next(0, 4);
            GameType selectedOperation = GameType.None;

            switch (operationSelector)
            {
                case 0:
                    numbers = Helpers.GetAdditionNumbers(difficulty);
                    operatorSymbol = '+';
                    selectedOperation = GameType.Addition;
                    break;
                case 1:
                    numbers = Helpers.GetSubtractionNumbers(difficulty);
                    operatorSymbol = '-';
                    selectedOperation = GameType.Subtraction;
                    break;
                case 2:
                    numbers = Helpers.GetMultiplicationNumbers(difficulty);
                    operatorSymbol = '*';
                    selectedOperation = GameType.Multiplication;
                    break;
                case 3:
                    numbers = Helpers.GetDivisionNumbers(difficulty);
                    operatorSymbol = '/';
                    selectedOperation = GameType.Division;
                    break;
            }

            Console.Write($"{numbers[0]} {operatorSymbol} {numbers[1]} = ");

            var resultInput = Console.ReadLine();
            resultInput = Helpers.ValidateResultInput(resultInput, numbers[0], numbers[1], operatorSymbol);

            int correctResult = Helpers.CalculateResult(selectedOperation, numbers[0], numbers[1]);

            if (int.Parse(resultInput) == correctResult)
            {
                Console.WriteLine("Correct! Press any key for the next question.");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Incorrect! Press any key for the next question.");
                Console.ReadLine();
            }

            if (i == numberOfQuestions - 1)
            {
                endTime = DateTime.UtcNow;
                var elapsedSeconds = ((endTime - startTime).TotalSeconds).ToString(string.Format(".00"));
                Helpers.AddToHistory(GameType.Random, difficulty, score, numberOfQuestions, elapsedSeconds);

                Console.WriteLine($"The game is over. You had {score} of {numberOfQuestions} correct answers. You took {elapsedSeconds} seconds. Press any key to return to the main menu.");
                Console.ReadLine();
            }
        }
    }
}
