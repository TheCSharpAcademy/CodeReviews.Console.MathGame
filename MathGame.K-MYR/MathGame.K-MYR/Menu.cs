using MathGame.K_MYR.Models;

namespace MathGame.K_MYR
{
    internal class Menu
    {
        GameEngine engine = new();

        internal void ShowMenu(string name, DateTime date)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine($"Hello {name.ToUpper()}. It's {date}. This is your math's game. That's great that you're working on improving yourself\n");
            Console.WriteLine("Press enter to show menu");
            Console.ReadLine();

            bool isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine("What game would you like to play today? Choose from the options below?:");
                Console.WriteLine("--------------------------------------------------------------------------");
                Console.WriteLine("V - View Previous Games");
                Console.WriteLine("A - Addition");
                Console.WriteLine("S - Subtraction");
                Console.WriteLine("M - Multiplication");
                Console.WriteLine("D - Division");
                Console.WriteLine("R - Random Mode");
                Console.WriteLine("Q - Quit the program");
                Console.WriteLine("--------------------------------------------------------------------------");

                var gameSelected = Console.ReadLine();
                int NumberOfGames;
                DifficultyMode difficulty;

                switch (gameSelected.Trim().ToLower())
                {
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "a":
                        NumberOfGames = Helpers.GetNumberOfGames();
                        difficulty = Helpers.GetDifficulty();
                        engine.AdditionGame(NumberOfGames, difficulty);
                        break;
                    case "s":
                        NumberOfGames = Helpers.GetNumberOfGames();
                        difficulty = Helpers.GetDifficulty();
                        engine.SubtractionGame(NumberOfGames, difficulty);
                        break;
                    case "m":
                        NumberOfGames = Helpers.GetNumberOfGames();
                        difficulty = Helpers.GetDifficulty();
                        engine.MultiplicationGame(NumberOfGames, difficulty);
                        break;
                    case "d":
                        NumberOfGames = Helpers.GetNumberOfGames();
                        difficulty = Helpers.GetDifficulty();
                        engine.DivisionGame(NumberOfGames, difficulty);
                        break;
                    case "r":
                        NumberOfGames = Helpers.GetNumberOfGames();
                        difficulty = Helpers.GetDifficulty();
                        engine.RandomGame(NumberOfGames, difficulty);
                        break;
                    case "q":
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        isGameOn = false;
                        break;
                    default:                                         
                        break;
                } 
            } while (isGameOn);
        }
    }
}
