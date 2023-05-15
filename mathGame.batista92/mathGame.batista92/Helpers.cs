using mathGame.batista92.Models;

namespace mathGame.batista92;

internal class Helpers
{
    internal static List<Game> games = new();
    internal static void PrintGames()
    {
        Console.Clear();
        Console.WriteLine("Games History");
        Console.WriteLine("--------------------------------------------------------------");
        foreach (var game in games)
        {
            Console.WriteLine($"{game.Date} - {game.Type} - {game.Difficulty}: {game.Score}/{game.NumberOfQuestions} in {game.TimeTaken.TotalSeconds.ToString("0.00")}s.");
        }
        Console.WriteLine("--------------------------------------------------------------\n");
        Console.WriteLine("Press anu key to return to Main Menu");
        Console.ReadLine();
    }

    internal static void AddToHistory(int gameScore, GameType gameType, int numberOfQuestions, DifficultyLevel difficulty, TimeSpan timeTaken)
    {
        games.Add(new Game
        {
            Date = DateTime.Now,
            Score = gameScore,
            Type = gameType,
            NumberOfQuestions = numberOfQuestions,
            Difficulty = difficulty,
            TimeTaken = timeTaken
        });
    }

    internal static string? ValidadeResult(string result)
    {
        while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
        {
            Console.WriteLine("Your answer needs to be an interger. Try again.");
            result = Console.ReadLine();
        }
        return result;
    }

    internal static string GetName()
    {
        Console.Clear();
        Console.WriteLine("Please type your name");
        string name = Console.ReadLine();

        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Name can't be empty.");
            name = Console.ReadLine();
        }
        return name;
    }

    internal static int[] GetNumbers(DifficultyLevel difficulty, bool isDivisionGame = false)
    {
        Random random = new Random();
        int[] numbers = new int[2];

        if(isDivisionGame)
        {
            numbers[0] = random.Next(1, 99);
            numbers[1] = random.Next(1, 99);

            while (numbers[0] % numbers[1] != 0)
            {
                numbers[0] = random.Next(1, 99);
                numbers[1] = random.Next(1, 99);
            }
        } 
        else
        {
            numbers[0] = random.Next(1, 9);
            numbers[1] = random.Next(1, 9);
        }
        
        if(difficulty == DifficultyLevel.Easy)
        {
            numbers[0] *= 1;
            numbers[1] *= 1;
        }

        if (difficulty == DifficultyLevel.Medium)
        {
            numbers[0] *= 15;
            numbers[1] *= 15;
        }

        if (difficulty == DifficultyLevel.Hard)
        {
            numbers[0] *= 35;
            numbers[1] *= 35;
        }

        return numbers;
    }

    internal static void GameOver(int score, GameType gameType, int numberOfQuestions,DifficultyLevel difficulty, TimeSpan timeTaken)
    {
        Console.Clear();
        Console.WriteLine($"Game over! Your final score is: {score}/{numberOfQuestions} in {timeTaken.TotalSeconds.ToString("0.00")}s.");
        Console.WriteLine("Type any key for return to the menu");
        Console.ReadKey();
        AddToHistory(score, gameType, numberOfQuestions, difficulty, timeTaken);
    }

    internal static int NumberOfQuestions()
    {
        int numberOfQuestions;

        Console.Clear();
        Console.WriteLine("Type the number of questions you wish to answer:");

        while (!int.TryParse(Console.ReadLine(), out numberOfQuestions))
        {
            Console.WriteLine("Invalid number, try again");
        }
        return numberOfQuestions;
    }

    internal static DifficultyLevel GetDifficulty()
    {
        DifficultyLevel difficulty;

        Console.Clear();
        Console.WriteLine("Choose a difficulty level:");
        Console.WriteLine(@"
1 - Easy
2 - Medium
3 - Hard
");

        while (!Enum.TryParse(Console.ReadLine(), out difficulty))
        {
            Console.WriteLine("Invalid mode, try again");
        }
        return difficulty;
    }
}
