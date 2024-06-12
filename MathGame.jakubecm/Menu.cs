using MathGame.jakubecm.Models;

namespace MathGame.jakubecm
{
    internal class Menu
    {
        internal void ShowMenu(string playerName)
        {
            GameEngine gameEngine = new();
            bool isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine($"Welcome to the Math game!\nCurrent player: {playerName}");
                Console.WriteLine("Press any key to show menu");
                Console.ReadLine();
                Console.Write(@"Choose game from the options bellow:
                A - Addition
                S - Subtraction
                M - Multiplication
                D - Division
                V - View Previous Games
                Q - Quit the program
                Selected action:  ");

                var selectedGame = Console.ReadLine();

                switch (selectedGame?.Trim().ToLower())
                {
                    case "a":
                        gameEngine.Game("Addition game", GameType.Addition);
                        break;
                    case "s":
                        gameEngine.Game("Subtraction game", GameType.Subtraction);
                        break;
                    case "m":
                        gameEngine.Game("Multiplication game", GameType.Multiplication);
                        break;
                    case "d":
                        gameEngine.Game("Division game", GameType.Division);
                        break;
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "q":
                        Console.WriteLine("Program exit");
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
