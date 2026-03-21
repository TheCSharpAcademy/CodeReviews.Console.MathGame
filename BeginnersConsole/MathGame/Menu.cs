using MathGame.Models;
using Microsoft.Extensions.Configuration;

namespace MathGame
{
    internal class Menu
    {
        private GameEngine engine;

        public Menu(IConfiguration configuration)
        {
            engine = new GameEngine(configuration);
        }

        internal void ShowMenu(string name, DateTime date)
        {
            Console.Clear();

            Console.WriteLine($"Hello {name}. It's {date}. This is your math's game. ");
            Console.ReadLine();
            Console.WriteLine("\n");
            bool isGameOn = true;
            do
            {
                string gameSelected;
                do
                {
                    Console.Clear();
                    Console.WriteLine($@"What game would you like to play today? Choose from the options below:
                            V - View Previous Games
                            A - Addition
                            S - Subtraction
                            M - Multiplication
                            D - Division
                            R - Random
                            Q - Quit the program");
                    Console.WriteLine("----------------");
                    gameSelected = Console.ReadLine();
                } while (!Helpers.IsValidInput(gameSelected, "v", "a", "s", "m", "d", "r", "q"));

                string difficulty;
                DifficultyLevel dLevel = DifficultyLevel.Easy;
                if (gameSelected != "v" && gameSelected != "q")
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine($@"
                            E - Easy
                            M - Medium
                            H - Hard");
                        difficulty = Console.ReadLine();
                        switch (difficulty.ToLower())
                        {
                            case "e":
                                dLevel = DifficultyLevel.Easy;
                                break;

                            case "m":
                                dLevel = DifficultyLevel.Medium;
                                break;

                            case "h":
                                dLevel = DifficultyLevel.Hard;
                                break;

                            default:
                                dLevel = DifficultyLevel.Easy;
                                break;
                        }
                    } while (!Helpers.IsValidInput(difficulty, "e", "m", "h"));
                }

                switch (gameSelected.Trim().ToLower())
                {
                    case "v":
                        Helpers.PrintGames();
                        break;

                    case "a":
                        engine.PlayGame(GameType.Addition, "Addition game", dLevel);
                        break;

                    case "s":
                        engine.PlayGame(GameType.Subtraction, "Subtraction game", dLevel);
                        break;

                    case "m":
                        engine.PlayGame(GameType.Multiplication, "Multiplication game", dLevel);
                        break;

                    case "d":
                        engine.PlayGame(GameType.Division, "Division game", dLevel);
                        break;

                    case "r":
                        engine.PlayGame(GameType.Random, "Random Game", dLevel);
                        break;

                    case "q":
                        Console.WriteLine("By");
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