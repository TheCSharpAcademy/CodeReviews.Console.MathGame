
namespace math_console_app
{
    internal class Menu
    {

        GameEngine gameEngine = new();

        internal void ShowMenu(string name, DateTime date)
        {
            var isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine($"Hello {name?.ToUpper()}. Today is {date.DayOfWeek}. Welcome to the math game. Good luck! \n");
                Console.WriteLine($@"What game would you like to play today? Choose an option below.
        A - Addition
        S - Subtraction
        M - Multiplication
        D - Division
        V - View Game Scores
        Q - Quit the game");

                Console.WriteLine("-------------------------------------------------");

                var gameSelected = Console.ReadLine()?.ToLower().Trim();

                switch (gameSelected)
                {
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
                        Console.WriteLine("Goodbye.");
                        isGameOn = false;
                        Environment.Exit(1);
                        break;
                    case "v":
                        Helpers.ViewGameHistory();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while (isGameOn);
        }
    }
}
