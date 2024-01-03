namespace MathGame.saullbrandao;

internal class GameEngine
{
    internal static void StartGame(GameType type)
    {
        Console.Clear();
        Console.WriteLine($"{type} game");

        var random = new Random();
        var score = 0;

        for (int i = 0; i < 5; i++)
        {
            int firstNumber, secondNumber;

            if (type == GameType.Division)
            {
                var numbers = Helpers.GetValidDivisionNumbers();
                firstNumber = numbers[0];
                secondNumber = numbers[1];
            }
            else
            {
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);
            }

            DisplayEquation(type, firstNumber, secondNumber);

            var answer = Console.ReadLine();
            answer = Helpers.ValidateAnswer(answer);

            if (int.Parse(answer) == GetCorrectAnswer(type, firstNumber, secondNumber))
            {
                Console.WriteLine("Your answer was correct!");
                score++;
            }
            else
            {
                Console.WriteLine("Your answer was incorrect.");
            }

            if (i == 4)
            {
                Console.WriteLine($"Game Over. Your final score is {score}");
            }
        }

        Helpers.AddToGames(type, score);
    }

    private static void DisplayEquation(GameType type, int firstNumber, int secondNumber)
    {
        string operatorSymbol = GetOperatorSymbol(type);
        Console.WriteLine($"{firstNumber} {operatorSymbol} {secondNumber}");
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
