namespace MathGame.patrickbo89;

internal class GameEngine
{
    internal Game SetupGame(GameType gameType, int numberOfQuestions, Difficulty difficulty)
    {
        return new Game()
        {
            StartTime = DateTime.UtcNow,
            Type = gameType,
            Score = 0,
            NumberOfQuestions = numberOfQuestions,
            Difficulty = difficulty
        };
    }

    internal void StartGame(Game game)
    {
        char operatorSymbol = ' ';

        if (game.Type != GameType.Random)
        {
            operatorSymbol = GetOperatorSymbol(game.Type);
        }

        RunGameLoop(game, operatorSymbol);

        var endTime = DateTime.UtcNow;
        game.ElapsedSeconds = ((endTime - game.StartTime).TotalSeconds).ToString(string.Format(".00"));

        DisplayGameResult(game);

        Helpers.AddToHistory(game);
    }

    internal void RunGameLoop(Game game, char operatorSymbol)
    {
        var random = new Random();

        int[] numbers;

        for (int i = 0; i < game.NumberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine($"{game.Type} Game ({game.Difficulty}) - Question {i + 1} of {game.NumberOfQuestions}");

            if (game.Type == GameType.Random)
            {
                operatorSymbol = GetRandomOperatorSymbol(random);
            }

            numbers = GenerateNumbers(operatorSymbol, game.Difficulty);

            Console.Write($"{numbers[0]} {operatorSymbol} {numbers[1]} = ");

            var resultInput = Console.ReadLine();
            resultInput = Helpers.ValidateResultInput(resultInput, numbers[0], numbers[1], operatorSymbol);

            int correctResult = Helpers.CalculateResult(operatorSymbol, numbers[0], numbers[1]);

            if (int.Parse(resultInput) == correctResult)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Correct! Press any key to continue.");
                Console.ForegroundColor = ConsoleColor.White;
                game.Score++;
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Incorrect! Press any key to continue.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
        }
    }

    private void DisplayGameResult(Game game)
    {
        Console.WriteLine($"\nThe game is over. You had {game.Score} of {game.NumberOfQuestions} correct answers. You took {game.ElapsedSeconds} seconds. Press any key to return to the main menu.");
        Console.ReadKey();
    }

    private char GetOperatorSymbol(GameType gameType)
    {
        return gameType switch
        {
            GameType.Addition       => '+',
            GameType.Subtraction    => '-',
            GameType.Multiplication => '*',
            GameType.Division       => '/',
            _                       => '+' // fallback value
        };
    }

    private char GetRandomOperatorSymbol(Random random)
    {
        int selector = random.Next(0, 4);

        return selector switch
        {
            0 => '+',
            1 => '-',
            2 => '*',
            3 => '/',
            _ => '+' // fallback value
        };
    }

    private int[] GenerateNumbers(char operatorSymbol, Difficulty difficulty)
    {
        int[] numbers = new int[2];

        switch (operatorSymbol)
        {
            case '+':
                numbers = Helpers.GetAdditionNumbers(difficulty);
                break;
            case '-':
                numbers = Helpers.GetSubtractionNumbers(difficulty);
                break;
            case '*':
                numbers = Helpers.GetMultiplicationNumbers(difficulty);
                break;
            case '/':
                numbers = Helpers.GetDivisionNumbers(difficulty);
                break;
        }

        return numbers;
    }
}