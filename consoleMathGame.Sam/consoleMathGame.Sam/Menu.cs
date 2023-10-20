using System;
using System.Linq;

namespace consoleMathGame.Sam
{
    internal class Menu
    {
        GameEngine gameEngine = new();
        internal void ShowMenu(string? name, DateTime date)
        {

            var isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine($@"Hello {name} what game would you like to play today? Choose the options below:
        V - View Previous Games
        A - Addition
        S - Subtraction
        M - Multuplication
        D - Division
        Q - Quit the program");
                Console.WriteLine("------------------------------");

                var gameSelected = Console.ReadLine();

                switch (gameSelected.Trim().ToLower())
                {
                    case "a":
                        gameEngine.AdditionGame("Addition game", name);
                        break;
                    case "s":
                        gameEngine.SubtractionGame("division game", name);
                        break;
                    case "m":
                        gameEngine.MultiplicationGame("Multiplcation game", name);
                        break;
                    case "d":
                        gameEngine.DivisionGame("Division game", name);
                        break;
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "q":
                        Console.WriteLine("Goodbye");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Press any key to contine to try again");
                        Console.ReadLine();
                        break;
                }
            } while (isGameOn);

        }
    }
}
