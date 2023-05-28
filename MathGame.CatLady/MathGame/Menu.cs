using CalculatingGame.Helpers;

namespace CalculatingGame
{
    internal class Menu
    {
        bool isGameRunning;
        GameLogic gameLogic = new();
        internal void ShowMenu()
        {
            Console.WriteLine("Welcome to the calculating game!");
            Console.WriteLine("Please enter your name:");
            var name = Console.ReadLine();
            GameHelper.SetPlayerName(name);
            do
            {
                Console.WriteLine("Please select a game type:");
                Console.WriteLine("A for Addition");
                Console.WriteLine("S for Subtraction");
                Console.WriteLine("M for Multiplication");
                Console.WriteLine("D for Division");
                Console.WriteLine("H to View History");
                Console.WriteLine("Q to Quit");
                var selection = Console.ReadLine();
                if (string.IsNullOrEmpty(selection))
                {
                    Console.WriteLine("No input. Please try again.");
                    selection = Console.ReadLine();
                }
                else
                {
                    switch (selection.Trim().ToLower())
                    {
                        case "a":
                            isGameRunning = true;
                            gameLogic.Add();
                            break;
                        case "s":
                            isGameRunning = true;
                            gameLogic.Subtract();
                            break;
                        case "m":
                            isGameRunning = true;
                            gameLogic.Multiply();
                            break;
                        case "d":
                            isGameRunning = true;
                            gameLogic.Divide();
                            break;
                        case "h":
                            GameHelper.ShowHistory();
                            break;
                        case "q":
                            isGameRunning = false;
                            GameHelper.QuitGameMessage();
                            break;
                        default:
                            Console.WriteLine("Invalid input. Please try again.");
                            break;
                    }
                }              
            } while (isGameRunning);
        }
    }
}
