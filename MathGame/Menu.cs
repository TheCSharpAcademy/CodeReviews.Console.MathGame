using MathGame.Models;

namespace MathGame
{
    internal class Menu
    {
        GameEngine gameEngine = new();
        internal void ShowMenu(string? name, DateTime date)
        {
            Console.WriteLine($"Hello {name}! It's {date.DayOfWeek} and this is maths game!!");
            Console.WriteLine("Press any key to show menu");
            Console.ReadLine();

            var isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine($@"What game would you like to play today?choose from below
                V - view previous games
                A - addition
                S - subtraction
                M - multiplication
                D - division
                Q - quit the program");
                Console.WriteLine("\n-----------------------------------------------------");

                var gameSelected = Console.ReadLine();

                switch (gameSelected.Trim().ToLower())
                {
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "a":
                        gameEngine.AdditionGame("Addition Game");
                        break;
                    case "s":
                        gameEngine.SubtractionGame("Subtraction Game");
                        break;
                    case "m":
                        gameEngine.MultiplicationGame("Multiplication Game");
                        break;
                    case "d":
                        gameEngine.DivisionGame("Division Game");
                        break;
                    case "q":
                        Console.Clear();
                        Console.WriteLine("Goodbye");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            } while (isGameOn);
        }
    }
}
