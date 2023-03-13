using MathGame.Models;

namespace MathGame
{
    internal class Menu
    {
        GameEngine game = new();
        bool difficultySelected = false;
        DifficultyLevel diff;
        internal void ShowMenu(string name, DateTime date)
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------\n");
            Console.WriteLine($"Hello {name}! It's {date.DayOfWeek}. This is your math game. That's great that you are improving yourself.");
            Console.WriteLine("Press any key to show menu");
            Console.ReadLine();

            while (true)
            {
                Console.Clear();
                Console.WriteLine($@"What game would you like to play? Choose from the options below:
V - View Previous Games
A - Addition
S - Subtraction
M - Multiplication
D - Division
R - Random
Q - Quit the program");
                Console.WriteLine("-------------------------------------------\n");

                var selection = Console.ReadLine();

                switch (selection.Trim().ToLower())
                {
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "a":
                        while (!difficultySelected)
                        {
                            ChooseDifficulty();
                        }
                        GameEngine.Addition("Addition selected", diff);
                        difficultySelected = false;
                        break;
                    case "s":
                        while (!difficultySelected)
                        {
                            ChooseDifficulty();
                        }
                        GameEngine.Subtraction("Subtraction selected", diff);
                        difficultySelected = false;
                        break;
                    case "m":
                        while (!difficultySelected)
                        {
                            ChooseDifficulty();
                        }
                        GameEngine.Multiplication("Multiplication selected", diff);
                        difficultySelected = false;
                        break;
                    case "d":
                        while (!difficultySelected)
                        {
                            ChooseDifficulty();
                        }
                        GameEngine.Division("Division selected", diff);
                        difficultySelected = false;
                        break;
                    case "r":
                        while (!difficultySelected)
                        {
                            ChooseDifficulty();
                        }
                        game.RandomGame("Random selected", diff);
                        difficultySelected = false;
                        break;
                    case "q":
                        Console.WriteLine("Goodbye");
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Please enter an appropriate response\n");
                        break;
                }
            }
        }

        internal void ChooseDifficulty()
        {
            Console.WriteLine($@"Please choose a difficulty level:
E- Easy
M- Medium
H-Hard");
            var difficulty = Console.ReadLine();
            //var diff = DifficultyLevel.Easy;

            switch (difficulty.Trim().ToLower())
            {
                case "e":
                    difficultySelected = true;
                    diff = DifficultyLevel.Easy;
                    break;
                case "m":
                    difficultySelected = true;
                    diff = DifficultyLevel.Medium;
                    break;
                case "h":
                    difficultySelected = true;
                    diff = DifficultyLevel.Hard;
                    break;
                default:
                    Console.WriteLine("Please choose e for easy, m for medium, or h for hard");
                    break;
            }
        }
    }
}


