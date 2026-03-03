using MathGame.Enums;
using MathGame.Models;
using MathGame.Services;
using MathGame.UI;

var ui = new ConsoleUI();
var generator = new QuestionGenerator();
var history = new GameHistory();
var engine = new GameEngine(generator, ui);

while (true)
{
    string choiceGame = ui.ShowMainMenu();

    if (choiceGame == "0") break;

    if (choiceGame == "5")
    {
        ui.DisplayHistory(history.GetAll());
        continue;
    }

    GameType game;

    switch (choiceGame)
    {
        case "1":
            game = GameType.Addition;
            break;
        case "2":
            game = GameType.Subtraction;
            break;
        case "3":
            game = GameType.Multiplication;
            break;
        case "4":
            game = GameType.Division;
            break;
        case "r":
            game = GameType.Random;
            break;
        default:
            // Use a "sentinel" value to indicate something went wrong
            game = (GameType)(-1);
            break;
    }

    if ((int)game == -1)
    {
        Console.WriteLine("Invalid choice. Press any key...");
        Console.ReadKey();
        continue;
    }

    string choiceDifficulty = ui.ShowDifficultyMenu();
    Difficulty difficulty;

    switch (choiceDifficulty)
    {
        case "1": 
            difficulty = Difficulty.Easy; 
            break;
        case "2":
            difficulty = Difficulty.Medium;
            break;
        case "3":
            difficulty= Difficulty.Hard;
            break;

        default:
            Console.WriteLine("\nInvalid choice. Press any key to try again...");
            Console.ReadKey();
            continue;
    }

    GameSession session = engine.Play(game, difficulty);
    history.Add(session);
}

Console.WriteLine("Thanks for playing!");