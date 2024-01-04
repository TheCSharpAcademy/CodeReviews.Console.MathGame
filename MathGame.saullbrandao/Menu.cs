namespace MathGame.saullbrandao;

internal class Menu
{
    internal static void ShowMenu()
    {
        var isGameActive = true;

        do
        {
            Console.WriteLine();
            Console.WriteLine(@$"Choose the game you would like to play:
A - Addition
S - Subtraction
M - Multiplication
D - Division
R - Random
V - View Games History
Q - Quit");

            var gameSelected = Console.ReadLine();

            switch (gameSelected?.Trim().ToLower())
            {
                case "a":
                    GameEngine.StartGame(GameType.Addition);
                    break;
                case "s":
                    GameEngine.StartGame(GameType.Subtraction);
                    break;
                case "m":
                    GameEngine.StartGame(GameType.Multiplication);
                    break;
                case "d":
                    GameEngine.StartGame(GameType.Division);
                    break;
                case "r":
                    GameEngine.StartGame(GameType.Random);
                    break;
                case "v":
                    Helpers.PrintGames();
                    break;
                case "q":
                    Console.WriteLine("Thanks for playing.");
                    isGameActive = false;
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again.");
                    break;
            }
        } while (isGameActive);
    }

    internal static GameDifficulty SelectDifficulty()
    {
        do
        {
            Console.WriteLine();
            Console.WriteLine(@$"Choose the game difficulty:
1 - Easy
2 - Normal
3 - Hard");

            var difficulty = Console.ReadLine();

            switch (difficulty?.Trim())
            {
                case "1":
                    return GameDifficulty.Easy;
                case "2":
                    return GameDifficulty.Normal;
                case "3":
                    return GameDifficulty.Hard;
                default:
                    Console.WriteLine("Invalid input. Try again.");
                    break;
            }
        } while (true);
    }
}