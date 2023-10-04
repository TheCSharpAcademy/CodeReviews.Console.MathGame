using MathGame.wkktoria.Models;

namespace MathGame.wkktoria;

internal class Menu
{
    internal void ShowMenu(string name)
    {
        Console.Clear();
        Console.WriteLine(
            $"Hello {Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(name.ToLower())}. It's {DateTime.UtcNow.DayOfWeek}. This is math's game.");
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
            var difficulty = DifficultyLevel.Easy;

            switch (gameSelected.Trim().ToLower())
            {
                case "v":
                    Helpers.PrintPreviousGames();
                    break;
                case "a":
                    difficulty = Helpers.ChooseDifficulty();
                    GameEngine.Play(GameType.Addition, difficulty);
                    break;
                case "s":
                    difficulty = Helpers.ChooseDifficulty();
                    GameEngine.Play(GameType.Subtraction, difficulty);
                    break;
                case "m":
                    difficulty = Helpers.ChooseDifficulty();
                    GameEngine.Play(GameType.Multiplication, difficulty);
                    break;
                case "d":
                    difficulty = Helpers.ChooseDifficulty();
                    GameEngine.Play(GameType.Division, difficulty);
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