namespace ConsoleMathsGame
{
    internal class Menu
    {
        internal static void MainProgramRepeat()
        {
            MenuLogic();
            GameLogic();
            MenuReturn();
        }
        internal static void MenuLogic()
        {
            int score = 0;
            Console.WriteLine("Welcome! Which game would you like to play?");
            Console.WriteLine("+ = Addition\n- = Subtraction\n* = Multiplication\n/ = Division\nR = Random Game\nV = View Previous Games\nQ = Quit");
            Console.WriteLine("-----");
        }
        internal static void GameLogic()
        {
            string chosenDifficulty;
            var gameChoice = Console.ReadLine().ToLower().Trim();

            switch (gameChoice)
            {
                case "+":
                    GameEngine.AdditionGame();
                    break;

                case "-":
                    GameEngine.SubtractionGame();
                    break;

                case "*":
                    GameEngine.MultiplicationGame();
                    break;

                case "/":

                    Console.WriteLine("Easy or Hard? (E/H): ");
                    chosenDifficulty = Console.ReadLine().ToLower().Trim();
                    if (chosenDifficulty == "e")
                    {
                        Console.Clear();
                        GameEngine.DivisionGameEasy();
                    }
                    else if (chosenDifficulty == "h")
                    {
                        Console.Clear();
                        GameEngine.DivisionGameHard();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid choice");
                    }
                    break;

                case "r":
                    GameEngine.RandomGame();
                    break;

                case "v":

                    Helpers.ViewPrevGames();

                    break;

                case "q":

                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                    break;

                default:

                    Console.Clear();
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
        internal static void MenuReturn()
        {
            Console.WriteLine("Would you like to return to the menu? Y/N : ");
            var playAgain = Console.ReadLine().ToLower().Trim();
            switch (playAgain)
            {
                case "y":

                    Console.WriteLine("---");
                    MainProgramRepeat();
                    break;

                case "n":

                    Console.WriteLine("Goodbye!");
                    Console.WriteLine("Press any key");
                    Console.ReadKey();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid");
                    MenuReturn();
                    break;

            }
        }
    }
}
