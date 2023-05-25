using firstAppCalculator.Models;

internal class Helpers
{
    internal static List<Game> games = new List<Game>
    {

    };

    internal static int[] GetDivisionNumbers(string difficulty)
    {
        var random = new Random();
        int firstNumber = 0;
        int secondNumber = 0;

        switch (difficulty){
            case "1":
                firstNumber = random.Next(1, 10);
                secondNumber = random.Next(1, 10);
                break;
            case "2":
                firstNumber = random.Next(1, 99);
                secondNumber = random.Next(1, 99);
                break;
            case "3":
                firstNumber = random.Next(1, 1000);
                secondNumber = random.Next(1, 1000);
                break;
        }

        var result = new int[2];

        while (firstNumber % secondNumber != 0)
        {
            switch (difficulty)
            {
                case "1":
                    firstNumber = random.Next(1, 10);
                    secondNumber = random.Next(1, 10);
                    break;
                case "2":
                    firstNumber = random.Next(1, 99);
                    secondNumber = random.Next(1, 99);
                    break;
                case "3":
                    firstNumber = random.Next(1, 1000);
                    secondNumber = random.Next(1, 1000);
                    break;
            }
        }

        result[0] = firstNumber;
        result[1] = secondNumber;
        return result;
    }

    internal static void AddToHistory(int gameScore, GameType gameType, int amountOfQuestion, string difficultyOfGame, TimeSpan timeSpanned)
    {
        games.Add(new Game
        {
            Date = DateTime.Now,
            Score = gameScore,
            Type = gameType,
            Amount = amountOfQuestion,
            Difficulty = difficultyOfGame,
            TimeSpanned = timeSpanned
        });
    }

    internal static void PrintGames()
    {
        Console.Clear();
        Console.WriteLine("Games History");
        Console.WriteLine("---------------------------");
        foreach (var game in games)
        {
            Console.WriteLine($"{game.Date} - {game.Type}: {game.Score} out of {game.Amount} questions with the difficulty of {game.Difficulty} - Game Time {game.TimeSpanned}");
        }
        Console.WriteLine("---------------------------\n");
        Console.WriteLine("Press any key to return to Main Menu");
        Console.ReadLine();
    }

    internal static int AmountOfQuestion()
    {
        int result = 0;
        Console.WriteLine("How many questions do you want to do ? (answer by a number)");
        var resultBeforeInt = Console.ReadLine();
        result = int.Parse(resultBeforeInt);

        return result;
    }
}
