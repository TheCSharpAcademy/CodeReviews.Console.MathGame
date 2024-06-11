﻿using MathGame.jakubecm.Models;

namespace MathGame.jakubecm
{
    internal class Helpers
    {
        internal static List<Game> games = new();
        internal static int[] GetDivisionNumbers()
        {
            var random = new Random();
            var result = new int[2];

            var firstNumber = random.Next(0, 99);
            var secondNumber = random.Next(0, 99);

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, 99);
                secondNumber = random.Next(1, 99);

            }

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }

        internal static void AddToHistory(int gameScore, GameType gameType)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType
            });
        }

        internal static string GetName()
        {
            Console.WriteLine("Please type your name");
            var name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be an empty string");
                name = Console.ReadLine();
            }
            return name!;
        }

        internal static void PrintGames()
        {
            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("---------------------");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score} pts");
            }
            Console.WriteLine("---------------------");
            Console.WriteLine("Press any key to return to the Main Menu");
            Console.ReadLine();
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

        internal static string GetGameOperator(GameType gameType)
        {
            switch (gameType)
            {
                case GameType.Addition:
                    return "+";
                case GameType.Multiplication:
                    return "*";
                case GameType.Division:
                    return "/";
                case GameType.Subtraction:
                    return "-";
                default:
                    throw new InvalidDataException("Invalid game type");
            }
        }

        internal static int GetOperationResult(string currentGameOperator, int num1, int num2)
        {
            switch (currentGameOperator)
            {
                case "+":
                    return num1+num2;
                case "*":
                    return num1*num2;
                case "-":
                    return num1-num2;
                case "/":
                    return num1 / num2;
                default:
                    throw new InvalidDataException("Invalid operator");
            }
        }
    }
}
