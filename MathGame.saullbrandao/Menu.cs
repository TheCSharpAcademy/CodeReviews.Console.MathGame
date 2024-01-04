namespace MathGame.saullbrandao;

public class Menu
{
    public static void ShowMenu()
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
}