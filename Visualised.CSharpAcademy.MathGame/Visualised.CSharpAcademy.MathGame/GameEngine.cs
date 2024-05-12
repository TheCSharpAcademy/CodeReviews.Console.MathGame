using Visualised.CSharpAcademy.MathGame.Models;
using System.Linq.Dynamic.Core;

namespace Visualised.CSharpAcademy.MathGame;

internal class GameEngine
{
    List<Game> games = new();
    GameLogic gameLogic = new();

    internal void AdditionGame()
    {
        GameDifficultyLevels gameDifficulty = Helpers.GetDifficultyLevel();
        Console.Clear();
        int numberOfQuestions = Helpers.GetNumberOfQuestions();
        Console.Clear();

        int score = 0;
        var gameStartTime = DateTime.Now;

        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine("Addition Game");
            bool hasUserWonTheGame = gameLogic.AdditionGameLogic(gameDifficulty);
            if (hasUserWonTheGame)
                score++;
        }

        var elapsedTime = DateTime.Now - gameStartTime;
        Helpers.PrintCurrentGameResult(score, elapsedTime);

        AddToHistory(score, GameType.Addition, gameDifficulty, elapsedTime);
    }
    internal void SubtractionGame()
    {
        GameDifficultyLevels gameDifficulty = Helpers.GetDifficultyLevel();
        Console.Clear();
        int numberOfQuestions = Helpers.GetNumberOfQuestions();
        Console.Clear();

        int score = 0;
        var gameStartTime = DateTime.Now;

        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine("Subtraction Game");
            bool hasUserWonTheGame = gameLogic.SubtractionGameLogic(gameDifficulty);
            if (hasUserWonTheGame)
                score++;
        }

        var elapsedTime = DateTime.Now - gameStartTime;
        Helpers.PrintCurrentGameResult(score, elapsedTime);

        AddToHistory(score, GameType.Subtraction, gameDifficulty, elapsedTime);
    }
    internal void MultiplicationGame()
    {
        GameDifficultyLevels gameDifficulty = Helpers.GetDifficultyLevel();
        Console.Clear();
        int numberOfQuestions = Helpers.GetNumberOfQuestions();
        Console.Clear();

        int score = 0;
        var gameStartTime = DateTime.Now;

        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine("Multiplication Game");
            bool hasUserWonTheGame = gameLogic.MultiplicationGameLogic(gameDifficulty);
            if (hasUserWonTheGame)
                score++;

        }

        var elapsedTime = DateTime.Now - gameStartTime;
        Helpers.PrintCurrentGameResult(score, elapsedTime);

        AddToHistory(score, GameType.Multiplication, gameDifficulty, elapsedTime);
    }
    internal void DivisionGame()
    {
        GameDifficultyLevels gameDifficulty = Helpers.GetDifficultyLevel();
        Console.Clear();
        int numberOfQuestions = Helpers.GetNumberOfQuestions();
        Console.Clear();

        int score = 0;
        var gameStartTime = DateTime.Now;

        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine("Division Game");
            bool hasUserWonTheGame = gameLogic.DivisionGameLogic(gameDifficulty);
            if (hasUserWonTheGame)
                score++;
        }

        var elapsedTime = DateTime.Now - gameStartTime;
        Helpers.PrintCurrentGameResult(score, elapsedTime);

        AddToHistory(score, GameType.Division, gameDifficulty, elapsedTime);
    }

    internal void RandomGame()
    {
        GameDifficultyLevels gameDifficulty = Helpers.GetDifficultyLevel();
        Console.Clear();
        int numberOfQuestions = Helpers.GetNumberOfQuestions();
        Console.Clear();

        int score = 0;
        var gameStartTime = DateTime.Now;

        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.Clear();

            GameType drawnGameType = Helpers.GetRandomGameType();
            bool hasUserWonTheGame = false;

            Console.WriteLine("Random Game");
            switch (drawnGameType)
            {
                case GameType.Addition:
                    hasUserWonTheGame = gameLogic.AdditionGameLogic(gameDifficulty);
                    break;
                case GameType.Subtraction:
                    hasUserWonTheGame = gameLogic.SubtractionGameLogic(gameDifficulty);
                    break;
                case GameType.Multiplication:
                    hasUserWonTheGame = gameLogic.MultiplicationGameLogic(gameDifficulty);
                    break;
                case GameType.Division:
                    hasUserWonTheGame = gameLogic.DivisionGameLogic(gameDifficulty);
                    break;
            }

            if (hasUserWonTheGame)
                score++;
        }

        var elapsedTime = DateTime.Now - gameStartTime;
        Helpers.PrintCurrentGameResult(score, elapsedTime);

        AddToHistory(score, GameType.Random, gameDifficulty, elapsedTime);
    }
    internal void PrintGameHistory()
    {
        Console.Clear();
        if (games.Count == 0)
        {
            Console.WriteLine("You haven't played any games yet!");
        }
        else
        {
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - Elapsed Time: {game.ElapsedTime.ToString("m\\:ss")} - {game.Type} - {game.Difficulty}: {game.Score}pts.");
            }
        }
        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
    }

    internal void SearchGameHistory()
    {
        Console.Clear();
        Helpers.PrintMenuFromEnumType("Select Game Type", new GameType());

        GameType selectedGameType;
        IOrderedEnumerable<Game> filteredGameList;

        if (Enum.TryParse<GameType>(Helpers.UppercaseFirst(Console.ReadLine()), out selectedGameType))
        {
            Console.Clear();
            Helpers.PrintMenuFromObjProperties("Order by (case sensitive!)", new Game());
            string orderBy = Console.ReadLine();
            bool isOrderByValid = typeof(Game).GetProperty(orderBy) != null;

            if (!isOrderByValid)
            {
                Helpers.FailInput();
                return;
            }

            Console.Clear();
            Console.Write("Please select Ascending or Descending order: ");
            string orderDirection = Helpers.UppercaseFirst(Console.ReadLine());
            bool isOrderDirectionValid = Helpers.IsOrderDirectionValid(orderDirection);

            if (!isOrderDirectionValid)
            {
                Helpers.FailInput();
                return;
            }

            switch (orderDirection)
            {
                case "Descending":
                    filteredGameList = games
                        .Where(x => x.Type == selectedGameType)
                        .OrderByDescendingDynamic(x => "x." + orderBy);
                    break;
                default:
                    filteredGameList = games
                        .Where(x => x.Type == selectedGameType)
                        .OrderByDynamic(x => "x." + orderBy);
                    break;
            }
        }
        else
        {
            Helpers.FailInput();
            return;
        }

        Console.Clear();
        foreach (var game in filteredGameList)
        {
            Console.WriteLine($"{game.Date} - Elapsed Time: {game.ElapsedTime.ToString("m\\:ss")} - {game.Type} - {game.Difficulty}: {game.Score}pts");
        }

        Console.WriteLine("\nPress any key to continue.");
        Console.ReadLine();

    }

    internal void AddToHistory(int gameScore, GameType gameType, GameDifficultyLevels difficulty, TimeSpan elapsedTime)
    {
        games.Add(new Game
        {
            Date = DateTime.Now,
            Type = gameType,
            Score = gameScore,
            Difficulty = difficulty,
            ElapsedTime = elapsedTime
        });
    }
}
