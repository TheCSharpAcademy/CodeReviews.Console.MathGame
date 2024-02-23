using MathGameLibrary;
using MathGameLibrary.Models;

namespace MathGame;

public static class GameEngine
{
    private static List<Game> games = new List<Game>();

    public static void GameInit(GameType gameType, string operatorSymbol)
    {
        var difficulty = UserInputHandler.GetGameDifficulty();

        Console.WriteLine($"Generating Questions for {gameType} game - {difficulty} Level\n");

        int score = 0;
        int numOfQuestions = 5;

        for (int i = 0; i < numOfQuestions; i++)
        {
            var operands = GameLogic.GenerateOperands(gameType, (int) difficulty);

            if (operands.Length != 2)
            {
                throw new ArgumentException("Invalid number of operands", "operands");
            }

            MessageHandler.DisplayOperation(operands, operatorSymbol);
            int answer = UserInputHandler.GetAnswer();
            int correctAnswer = GameLogic.GenerateCorrectAnswer(operands, gameType);

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

        StoreGame(gameType, score, difficulty);

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
                Console.WriteLine($"{game.Date} - {game.Difficulty} Level - {game.GameType}: {game.Score}pts");
            }
        }
        else
        {
            Console.WriteLine("You haven't played any game yet.");
        }

        MessageHandler.AskToContinueToMenu();
    }

    private static void StoreGame(GameType gameType, int score, Difficulty difficulty)
    {
        games.Add(new Game
        {
            Date = DateTime.Now,
            GameType = gameType,
            Score = score,
            Difficulty = difficulty
        });
    }

    
}
