namespace MyFirstProgram
{
    internal class Menu
    {
        GameEngine gameEngine = new();
        bool isGameOn = true;
        internal void ShowMenu(string name, DateTime date)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("------------------------------------------------------------------");

                Console.WriteLine($"Hello {name.ToUpper()}. It's {date.DayOfWeek}. This is a math game.\n");
                Console.WriteLine($@"What game would you like to play?
                             A - Addition
                             S - Subtraction
                             M - Multiplication
                             D - Division
                             R - Randomize each question
                             G - Games
                             Q - Quit");
                Console.WriteLine("------------------------------------------------------------------");


                var gameSelected = Console.ReadLine().ToLower().Trim();

                switch (gameSelected)
                {
                    case "a":
                        gameEngine.AdditionGame("Addition game selected", Helpers.SelectDifficulty(), Helpers.SelectQuestions(), false);
                        break;
                    case "s":
                        gameEngine.SubtractionGame("Subtraction game selected", Helpers.SelectDifficulty(), Helpers.SelectQuestions(), false);
                        break;
                    case "m":
                        gameEngine.MultiplicationGame("Multiplication game selected", Helpers.SelectDifficulty(), Helpers.SelectQuestions(), false);
                        break;
                    case "d":
                        gameEngine.DivisionGame("Division game selected", Helpers.SelectDifficulty(), Helpers.SelectQuestions(), false);
                        break;
                    case "r":
                        gameEngine.RandomGame("Random game selected", Helpers.SelectDifficulty(), Helpers.SelectQuestions(), true);
                        break;
                    case "g":
                        Helpers.PrintGames();
                        break;
                    case "q":
                        Console.WriteLine("Goodbye");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid game");
                        break;
                }

            } while (isGameOn);
        }


    }
}
