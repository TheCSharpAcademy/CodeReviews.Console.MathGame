﻿using MathGame.lordWalnuts.Models;

namespace MathGame.lordWalnuts
{
    internal class Helpers
    {

        internal static List<Game> games = new();

        internal static int[] GetDivisionNumbers()
        {
            var random = new Random();
            var firstNumber = random.Next(1, 99);
            var secondNumber = random.Next(1, 99);

            var result = new int[2];

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, 99);
                secondNumber = random.Next(1, 99);
            }

            result[0] = firstNumber;
            result[1] = secondNumber;
            return result;
        }

        internal static void AddToHistory(int gameScore, GameType gameType, Difficulty difficulty, string duration)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType,
                Difficulty = difficulty,
                Duration = duration
            });
        }

        internal static void PrintGames()
        {

            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("---------------------------");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type} - {game.Difficulty} - {game.Duration}: {game.Score}pts");
            }
            Console.WriteLine("---------------------------\n");
            Console.WriteLine("Press any key to return to Main Menu");
            Console.ReadLine();
        }


        internal static int NumberOfQuestions()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Enter number of questions");
            var input = Console.ReadLine();
            input = ValidateResult(input);
            return int.Parse(input);

        }
        internal static void RandomGame(GameEngine gameEngine)
        {
            var random = new Random();
            var num = random.Next(0, 4);
            switch (num)
            {
                case 0: gameEngine.DivisionGame("Division game"); break;
                case 1: gameEngine.AdditionGame("Addition game"); break;
                case 2: gameEngine.SubtractionGame("Subtraction game"); break;
                case 3: gameEngine.MultiplicationGame("Multiplication game"); break;
            }
        }

        internal static string ValidateResult(string? result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your answer needs to be an integer. Try again.");
                result = Console.ReadLine();
            }

            return result;
        }

        internal static string GetName()
        {
            Console.WriteLine("Please type your name");
            var name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty");
                name = Console.ReadLine();
            }

            return name;
        }

        internal static Difficulty ChooseDifficulty()
        {
            var difficulty = new Difficulty();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Choose your difficulty");
            Console.WriteLine("Easy - Press 1");
            Console.WriteLine("Medium - Press 2");
            Console.WriteLine("Hard - Press 3");


            var input = Console.ReadLine();
            input = ValidateResult(input);
            switch (int.Parse(input))
            {
                case 1:
                    difficulty = Difficulty.Easy; break;
                case 2:
                    difficulty = Difficulty.Medium; break;
                case 3:
                    difficulty = Difficulty.Hard; break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;

            }

            return difficulty;
        }
    }
}

