namespace MathGame.Models
{
    internal class Menu
    {
        GameEngine engine = new();

        internal void ShowMenu(string name, DateTime date)
        {
            Console.Clear();
            Console.WriteLine($"Hello {name}, it's {date.DayOfWeek}. Welcome to your math's game. I hope you will enjoy it!");
            Console.ReadLine();
            Console.WriteLine("\n");

            var isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine(@$"What game mode would you like to choose?
        A - Addition
        S - Subtraction
        M - MUltiplication
        D - Division
        V - View previous games
        Q - Quit the program");
                Console.WriteLine("________________________________");


                var gameModeSelected = Console.ReadLine().Trim().ToLower();

                switch (gameModeSelected.Trim().ToLower())
                {
                    case "a":
                        engine.AdditionGame("Addition Game");
                        break;
                    case "s":
                        engine.SubtractionGame("Subtraction Game");
                        break;
                    case "m":
                        engine.MultiplicationGame("Multiplication Game");
                        break;
                    case "d":
                        engine.DivisionGame("Division Game");
                        break;
                    case "q":
                        Console.WriteLine("Quitting the program. Goodbye!");
                        isGameOn = false;
                        Environment.Exit(1);
                        break;
                    case "v":
                        Helpers.GetGames();
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            } while (isGameOn);


        }
    }
}
