using MathGame.Models;
using Type = System.Type;

namespace MathGame;

internal class Menu
{
    internal void ShowMenu(string name, DateTime date)
    {
        bool playAgain = true;
        
        Console.WriteLine($"Hello {name}! It is {date}.");

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
        Console.WriteLine("---------------------------");
        Console.WriteLine("Math Game");
        
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        
        string menuSelection = Console.ReadLine();

        switch (menuSelection)
        {
            case "1":
                int result = engine.AdditionGame();
                
                Helpers.AddToScores(new Score(DateTime.Now, Models.Type.Addition,  result));
                break;
        }
    }
}