using CalculatingGame.Models;
using static CalculatingGame.Models.GameDetailsModel;

namespace CalculatingGame.Helpers
{
    internal static class GameHelper
    {
        static string? Name { get; set; }
        static List<GameDetailsModel> games = new();

        internal static void SetPlayerName(string? name)
        {
            Name = name;
        }

        internal static void QuitGameMessage()
        {
            Console.WriteLine("Bye");
        }

        internal static void GameOverMessageWon(int score)
        {
            Console.WriteLine("Correct answer. \r\nThis Game is Over. " + $"Final Score is {score}. Press any key for the menu");
            Console.ReadLine();
        }

        internal static void GameOverMessageLost(int score)
        {
            Console.WriteLine("Wrong answer. \r\nThis Game is Over. " + $"Final Score is {score}. Press any key for the menu");
            Console.ReadLine();
        }

        internal static void NotifyPlayerLost(int score)
        {
            Console.WriteLine($"Wrong answer, your score is {score}. " +
                $"Type any key for next question.");
            Console.ReadLine();
        }

        internal static void NotifyPlayerWon(int score)
        {
            Console.WriteLine($"Correct answer, your score is {score}. " +
                $"Type any key for next question.");
            Console.ReadLine();
        }

        internal static void ShowCalculation(int a, int b, string type)
        {
            Console.Clear();
            switch (type)
            {
                case "Addition":
                    Console.WriteLine($"{type}: {a} + {b}");
                    break;
                case "Subtraction":
                    Console.WriteLine($"{type}: {a} - {b}");
                    break;
                case "Multiplication":
                    Console.WriteLine($"{type}: {a} * {b}");
                    break;
                case "Division":
                    Console.WriteLine($"{type}: {a} / {b}");
                    break;
            }   
        }

        internal static int GetAnswer()
        {
            Console.WriteLine("type your answer");
            var answer = Console.ReadLine();
            while(string.IsNullOrEmpty(answer)||!Int32.TryParse(answer, out _))
            {
                Console.WriteLine("Incorrect Input. The answer must be ineger. /r/nTry again");
            }
            return int.Parse(answer);
        }

        internal static void AddToHistory(int score, GameType Type)
        {
            games.Add(new GameDetailsModel
            {
                Name = Name,
                Date = DateTime.Now,
                Type = Type,
                Score = score
            });
        }

        internal static void ShowHistory()
        {
            if (games.Count > 0)
            {
                foreach (var game in games)
                {
                    Console.WriteLine($"Name: {game.Name}, Date: {game.Date}, Type: {game.Type}, Score: {game.Score}");

                }
                Console.WriteLine("Press any key to return to menu");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("No history found. Press any key to return to menu;");
                Console.ReadLine();
            }
        }
    }
}
