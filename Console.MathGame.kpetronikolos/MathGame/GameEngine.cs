using MathGameLibrary;
using MathGameLibrary.Models;

namespace MathGame;

public static class GameEngine
{
    private static List<Game> games = new List<Game>();

    public static void GameInit(GameType gameType, string operatorSymbol)
    {
        Console.WriteLine($"Generating Questions for {gameType} game");

        int score = 0;
        int numOfQuestions = 5;

        for (int i = 0; i < numOfQuestions; i++)
        {
            var operands = GameLogic.GenerateOperands(gameType);

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

        StoreGame(gameType, score);

        Console.WriteLine($"Your score is {score}");
        Console.WriteLine("Press any key to proceed to the Menu.");
        Console.ReadLine();
        Console.Clear();
    }
    
    public static void PrintGamesHistory()
    {
        Console.Clear();
        Console.WriteLine("Game History\n");

        if (games.Any() == true)
        {
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.GameType}: {game.Score}pts");
            }
        }
        else
        {
            Console.WriteLine("You haven't played any game yet.");
        }
        
        Console.WriteLine("\nPress any key to proceed to the Menu.");
        Console.ReadLine();
        Console.Clear();
    }

    private static void StoreGame(GameType gameType, int score)
    {
        games.Add(new Game
        {
            Date = DateTime.Now,
            GameType = gameType,
            Score = score
        });
    }

    
}
