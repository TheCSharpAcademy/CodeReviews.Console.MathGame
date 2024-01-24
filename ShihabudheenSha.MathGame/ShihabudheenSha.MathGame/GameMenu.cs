namespace ShihabudheenSha.MathGame
{
    internal class GameMenu
    {
        GameEngine gameEngine = new GameEngine();
        internal void ShowGameMenus(string userName)
        {
            Console.Clear();
            Console.WriteLine($"Hi {userName} welcome to the Math Game. Press any key to continue");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.ReadLine();
            bool isGameOn = true;

            do
            {
                Console.Clear();
                string menuOptions = $@"Choose a option from the list
------------------------------------------------------
V - View Score
A - Addition
S - Subtraction
M - Multiplication
D - Division
Q - Quit
              ";

                Console.WriteLine(menuOptions);

                var selectedGameOption = Console.ReadLine().Trim().ToLower();

                switch (selectedGameOption)
                {
                    case "a":
                        gameEngine.AdditionGame();
                        break;
                    case "s":
                        gameEngine.SubtractionGame();
                        break;
                    case "m":
                        gameEngine.MultiplicationGame();
                        break;
                    case "d":
                        gameEngine.DivisionGame();
                        break;
                    case "q":
                        isGameOn = false;
                        Environment.Exit(0);
                        break;
                    case "v":
                        gameEngine.ShowGameScore();
                        break;
                    default:
                        Console.WriteLine("Invalid input. Press any key to continue");
                        break;
                }

            } while (isGameOn);
        }
    }
}
