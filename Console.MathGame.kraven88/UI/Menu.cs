using MathGame.Models;
using System.Diagnostics;

namespace MathGame.UI;
internal class Menu
{
    internal List<string> gameHistory = new();
    GameLogic game = new();

    internal void MainMenu()
    {
        var isGameOn = true;
        UserMessages.WelcomeMessage();

        do
        {
            Console.Clear();
            var gameSelected = GameSelection();

            switch (gameSelected)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    PlayGame("Addition");
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    PlayGame("Subtraction");
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    PlayGame("Multiplication");
                    break;

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    PlayGame("Division");
                    break;

                case ConsoleKey.R:
                    PlayGame("Random");
                    break;

                case ConsoleKey.H:
                    if (gameHistory.Count > 0)
                        ViewGameHistory();
                    break;

                case ConsoleKey.Q:
                    Console.WriteLine("Goodbye");
                    Console.ReadLine();
                    isGameOn = false;
                    break;

                default:
                    Console.WriteLine("Invalid input");
                    Console.ReadLine();
                    break;
            }
        } while (isGameOn);
    }

    private ConsoleKey GameSelection()
    {
        Console.WriteLine(@$" What game would you like to play today:
    1 - Addition
    2 - Subtraction
    3 - Multiplication
    4 - Division
    R - Random Game
    H - Game History
    Q - Quit the program
-------------------------------------------------");
        ConsoleKeyInfo key = Console.ReadKey(true);
        return key.Key;
    }
    private Difficulty SelectDifficulty()
    {
        Console.Clear();
        Console.WriteLine(@"Select difficulty level:
    1 - Easy
    2 - Medium
    3 - Hard
-------------------------");
        Difficulty difficulty = Difficulty.NotSelected;

        while (difficulty == Difficulty.NotSelected)
        {
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    difficulty = Difficulty.Easy;
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    difficulty = Difficulty.Medium;
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    difficulty = Difficulty.Hard;
                    break;

                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }
        return difficulty;
    }
    private int SelectNumberOfRounds()
    {
        Console.Clear();
        Console.Write("How many rounds would you like to play: ");
        return UserMessages.GetAndValidateInteger("Please enter a whole number.");
    }
    private void ViewGameHistory()
    {
        Console.Clear();
        Console.WriteLine("History of previous games");
        Console.WriteLine("------------------------------------");

        foreach (var game in gameHistory)
            Console.WriteLine(game);

        Console.ReadLine();
    }
    private void PlayGame(string gameType)
    {
        var difficulty = SelectDifficulty();
        var rounds = SelectNumberOfRounds();

        Console.WriteLine($"{gameType}({difficulty}) game");

        var timer = Stopwatch.StartNew();
        var entry = game.NewGame(new GameEntry 
        {
            GameType = gameType, 
            NumberOfRounds = rounds, 
            Difficulty = difficulty,
        });

        timer.Stop();
        entry.CompletionTime = timer.Elapsed;
        var score = UserMessages.GetScore(entry);
        gameHistory.Add(score);
    }
}
