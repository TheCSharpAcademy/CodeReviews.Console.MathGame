using MyFirstProgram.Models;

namespace MyFirstProgram
{
    internal class Menu
    {
        GameEngine engine = new();
        DifficultyLevel difficulty;
        internal void ShowMenu(string name, DateTime date)
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Hello {name.ToUpper()}. It's {date.DayOfWeek}. This is your math's game. That's great that you are working on improving yourself\n");
            Console.WriteLine("Press any key to show difficulty menu...");
            Console.ReadLine();
            int lowerLimit = 0;
            int upperLimit = 0;
            bool isGameOn = true;

            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine(@"Choose your difficulty level:
                        E - Easy
                        M - Medium
                        H - Hard
                        ");
                    string? readInput = Console.ReadLine();
                    if (readInput != null)
                    {
                        string choice = readInput;
                        choice = choice.Trim().ToLower();
                        switch (choice)
                        {
                            case "e":
                                lowerLimit = 1;
                                upperLimit = 15;
                                difficulty = DifficultyLevel.Easy;
                                break;
                            case "m":
                                lowerLimit = 16;
                                upperLimit = 50;
                                difficulty = DifficultyLevel.Medium;
                                break;
                            case "h":
                                lowerLimit = 51;
                                upperLimit = 100;
                                difficulty = DifficultyLevel.Hard;
                                break;
                            default:
                                Console.WriteLine("Invalid input. Please try again...");
                                Console.ReadLine();
                                continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Input can't be null. Please try again...");
                        Console.ReadLine();
                        continue;
                    }
                } while (false);

                Console.Clear();
                Console.WriteLine(@$"What games would you like to play today? Choose from the options below:
                V - View Previous Game Results
                A - Addition
                S - Subtraction
                M - Multiplication
                D - Division
                Q - Quit the program");
                Console.WriteLine("------------------------------------------");
                var gameSelected = Console.ReadLine();
                gameSelected = gameSelected.Trim().ToLower();

                switch (gameSelected)
                {
                    case "a":
                        engine.AdditionGame(lowerLimit, upperLimit, difficulty);
                        break;
                    case "s":
                        engine.SubtractionGame(lowerLimit, upperLimit, difficulty);
                        break;
                    case "m":
                        engine.MultiplicationGame(lowerLimit, upperLimit, difficulty);
                        break;
                    case "d":
                        engine.DivisionGame(lowerLimit, upperLimit, difficulty);
                        break;
                    case "v":
                        Helpers.ViewGameResults();
                        break;
                    case "q":
                        Console.WriteLine("Exiting the program\nGoodbye");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }

                string? playAgain;
                do
                {
                    Console.Clear();
                    Console.Write("Do you want to play again: Press 'y' for yes and 'n' for no: ");
                    playAgain = Console.ReadLine();
                    if (playAgain != null)
                    {
                        playAgain = playAgain.Trim().ToLower();
                        if (playAgain == "y")
                        {
                            isGameOn = true;
                            break;
                        }
                        else if (playAgain == "n")
                        {
                            isGameOn = false;
                            Console.WriteLine("Thanks for playing. Hope you liked it....");
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                            Console.ReadLine();
                            continue;
                        }

                    }
                } while (playAgain == null || (playAgain != "y" && playAgain != "n"));
            } while (isGameOn);
        }
    }
}
