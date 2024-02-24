using MathGameLibrary;
using MathGameLibrary.Models;

namespace MathGame;

public static class GameEngine
{
    private static List<Game> games = new List<Game>();

    public static void GameInit(GameType gameType, string operatorSymbol)
    {
        int score = 0;
        var random = new Random();
        GameType typeOfGame;

        var difficulty = UserInputHandler.GetGameDifficulty();
        
        int numOfQuestions = UserInputHandler.GetNumberOfQuestions();

        Console.WriteLine($"Generating Questions for {gameType} game - {difficulty} Level\n");

        var startTime = DateTime.Now;

        for (int i = 0; i < numOfQuestions; i++)
        {
            if (gameType == GameType.Random)
            {
                typeOfGame = (GameType)random.Next(0, 4);
                operatorSymbol = GameLogic.GetOperatorSymbol(typeOfGame);
            }
            else
            {
                typeOfGame = gameType;
            }

            var operands = GameLogic.GenerateOperands(typeOfGame, (int) difficulty);

            if (operands.Length != 2)
            {
                throw new ArgumentException("Invalid number of operands", "operands");
            }

            MessageHandler.DisplayOperation(operands, operatorSymbol);
            int answer = UserInputHandler.GetAnswer();

            int correctAnswer = GameLogic.GenerateCorrectAnswer(operands, typeOfGame);

            if (answer == correctAnswer)
            {
                Console.WriteLine("Correct Answer!\n");
                score++;
            }
            else
            {
                Console.WriteLine("Wrong Answer\n");                
            }
        }

        var endTime = DateTime.Now;
        var timeSpan = endTime - startTime;

        StoreGame(gameType, score, difficulty, timeSpan, numOfQuestions);

        MessageHandler.PrintScore(score);

        MessageHandler.AskToContinueToMenu();
        
    }
    
    public static void PrintGamesHistory()
    {
        Console.Clear();
        Console.WriteLine("Game History\n");

        if (games.Any() == true)
        {
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Difficulty} Level - {game.GameType}: {game.Score} out of {game.NumberOfQuestions} correct in {game.TimeSpan.Seconds} seconds");
            }
        }
        else
        {
            Console.WriteLine("You haven't played any game yet.");
        }

        MessageHandler.AskToContinueToMenu();
    }

    private static void StoreGame(GameType gameType, int score, Difficulty difficulty, TimeSpan timeSpan, int numberOfQuestions)
    {
        games.Add(new Game
        {
            Date = DateTime.Now,
            GameType = gameType,
            Score = score,
            Difficulty = difficulty,
            TimeSpan = timeSpan,
            NumberOfQuestions = numberOfQuestions
        });
    }

    
}
