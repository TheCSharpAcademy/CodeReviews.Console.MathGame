namespace Math_Game
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
                Console.WriteLine("------------------------------");
                Console.WriteLine($"Hello {name.ToUpper()}. It's {date.DayOfWeek}. This is your math game.\n");
                Console.WriteLine("Press any key to show menu");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine($@"Please choose a subject:
V - View Previous Games
A - Addition
S - Subtraction
M - Multiplication
D - Division
Q - Quit the program");
                Console.WriteLine("------------------------------");

                var gameSelected = Console.ReadLine();

                switch (gameSelected.Trim().ToLower())
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
                        Console.Write("Goodbye");
                        isGameOn = false;
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
            while (isGameOn);


        }

    }
}
