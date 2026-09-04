namespace MathGame_v2
{
    internal class Menu
    {
        internal void ShowMenu(string name)
        {
            Console.WriteLine($"Hello {name}! Welcome to the Math Games.");

            bool isGameOn = true;
            do
            {
                Console.Clear();
                Console.WriteLine(@"Select game that you want to play:
                                a - Addition
                                s - Subtraction
                                m - Multiplication
                                d - Division
                                q - Leave the game
                                v - View results history");
                string? chosenGame = Console.ReadLine();
                GameEngine engine = new();

                switch (chosenGame.ToLower())
                {
                    case "a":
                        engine.ChosenGame("a");
                        break;
                    case "s":
                        engine.ChosenGame("s");
                        break;
                    case "m":
                        engine.ChosenGame("m");
                        break;
                    case "d":
                        engine.ChosenGame("d");
                        break;
                    case "v":
                        engine.ViewResultsHistory();
                        break;
                    case "q":
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Bad input.");
                        break;
                }
            } while (isGameOn);

        } 
    }
}
