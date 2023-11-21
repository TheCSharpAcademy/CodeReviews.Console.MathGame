namespace MathGame.nwdorian;

internal class Menu
{
    GameEngine gameEngine = new GameEngine();
    internal void ShowMenu(string name, DateTime date)
    {
        Console.WriteLine($"Hello {name.ToLower()}! Today is {date.DayOfWeek}. Welcome to the Math Game.");
        Console.WriteLine("Press any key to show menu");
        Console.ReadKey();

        bool isGameOn = true;
        do
        {
            Console.Clear();
            Console.WriteLine("Choose an option from the main menu:");
            Console.WriteLine("X - Select Difficulty");
            Console.WriteLine("A - Addition");
            Console.WriteLine("S - Subtraction");
            Console.WriteLine("M - Multiplication");
            Console.WriteLine("D - Division");
            Console.WriteLine("V - View results");
            Console.WriteLine("Q - Quit the program");
            string menuSelection = "";
            string? userInput = Console.ReadLine();
            if (userInput != null)
            {
                menuSelection = userInput.ToUpper().Trim();
            }

            switch (menuSelection)
            {
                case "X":
                    Helpers.SelectDifficulty();
                    break;
                case "A":
                    gameEngine.AdditionGame("Addition Selected");
                    break;
                case "S":
                    gameEngine.SubtractionGame("Subtraction selected");
                    break;
                case "M":
                    gameEngine.MultiplicationGame("Multiplication selected");
                    break;
                case "D":
                    gameEngine.DivisionGame("Division selected");
                    break;
                case "V":
                    Helpers.PrintGames();
                    break;
                case "Q":
                    Console.WriteLine("Goodbye");
                    isGameOn = false;
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    break;
            }
        } while (isGameOn);
    }
}

