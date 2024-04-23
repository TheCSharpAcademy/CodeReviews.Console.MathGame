using jcast24.MathGame.Models;
namespace jcast24.MathGame;
internal class Engine
{
    private List<Game> games = [];

    private void AddToHistory(int gameScore, GameType gameType)
    {
        games.Add(new Game
        {
            Date = DateTime.Now,
            Score = gameScore,
            Type = gameType
        });
    }

    internal void RandomGame(int numOfGames)
    {
        Random num = new Random();
        var value = num.Next(0, 4);

        switch (value)
        {
            case 0:
                Addition(numOfGames);
                break;
            case 1:
                Subtraction(numOfGames);
                break;
            case 2:
                Division(numOfGames);
                break;
            case 3:
                Multiplication(numOfGames);
                break;
            default:
                Console.WriteLine("Please enter a correct response: ");
                break;
        }

    }

    internal void GetGames()
    {
        foreach (var game in games)
        {
            Console.WriteLine($"{DateTime.Now} - {game.Type}: {game.Score} pts");
        }
        Console.WriteLine("Press any key to continue!");
        Console.ReadLine();
    }

    internal void Addition(int numOfGames)
    {
        int score = 0;
        for (int i = 0; i < numOfGames; i++)
        {
            var random = new Random();
            int firstNum = random.Next(1, 9);
            int secondNum = random.Next(1, 9);

            Console.WriteLine($"What is the result of {firstNum} + {secondNum}?");
            string? result = Console.ReadLine();
            result = Helper.ValidateInput(result);


            if (int.Parse(result) == firstNum + secondNum)
            {
                Console.WriteLine("Correct!");
                score++;
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }

            if (i == numOfGames - 1)
            {
                Console.WriteLine($"Final Score: {score}");
                Console.ReadLine();
            }
        }
        AddToHistory(score, GameType.Addition);
    }

    internal void Subtraction(int numOfGames)
    {
        int score = 0;
        for (int i = 0; i < numOfGames; i++)
        {
            var random = new Random();
            int firstNum = random.Next(1, 9);
            int secondNum = random.Next(1, 9);
            Console.WriteLine($"What is the result of {firstNum} - {secondNum}?");
            string? result = Console.ReadLine();
            result = Helper.ValidateInput(result);

            if (int.Parse(result) == firstNum - secondNum)
            {
                Console.WriteLine("Correct!");
                score++;
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }

            if (i == numOfGames - 1)
            {
                Console.WriteLine($"Final score: {score}");
                Console.ReadLine();
            }
        }
        AddToHistory(score, GameType.Subtraction);
    }

    int[] GetDivisionNumbers()
    {
        var random = new Random();
        int firstNum = random.Next(1, 99);
        int secondNum = random.Next(1, 99);

        // if the remainder of the firstNum and secondNum isn't zero
        // get 2 other random numbers
        while (firstNum % secondNum != 0)
        {
            firstNum = random.Next(1, 99);
            secondNum = random.Next(1, 99);
        }

        var result = new int[2];

        result[0] = firstNum;
        result[1] = secondNum;

        return result;
    }

    internal void Division(int numOfGames)
    {
        int score = 0;
        for (int i = 0; i < numOfGames; i++)
        {
            var divArray = GetDivisionNumbers();
            var answer = divArray[0] / divArray[1];

            Console.WriteLine($"What is the result of {divArray[0]} / {divArray[1]}?");
            string? result = Console.ReadLine();
            result = Helper.ValidateInput(result);

            if (int.Parse(result) == answer)
            {
                Console.WriteLine("Correct!");
                score++;
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }

            if (i == numOfGames - 1)
            {
                Console.WriteLine($"Final Score: {score}");
                Console.ReadLine();
            }

            AddToHistory(score, GameType.Division);
        }
    }

    internal void Multiplication(int numOfGames)
    {
        int score = 0;
        for (int i = 0; i < numOfGames; i++)
        {
            var random = new Random();
            int firstNum = random.Next(1, 9);
            int secondNum = random.Next(1, 9);

            int answer = firstNum * secondNum;

            Console.WriteLine($"What is the result of {firstNum} * {secondNum}?");
            string result = Console.ReadLine();
            result = Helper.ValidateInput(result);

            if (int.Parse(result) == answer)
            {
                Console.WriteLine("Correct!");
                score++;
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }

            if (i == numOfGames - 1)
            {
                Console.WriteLine($"Final score: {score}");
            }
        }
        AddToHistory(score, GameType.Multiplication);
    }
}