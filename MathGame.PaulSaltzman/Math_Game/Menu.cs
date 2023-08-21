using System;
using static Math_Game.Models.Game;


namespace Math_Game
{
    internal class Menu
    {
        GameEngine gameEngine = new();
        internal void ShowMenu(string? name, DateTime date)
        {
            Console.Clear();
            Console.WriteLine("___________________________________________________________");
            Console.WriteLine($"Hello {name.ToUpper()}. It's {date.DayOfWeek}. This is your math game.  That's great that you're working on improving yourself\n");
            Console.WriteLine("Press any key to show the menu");
            Console.ReadLine();
            Console.WriteLine("\n");

            var difficultyLevel = DifficultyLevel.Medium;
            var isGameOn = true;
            do
            {
                Console.Clear();
                Console.Write($@"What game would you like to play today? Choose from the options below:
V - View Previous Games
L - Difficulty:");
                Helpers.ColorPicker(difficultyLevel);          
                Console.WriteLine($@"A - Addition
S - Subtraction
M - Multiplication 
D - Division
Q - Quit the program");
                Console.WriteLine("___________________________________________________________");

                var gameSelected = Console.ReadLine();

                switch (gameSelected.Trim().ToLower())
                {

                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "l":
                        difficultyLevel = Helpers.SetLevel(difficultyLevel);
                        break;
                    case "a":
                        gameEngine.AdditionGame("Addition Game!",difficultyLevel);
                        break;
                    case "s":
                        gameEngine.SubtractionGame("Subtraction Game!",difficultyLevel);
                        break;
                    case "m":
                        gameEngine.MultiplicationGame("Multiplication Game!",difficultyLevel);
                        break;
                    case "d":
                        gameEngine.DivisionGame("Division Game!", difficultyLevel);
                        break;
                    case "q":
                        Console.WriteLine("Goodbye");
                        isGameOn = false;
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Invalid Selection"); //This actually doesn't show
                        break;
                }
            } while (isGameOn);
        }

    }
}
