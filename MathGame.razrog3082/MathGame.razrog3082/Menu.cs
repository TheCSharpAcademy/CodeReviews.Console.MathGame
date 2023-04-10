namespace MathGame
{
    internal class Menu
    {
        GameEngine gameClass = new();

        internal void ShowMenu(string name, DateTime date)
        {
            bool isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine($"Hello {name}. It is {date.DayOfWeek}. This is your math game. Thats great that you're working on improving yourself");
                Console.WriteLine("\n");
                Console.WriteLine($@"What game would you like to play today? Chose from the options below:
 V - View Previous Game(s)
 A - Addition
 S - Subtraction
 M - Multiplication
 D - Division
 Q - Quit the program");
                Console.WriteLine("-------------------------------------------");

                var gameSelected = Console.ReadLine();

                switch (gameSelected.Trim().ToLower())
                {
                    case "v":
                        Helpers.GetGames();
                        break;
                    case "a":
                        gameClass.AdditionGame("Addition game");
                        break;
                    case "s":
                        gameClass.SubtractionGame("Subtraction game");
                        break;
                    case "m":
                        gameClass.MultiplicationGame("Multiplication game");
                        break;
                    case "d":
                        gameClass.DivisionGame("Division game");
                        break;
                    case "q":
                        Console.WriteLine("Goodbye");
                        isGameOn = false;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        Environment.Exit(0);
                        break;
                }
            } while (isGameOn);
        }
    }
}