namespace MathGame
{
    internal class Menu
    {
        Games games = new();

        internal void ShowMenu(string? name, DateTime date, int questionAmount)
        {
            bool running = true;

            do
            {
                Console.Clear();
                Console.WriteLine("-------------------------------");
                Console.WriteLine($"Hello {name}. It's {date}. Your current score is: {games.score}.");
                Console.WriteLine("\n");
                Console.WriteLine($@"What game would you like to play today? Choose from the options below:
                V - View Game History
                A - Addition
                S - Subtraction
                M - Multiplication
                D - Division
                Q - Quit the program");
                Console.WriteLine("-------------------------------");

                string? gameSelected = Console.ReadLine();

                if (gameSelected != null)
                {
                    gameSelected = gameSelected.Trim().ToLower();
                    switch (gameSelected)
                    {
                        case "v":
                            Helpers.PrintGameHistory();
                            break;
                        case "a":
                            games.AdditionGame(questionAmount);
                            break;
                        case "s":
                            games.SubtractionGame(questionAmount);
                            break;
                        case "m":
                            games.MultiplicationGame(questionAmount);
                            break;
                        case "d":
                            games.DivisionGame(questionAmount);
                            break;
                        case "q":
                            Console.WriteLine("Program quitting...");
                            Thread.Sleep(1000);
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine($"You've entered an invalid option: {gameSelected}\n");
                            break;
                    }
                }
            }
            while (running == true);
        }
    }
}
