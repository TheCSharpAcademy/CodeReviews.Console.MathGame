namespace BasicMathsProject
{
    internal class Menu
    {
        readonly GameEngine gameEngine = new();

        internal void ShowMenu(string name, DateTime date)
        {
            Console.WriteLine("-------------------");
            Console.WriteLine($"Hello {name.ToUpper()}. It's {date.DayOfWeek}. This is the math's game");
            Console.WriteLine("\n");

            var isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine(@$"
What game do you want to play? Choose an option:
A - Addition
S - Subtraction
M - Multiplication
D - Division
V - View previous games
Q - Quit");
                Console.WriteLine("--------------------------");

                var gameSelected = Console.ReadLine().Trim().ToLower();
                Console.Clear();
                switch (gameSelected)
                {
                    case "a":
                        Helpers.ChooseDifficulty();
                        gameEngine.AdditionGame();
                        break;

                    case "s":
                        Helpers.ChooseDifficulty();
                        gameEngine.SubtractionGame();
                        break;

                    case "m":
                        Helpers.ChooseDifficulty();
                        gameEngine.MultiplicationGame();
                        break;

                    case "d":
                        Helpers.ChooseDifficulty();
                        gameEngine.DivisionGame();
                        break;

                    case "v":
                        Helpers.PrintGames();
                        break;

                    case "q":
                        Console.WriteLine("Goodbye");
                        isGameOn = false;
                        break;

                    default:
                        Console.WriteLine("Try again");
                        break;
                }
            }
            while (isGameOn);
        }
    }
}
