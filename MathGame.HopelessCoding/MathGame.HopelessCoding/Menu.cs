namespace MathGame.HopelessCoding
{
    internal class Menu
    {
        GameEngine gameEngine = new();

        internal void ShowMenu()
        {
            string input;

            do
            {
                Console.WriteLine("Choose your game mode or command:\n" +
                    "- (+, -, *, /) to play\n" +
                    "- list to list all previous games with correct answers\n" +
                    "- exit to close program:");
                input = Console.ReadLine().ToLower().Trim();

                switch (input)
                {
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                        gameEngine.PlayGame(input);
                        break;
                    case "list":
                        Helpers.ShowHistory();
                        break;
                    case "exit":
                        Console.WriteLine("Thanks for playing!");
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            } while (true);
        }
    }
}
