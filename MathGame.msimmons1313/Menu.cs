namespace MyFirstProgram
{
    internal class Menu
    {
        GameEngine engine = new GameEngine();

        internal void ShowMenu(string name, DateTime date)
        {
            Console.Clear();
            Console.WriteLine($"Hello {name.ToUpper()}. It's {date.DayOfWeek}. This is your math game. That's great that you're working on improving yourself\n");
            Console.WriteLine("Press any key to show menu");
            Console.ReadLine();
            Console.WriteLine("\n");

            bool isGameOn = true;

            do
            {

                Console.Clear();
                Console.WriteLine(@$"
What game would you like to play today? Chose from the options below:
V - View Previous Games
A - Addition
S - Subtraction
M - Multiplication
D - Division
O - Set Difficulty
Q - Quit the program");
                Console.WriteLine("-----------------------------------------");

                string gameSelected = Console.ReadLine();

                switch (gameSelected.Trim().ToLower())
                {
                    case "v":
                        Helpers.PrintGames();
                        break;

                    case "a":
                        engine.AdditionGame("Addition game");
                        break;

                    case "s":
                        engine.SubtractionGame("Subtraction game");
                        break;

                    case "m":
                        engine.MultiplicationGame("Multiplication game");
                        break;

                    case "d":
                        engine.DivisionGame("Division game");
                        break;

                    case "o":
                        Helpers.SetGameDifficulty();
                        break;

                    case "q":
                        Console.WriteLine("Goodbye");
                        isGameOn = false;
                        Environment.Exit(1);
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        Environment.Exit(1);
                        break;
                };

            } while (isGameOn);

        }

    }
}
