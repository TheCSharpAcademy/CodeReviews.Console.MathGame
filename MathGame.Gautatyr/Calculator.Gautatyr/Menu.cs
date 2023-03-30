using Calculator.Gautatyr.Models;

namespace Calculator.Gautatyr;

internal class Menu
{
    GameEngine gameEngine = new GameEngine();
    internal void ShowMenu(string name, DateTime date)
    {
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine($"Hello {name}. It's {date.DayOfWeek}. This is your math's game. That's great that you're working on improving yourself");
        Console.WriteLine("\n");

        var isGameOn = true;

        do
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($@"What game would you like to play today? Choose from the options below:
                        V - View Previous Games
                        A - Addition
                        S - Substraction
                        M - Multiplication
                        D - Division
                        Q - Quit the program");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");

            var gameSelected = Console.ReadLine().Trim().ToLower();
            GameDifficulty difficulty;

            switch (gameSelected)
            {
                case "v":
                    Helpers.GetGames();
                    break;
                case "a":
                    difficulty = Helpers.ChooseDifficulty();
                    gameEngine.AdditionGame("Addition game", difficulty);
                    break;
                case "s":
                    difficulty = Helpers.ChooseDifficulty();
                    gameEngine.SubstractionGame("Substraction game", difficulty);
                    break;
                case "m":
                    difficulty = Helpers.ChooseDifficulty();
                    gameEngine.MultiplicationGame("Multiplication game", difficulty);
                    break;
                case "d":
                    difficulty = Helpers.ChooseDifficulty();
                    gameEngine.DivisionGame("Division game", difficulty);
                    break;
                case "q":
                    Console.WriteLine("Goodbye !");
                    Console.ReadLine();
                    isGameOn = false;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input, press any key to go back in the menu.");
                    Console.ReadLine();
                    break;
            }
            Console.Clear();
        } while (isGameOn);
    }
}
