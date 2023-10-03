using Math_Game_v2.Models;

namespace Math_Game_v2;

public class Menu
{
     private GameEngine gameEngine = new(); // Allows to call the methods from the class GameEngine.
     internal void ShowMenu(string username, DateTime date)
        {
            Console.Clear();
            Console.WriteLine(
                $"Hello {username}. It's {date}. This is your computer speaking. You are going to play a game with my transistors heheheheh.");
            // $ sign allows for String Interpolation (the use of curly braces). @ allows for multi-line block of text.
            Console.WriteLine("Press any key to show menu");
            Console.ReadLine();
            Console.WriteLine("\n");

            var isGameOn = true;

            do
            {
                Console.WriteLine(@$"What game would you like to play today? Choose from the user-friendly-looking enhanced binary options below:
                V - View Previous Games  
                A - Addition
                S - Subtraction
                M - Multiplication          
                D - Division
                Q - Quit the program");
                Console.WriteLine("----------------------");

                var gameSelected = Console.ReadLine();

                switch (gameSelected.Trim().ToLower()) // Trim() is necessary to take into account spaces in input.
                {
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "a":
                        gameEngine.AdditionGame("Addition game");
                        break;
                    case "s":
                        gameEngine.SubtractionGame("Subtraction game");
                        break;
                    case "m":
                        gameEngine.MultiplicationGame("Multiplication game");
                        break;
                    case "d":
                        gameEngine.DivisionGame("Division game");
                        break;
                    case "q":
                        Console.WriteLine("Goodbye, have fun suffering in the \"real\" world :)");
                        Environment.Exit(1);
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        
                        break;
                }
            } while (isGameOn);
            
        }
}