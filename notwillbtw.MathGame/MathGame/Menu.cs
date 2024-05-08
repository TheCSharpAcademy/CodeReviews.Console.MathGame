namespace MathGame
{
    internal class Menu
    {
        GameEngine engine = new();
        internal void ShowMenu(string name, DateTime date)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($"Hello, {name}. the date is {date}. welcome to the maths game. \n");

            bool isGameOn = true;

            do
            {
                Console.WriteLine($"What game would you like to play? choose from the following options: \nV - View Previous Games \nA - Addition \nS - Subtraction \nM - Multiplication \nD - Division \nR - Random Questions \nQ - Quit the program");
                Console.WriteLine("------------------------");

                var gameSelected = Console.ReadLine().ToLower().Trim();

                switch (gameSelected)
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
                    case "r":
                        engine.RandomGame("Random Game");
                        break;
                    case "q":
                        Console.WriteLine("goodbye!");
                        isGameOn = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("invalid input");
                        break;
                }
            } while (isGameOn);
        }
    }
}