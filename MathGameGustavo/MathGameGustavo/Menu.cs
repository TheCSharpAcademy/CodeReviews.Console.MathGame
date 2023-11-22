namespace MathGameGustavo
{
    internal class Menu
    {
        Helpers helpers = new Helpers();
        GameEngine engine = new GameEngine();
        internal void ShowMenu(string name, DateTime date)
        {
            bool isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine($"Hello, {name}, today is {date}.\n");
                Console.WriteLine(@$"Select what game you want to play:
        A - Addition
        S - Subtraction
        M - Multiplication
        D - Division
        R - Random
        V - View Previous Games
        Q - Quit game");

                string gameSelected = Console.ReadLine();

                switch (gameSelected.Trim().ToLower())
                {
                    case "a":
                        engine.AdditionGame("Addition game:\n");
                        break;
                    case "s":
                        engine.SubtractionGame("Subtraction game:\n");
                        break;
                    case "m":
                        engine.MultiplicationGame("Multiplication game:\n");
                        break;
                    case "d":
                        engine.DivisionGame("Division game:\n");
                        break;
                    case "r":
                        engine.RandomGame("Random Game:\n");
                        break;
                    case "v":
                        helpers.PrintGames();
                        break;
                    case "q":
                        Console.WriteLine("\nQuitting game\n");
                        isGameOn = false;
                        break;
                    default:
                        break;
                }
            } while (isGameOn);
        }
    }
}
