namespace MathGame.saullbrandao;

internal class GameEngine
{
    internal static void StartGame(GameType type)
    {
        Console.Clear();
        Console.WriteLine($"{type} game");

        GameDifficulty difficulty = Helpers.SelectDifficulty();
        Console.WriteLine();
        Console.WriteLine($"Difficulty = {difficulty}");

        Console.WriteLine("How many questions you want?");
        var totalQuestions = Helpers.GetValidAnswer();

        var random = new Random();
        var startTime = DateTime.Now;
        var score = 0;

        for (int i = 0; i < totalQuestions; i++)
        {
            int firstNumber, secondNumber;

            if (type == GameType.Division)
            {
                var numbers = Helpers.GetValidDivisionNumbers(difficulty);
                firstNumber = numbers[0];
                secondNumber = numbers[1];
            }
            else
            {
                firstNumber = random.Next(1, (int)difficulty);
                secondNumber = random.Next(1, (int)difficulty);
            }

            DisplayEquation(type, i + 1, firstNumber, secondNumber);

            var answer = Helpers.GetValidAnswer();

            if (answer == GetCorrectAnswer(type, firstNumber, secondNumber))
            {
                Console.WriteLine("Your answer was correct!");
                score++;
            }
            else
            {
                Console.WriteLine("Your answer was incorrect.");
            }

            if (i == totalQuestions - 1)
            {
                Console.WriteLine($"Game Over. Your final score is {score}");
            }
        }
        var endTime = DateTime.Now;
        var timeSpan = endTime - startTime;

        Helpers.AddToGames(type, score, difficulty, timeSpan, totalQuestions);
    }

    private static void DisplayEquation(GameType type, int questionNumber, int firstNumber, int secondNumber)
    {
        string operatorSymbol = GetOperatorSymbol(type);
        Console.WriteLine($"Question {questionNumber}: {firstNumber} {operatorSymbol} {secondNumber}");
    }

    private static int GetCorrectAnswer(GameType type, int firstNumber, int secondNumber)
    {
        return type switch
        {
            GameType.Addition => firstNumber + secondNumber,
            GameType.Subtraction => firstNumber - secondNumber,
            GameType.Multiplication => firstNumber * secondNumber,
            GameType.Division => firstNumber / secondNumber,
            _ => throw new ArgumentOutOfRangeException(type.ToString(), type, null),
        };
    }

    private static string GetOperatorSymbol(GameType type)
    {
        return type switch
        {
            GameType.Addition => "+",
            GameType.Subtraction => "-",
            GameType.Multiplication => "x",
            GameType.Division => "/",
            _ => throw new ArgumentOutOfRangeException(type.ToString(), type, null),
        };
    }
}
