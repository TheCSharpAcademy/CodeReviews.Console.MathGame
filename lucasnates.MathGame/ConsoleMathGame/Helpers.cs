using ConsoleMathGame.Models;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleMathGame
{
    internal class Helpers
    {
        internal static int diffRange1 = 0;
        internal static int diffRange2 = 0;
        internal static string diffLevel;

        internal static void ChooseDifficulty()
        {
            Console.WriteLine("Choose a difficulty:");
            Console.WriteLine("---------------------------------");
            Console.WriteLine(@"    E - Easy    
    M - Medium
    H - Hard");
            Console.WriteLine("---------------------------------");

            bool _isDivisionOn = Menu.isDivisionOn;
            bool _isMultiplicationOn = Menu.isMultiplicationOn;

            bool validMode = false;
            char selectedMode = '\0';

            while (!validMode)
            {
                selectedMode = Console.ReadLine()[0];
                if (selectedMode == 'e' || selectedMode == 'm' || selectedMode == 'h')
                {
                    validMode = true;
                }
                else
                {
                    Console.WriteLine("Enter a valid mode.");
                }
            }

            switch (selectedMode)
            {
                case 'e':
                    diffRange1 = 1;
                    diffRange2 = 9;
                    if (_isDivisionOn == true)
                    {
                        diffRange1 = 1;
                        diffRange2 = 99;
                    }
                    else if (_isMultiplicationOn == true)
                    {
                        diffRange1 = 1;
                        diffRange2 = 9;
                    }
                    diffLevel = "Easy";
                    Console.Clear();
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("Easy mode selected.");
                    break;
                case 'm':
                    diffRange1 = 1;
                    diffRange2 = 99;
                    diffLevel = "Medium";
                    if (_isDivisionOn == true)
                    {
                        diffRange1 = 1;
                        diffRange2 = 200;
                    }
                    else if (_isMultiplicationOn == true)
                    {
                        diffRange1 = 2;
                        diffRange2 = 50;
                    }
                    Console.Clear();
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("Medium mode selected.");
                    break;
                case 'h':
                    diffRange1 = 27;
                    diffRange2 = 299;
                    diffLevel = "Hard";
                    if (_isDivisionOn == true)
                    {
                        diffRange1 = 3;
                        diffRange2 = 499;
                    }
                    else if (_isMultiplicationOn == true)
                    {
                        diffRange1 = 2;
                        diffRange2 = 199;
                    }
                    Console.Clear();
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("Hard mode selected.");
                    break;
            }
        }

        internal static List<Game> games = new List<Game>
        {
        };

        internal static void GetGames()
        {
            var gamesToPrint = games.OrderByDescending(x => x.Score);

            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Games history. Sorted by correct answers.");
            foreach (var game in gamesToPrint)
            {
                Console.WriteLine($"{game.Date} - [{game.Mode}] {game.Type}: {game.Score}/{game.GamesCount} pts | {game.Time}");
            }
            Console.WriteLine("---------------------------------");
        }

        internal static void AddToHistory(int gameScore, GameType gameType, GameMode gameMode, TimeSpan elapsedTime, int gameCount)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType,
                Mode = gameMode,
                Time = elapsedTime,
                GamesCount = gameCount
            });
        }

        internal static int[] GetDivisionNumbers()
        {
            var random = new Random();
            var firstNumber = random.Next(diffRange1, diffRange2);
            var secondNumber = random.Next(diffRange1, diffRange2);

            var result = new int[2];

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(diffRange1, diffRange2);
                secondNumber = random.Next(diffRange1, diffRange2);
            }
            result[0] = firstNumber;
            result[1] = secondNumber;
            return result;
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

        internal static string GetName()
        {
            Console.WriteLine("What's your name?");
            var userName = Console.ReadLine();

            while(string.IsNullOrEmpty(userName))
            {
                Console.WriteLine("Please enter a valid name!");
                userName = Console.ReadLine();
            }
            return userName;
        }

        internal static int ChooseGames()
        {
            int gameCount = 0;
            bool isValid = false;

            while (!isValid)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Type how many questions you want to answer between 1 and 10");
                string input = Console.ReadLine();

                if (int.TryParse(input, out gameCount))
                {
                    if (gameCount >= 1 && gameCount <= 10)
                    {
                        isValid = true;
                        Console.Clear();
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine($"{gameCount} questions chosen. Good luck!");
                        Console.WriteLine("---------------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 10.");
                }
            }
            return gameCount;
        }
    }
}
