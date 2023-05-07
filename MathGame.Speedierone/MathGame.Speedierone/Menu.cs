namespace Math_Game
{
    internal class Menu
    {
        GameEngine engine = new();
        internal void ShowMenu(string name, DateTime date)
        {

            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Hello {name}. Its {date}. This is your math's game. That's great that you're working on improving yourself");
            Console.WriteLine("\n");
            Console.WriteLine($"Press a button to continue");
            Console.ReadLine();

            bool isGameOn = true;
            do
            {
                Console.Clear();
                Console.WriteLine($@"What game would you like to play today? Choose from the options below:
V - View previous games
A - Addition
S - Subtraction
M - Multiplication
D - Division
Q - Quit the programme");
                Console.WriteLine("----------------------------------");
                var gameSelected = Console.ReadLine();
                switch (gameSelected.Trim().ToLower())
                {
                    case "v":
                        Helpers.GetGames();
                        break;
                    case "a":
                        GameEngine.additionGame("Addition game");
                        break;
                    case "s":
                        GameEngine.subtractionGame("Subtraction game");
                        break;
                    case "m":
                        GameEngine.multiplicationGame("Multiplication game");
                        break;
                    case "d":
                        GameEngine.divisionGame("Division game");
                        break;
                    case "q":
                        Console.WriteLine("Goodbye");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
            while (isGameOn);
        }
    }
}

