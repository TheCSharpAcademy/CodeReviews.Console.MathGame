using MathGame.anplv.Models;
using System;
using System.Collections.Generic;

namespace MathGame.anplv
{
    internal class Helpers
    {
        internal static List<Game> games = new List<Game>();
        internal static readonly List<string> levels = new List<string>{ "Easy","Medium","Hard" };
        internal static void PrintGames()
        {
            Console.Clear();
            Console.WriteLine("Games history:");
            Console.WriteLine("--------------------------------");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score} pts. Game time - {game.Time}");
            }
            Console.WriteLine("--------------------------------\n");
            Console.WriteLine("Press any key to return to Main Menu");
            Console.ReadLine();
        }


        internal static void AddToHistory(int gameScore, GameType gameType, string gameTime)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType,
                Time = gameTime

            });
        }

        internal static string? ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your answer needs to be an integer. Try again.");
                result = Console.ReadLine();
            }
            return result;
        }

        internal static int ValidateLevel(int level)
        {
            var result = level;
            while (result < 1 || result > 3)
            {
                Console.WriteLine("Your answer needs to be an integer from 1 to 3. Try again.");
                result = int.Parse(Console.ReadLine());
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

        internal static void PrintLevels()
        {
            Console.Clear();
            Console.WriteLine(@$"Select game level
                                  1 - {levels[0]}
                                  2 - {levels[1]}
                                  3 - {levels[2]}");
        }

        internal static int GetLevel()
        {
            Console.Clear();
            PrintLevels();
            var level = int.Parse(Console.ReadLine());
            return level;

        }

        internal static int[] GetRandomNumbers()
        {
            var random = new Random();
            var listNumbers = new int[] { random.Next(10, 99), random.Next(1, 10) };
            for (int i = listNumbers.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);

                var tmp = listNumbers[j];
                listNumbers[j] = listNumbers[i];
                listNumbers[i] = tmp;
            }
            return listNumbers;
        }

        internal static int[] GetNumbers(string gameOption, int level)
        {
            var result = new int[2];
            var random = new Random();
            int firstNumber = 0;
            int secondNumber = 0;


            if (gameOption == "Division")
            {
                do
                {
                    switch (level)
                    {
                        case 1:
                            firstNumber = random.Next(1, 10);
                            secondNumber = random.Next(1, 10);
                            break;
                        case 2:
                            var listNumbers = GetRandomNumbers();
                            firstNumber = listNumbers[0];
                            secondNumber = listNumbers[1];
                            break;
                        case 3:
                            firstNumber = random.Next(1, 99);
                            secondNumber = random.Next(1, 99);
                            break;
                    }
                } while (firstNumber % secondNumber != 0);
            } else
            {
                switch (level)
                {
                    case 1:
                        firstNumber = random.Next(1, 10);
                        secondNumber = random.Next(1, 10);
                        break;
                    case 2:
                        var listNumbers = GetRandomNumbers();
                        firstNumber = listNumbers[0];
                        secondNumber = listNumbers[1];
                        break;
                    case 3:
                        firstNumber = random.Next(1, 99);
                        secondNumber = random.Next(1, 99);
                        break;
                }
            }

            result[0] = firstNumber;
            result[1] = secondNumber;
            return result;
        }

        internal static DateTime GetDate()
        {
            var dateTime = DateTime.UtcNow;
            Console.WriteLine(dateTime.ToString());
            return dateTime;
        }

         internal static string GetDateDifference(DateTime startDate)
        {
            var dateTime = DateTime.UtcNow;
            var dateDifference = $"{dateTime.Subtract(startDate).ToString(@"mm")} minutes {dateTime.Subtract(startDate).ToString(@"ss")} seconds";
            return dateDifference;
        }

        internal static string GetAmountQuestions()
        {
            Console.Clear();
            Console.WriteLine("Enter the number of questions you would like to answer");
            var amount = Console.ReadLine();
            return amount;
        }

       


    }

}


