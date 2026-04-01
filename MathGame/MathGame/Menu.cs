using MathGame.Models;

namespace MathGame;

internal class Menu
{
    internal void ShowMenu(string name, DateTime date)
    {
        bool playAgain = true;
        
        Console.Clear();
        Console.WriteLine($"Hello {name}! It is {date}.");
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();

        Console.Clear();
        
        do
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Play Math Game!");
            Console.WriteLine("2. Show Scores");
            Console.WriteLine("Enter x to exit");
            
            string menuSelection = Console.ReadLine();

            switch (menuSelection)
            {
                case "1":
                    PlayMathGame();
                    break;
                case "2":
                    Console.Clear();
                    Helpers.PrintScores();
                    break;
                case "x":
                    playAgain = false;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }
        } while (playAgain);
        
        Console.WriteLine("Thanks for playing!");
    }

    internal void PlayMathGame()
    {
        GameEngine engine = new GameEngine();
        
        Console.Clear();
        
        bool isPlaying = true;

        do
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Math Game");

            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("Enter x to exit.");

            string menuSelection = Console.ReadLine();
            int result = 0;

            switch (menuSelection)
            {
                case "1":
                    result = engine.AdditionGame();

                    Helpers.AddToScores(result, GameType.Addition);
                    break;
                case "2":
                    result = engine.SubtractionGame();

                    Helpers.AddToScores(result, GameType.Subtraction);
                    break;
                case "3":
                    result = engine.MultiplicationGame();

                    Helpers.AddToScores(result, GameType.Multiplication);
                    break;
                case "4":
                    result = engine.DivisionGame();

                    Helpers.AddToScores(result, GameType.Division);
                    break;
                case "x":
                    isPlaying = false;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }
        } while (isPlaying);

    }
}