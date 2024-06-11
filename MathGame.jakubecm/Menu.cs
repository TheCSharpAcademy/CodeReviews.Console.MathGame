namespace MathGame.jakubecm
{
    internal class Menu
    {
        internal void ShowMenu(string playerName)
        {
            GameEngine gameEngine = new();
            bool isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine($"\nCurrent player: {playerName}");
                Console.WriteLine("Press any key to show menu");
                Console.ReadLine();
                Console.Write(@"Choose game from the options bellow:
        A - Addition
        S - Subtraction
        M - Multiplication
        D - Division
        V - View Previous Games
        Q - Quit the program
        Selected action:  ");

                var selectedGame = Console.ReadLine();

                switch (selectedGame?.Trim().ToLower())
                {
                    case "a":
                        gameEngine.AdditionGame("Addition game");
                        break;
                    case "s":
                        gameEngine.SubtractionGame("S game");
                        break;
                    case "m":
                        gameEngine.MultiplicationGame("M game");
                        break;
                    case "d":
                        gameEngine.DivisionGame("D game");
                        break;
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "q":
                        Console.WriteLine("Program exit");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }

            } while (isGameOn);
        }
    }
}
