using MathGame.wkktoria.Models;

namespace MathGame.wkktoria;

internal class Menu
{
    internal void ShowMenu(string name)
    {
        Console.Clear();
        Console.WriteLine(
            $"Hello {Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(name.ToLower())}. It's {DateTime.UtcNow.DayOfWeek}. This is math's game.\n");
        Console.WriteLine("Press any key to go to the main menu.");
        Console.ReadLine();

        var isGameOn = true;

        do
        {
            Console.Clear();
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
            Console.WriteLine("""
                              What would you like to play today? Choose from the options below:

                              V - View previous games
                              A - Addition
                              S - Subtraction
                              M - Multiplication
                              D - Division
                              Q - Quit the program
                              """);
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
            Console.Write("> ");
            var gameSelected = Console.ReadLine();
            var difficulty = Helpers.ChooseDifficulty();

            switch (gameSelected.Trim().ToLower())
            {
                case "v":
                    Helpers.PrintPreviousGames();
                    break;
                case "a":
                    GameEngine.AdditionGame($"{GameType.Addition} game", difficulty);
                    break;
                case "s":
                    GameEngine.SubtractionGame($"{GameType.Subtraction} game", difficulty);
                    break;
                case "m":
                    GameEngine.MultiplicationGame($"{GameType.Multiplication} game", difficulty);
                    break;
                case "d":
                    GameEngine.DivisionGame($"{GameType.Division} game", difficulty);
                    break;
                case "q":
                    Console.WriteLine("Quiting...");
                    isGameOn = false;
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        } while (isGameOn);
    }
}