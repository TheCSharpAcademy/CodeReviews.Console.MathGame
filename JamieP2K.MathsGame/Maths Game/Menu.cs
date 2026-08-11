using Maths_Game.Models;

namespace Maths_Game;

internal class Menu
{
    GameEngine gameEngine = new();
    internal void MainMenu(string name)
    {

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Welcome {name} to the math game. Select an option.\n");
            Console.WriteLine("1. Play");
            Console.WriteLine("2. History");
            Console.WriteLine("3. Quit");
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    ModeSelect();
                    break;
                case 2:
                    Helpers.DisplayPreviousGames();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
    }

    internal void ModeSelect()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Select a gamemode:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Back");
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    gameEngine.RunGame(GameType.Addition);
                    break;
                case 2:
                    gameEngine.RunGame(GameType.Subtraction);
                    break;
                case 3:
                    gameEngine.RunGame(GameType.Multiplication);
                    break;
                case 4:
                    gameEngine.RunDivisionGame();
                    break;
                case 5:
                    return;
                default:
                    break;
            }
        }
    }
}