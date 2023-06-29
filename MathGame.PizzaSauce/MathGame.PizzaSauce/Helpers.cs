using MyFirstProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstProgram
{
    internal class Helpers
    {
        static List<Game> games = new();
        internal static void PrintGames()
        {
            Console.Clear();
            Console.WriteLine("Games History\n");
            if (games.Count != 0)
            {
                foreach (var game in games)
                {
                    Console.WriteLine($"{game.Date} - {game.Difficulty} {game.Type}: {game.Score} in {(game.Time / 60)}:{game.Time.ToString("00.##")}");
                }
            }
            else
            {
                Console.WriteLine("Play a game for the history to be displayed here");
            }
            Console.WriteLine("Press Enter to return to menu");
            Console.ReadLine();
        }
        internal static void AddToHistory(int gameScore, GameType gameType, string difficulty, int time)
        {
            //games.Add($"{DateTime.Now} - {gameType}: Score = {gameScore}");
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType,
                Difficulty = difficulty,
                Time = time
            });
        }
        internal static void DisplayScore(int score, int questions, int time)
        {
            Console.WriteLine($"You got {score}/{questions} correct in {(time / 60)}:{time.ToString("00.##")}");
            Console.ReadLine();
        }
        internal static int[] GetDivisionNumbers(string difficulty)
        {
            var random = new Random();

            int lowerValue = 0;
            int upperValue = 0;

            if (difficulty == "Easy")
            {
                lowerValue = 1;
                upperValue = 9;
            }
            else if (difficulty == "Medium")
            {
                lowerValue = 3;
                upperValue = 999;
            }
            else if (difficulty == "Hard")
            {
                lowerValue = 5;
                upperValue = 9999;
            }

            var firstNumber = random.Next(lowerValue, upperValue);
            var secondNumber = random.Next(lowerValue, upperValue);

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
        internal static string SelectDifficulty()
        {
            Console.Clear();
            Console.WriteLine(@"Select your difficulty
            1 - Easy
            2 - Medium
            3 - Hard");
            string difficulty = Console.ReadLine();
            while (string.IsNullOrEmpty(difficulty) || !(difficulty == "1" || difficulty == "2" || difficulty == "3"))
            {
                Console.Clear();
                Console.WriteLine(@"Select your difficulty
            1 - Easy
            2 - Medium
            3 - Hard
            Invalid Selection");
                difficulty = Console.ReadLine();
            }
            {
                if (difficulty == "1")
                {
                    difficulty = "Easy";
                }
                else if (difficulty == "2")
                {
                    difficulty = "Medium";
                }
                else if (difficulty == "3")
                {
                    difficulty = "Hard";
                }
                return difficulty;
            }
        }
        internal static int SelectQuestions()
        {
            Console.Clear();
            Console.WriteLine("Select how many questions you would like:");
            string answer = Console.ReadLine();
            while (string.IsNullOrEmpty(answer) || !Int32.TryParse(answer, out _) || Int32.Parse(answer) <= 0)
            {
                Console.Clear();
                Console.WriteLine("Please select an integer greater than 0");
                answer = Console.ReadLine();
            }
            int questionAmount = Int32.Parse(answer);
            return questionAmount;
        }
        internal static int GetTimeToComplete(DateTime startTime, DateTime endTime)
        {
            TimeSpan interval = endTime - startTime;
            int seconds = interval.Seconds;
            return seconds;
        }
    }
}
