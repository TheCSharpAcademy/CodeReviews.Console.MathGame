namespace MathGame {
    internal class Menu {

        internal void ShowMenu(string? name, DateTime date) {
            Console.Clear();
            Console.WriteLine($"Hello, {name}. It's {date}.\n" +
                                $"Welcome to the Math Game!");
            Console.WriteLine("\n");
            Console.Write("Press any key to show menu\n" +
                              ">");
            Console.ReadLine();

            GameEngine gameEngine = new();

            bool isGameOn = true;

            do {

                Console.WriteLine("<--------------------------------->");
                Console.Write("What game would you like to play now? Choose one of the options below:\n" +
                                  "V -> View previows games\n" +
                                  "A -> Addition\n" +
                                  "S -> Subtraction\n" +
                                  "M -> Multiplication\n" +
                                  "D -> Division\n" +
                                  "R -> Random Game" +
                                  "Q -> Quit\n\n" +

                                  ">");
                string selectedGame = Console.ReadLine().ToString().Trim().ToUpper();

                switch (selectedGame) {
                    case "V":
                        Helpers.PrintGames();
                        break;
                    case "A":
                        gameEngine.Addition();
                        break;
                    case "S":
                        gameEngine.Subtraction();
                        break;
                    case "M":
                        gameEngine.Multiplication();
                        break;
                    case "D":
                        gameEngine.Division();
                        break;
                    case "R":
                        gameEngine.Random();
                        break;
                    case "Q":
                        Console.WriteLine("Goodbye! ;)");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            } while (isGameOn);


        }
    }
}
