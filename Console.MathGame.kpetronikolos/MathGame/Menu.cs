using MathGameLibrary.Models;

namespace MathGame;

public static class Menu
{
    public static void ShowMenu()
    {
        bool shouldGameContinue = true;

        Console.WriteLine("\nPress any key to show the Menu.");
        Console.ReadLine();
        Console.Clear();

        do
        {
            Console.WriteLine(@"Please select the game you would like to play or any other option:
+    Addition
-    Subtraction
*    Multiplication
/    Division
H -  Game History
Q -  Quit");

            Console.WriteLine();

            string selection = Console.ReadLine();

            Console.Clear();

            switch (selection.Trim().ToLower())
            {
                case "+":
                    GameEngine.GameInit(GameType.Addition, "+");
                    break;
                case "-":
                    GameEngine.GameInit(GameType.Subtraction, "-");
                    break;
                case "*":
                    GameEngine.GameInit(GameType.Multiplication, "*");
                    break;
                case "/":
                    GameEngine.GameInit(GameType.Division, "/");
                    break;
                case "h":
                    GameEngine.PrintGamesHistory();
                    break;
                case "q":
                    Console.WriteLine("Thanks for playing. \nGame Over ...");
                    shouldGameContinue = false;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.\n");
                    break;
            }

        } while (shouldGameContinue);
    }
}
