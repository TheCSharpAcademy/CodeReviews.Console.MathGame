using MyFirstProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstProgram
{
    internal class Helpers
    {
        internal static List<Game> games = new();
        
        internal static void GetGames()
        {
           // var gamesToPrint = games.Where(x => x.Type == GameType.Multiplication);
            Console.Clear();

            Console.WriteLine("Game history");
            Console.WriteLine("---------------------------------");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score}pts -game difficulty : {game.Difficulty} - time while playing in seconds : {game.secondsInGame}");
            }
            Console.WriteLine("---------------------------------\n");
            Console.WriteLine("Press any key to go back to the main menu");
            Console.ReadLine();
        }
        internal static GameDifficulty getDifficultyLevel()
        {
           GameDifficulty difficulty=GameDifficulty.Easy; //by default
            Console.WriteLine($@"What difficulty level do you want to play at: 

             E - Easy
             M - Medium
             H - Hard
");
            var answer=Console.ReadLine();
            if (answer.ToLower() != "e" && answer.ToLower() != "m" && answer.ToLower() != "h")
            {
                Console.WriteLine("Please type E for easy , M for Medium , H for hard");
                answer = Console.ReadLine();
            }
            if(answer.ToLower() == "e")
            {
                Console.WriteLine($"you choose {GameDifficulty.Easy} level");
                difficulty = GameDifficulty.Easy;
            }
            else if (answer.ToLower() == "m")
            {
                Console.WriteLine($"you choose {GameDifficulty.Medium} level");
                difficulty = GameDifficulty.Medium;
            }
            else if (answer.ToLower() == "h")
            {
                Console.WriteLine($"you choose {GameDifficulty.Hard} level");
                difficulty = GameDifficulty.Hard;
            }
            return difficulty;

        }

        internal static void AddToHistory(int gameScore, GameType gameType, GameDifficulty difficulty, double time)
        {
       
            games.Add(new Game { Date = DateTime.Now, Score = gameScore, Type = gameType, Difficulty = difficulty,secondsInGame=time});
        }

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
        internal static int numberOfQuestions()
        {
            Console.WriteLine("How many questions you want to answer while playing this game?");
            var numberOfQuestions = Console.ReadLine();
            while (string.IsNullOrEmpty(numberOfQuestions) || !Int32.TryParse(numberOfQuestions, out _))
            {
                Console.WriteLine("Your answer needs to be an integer. Try again.");
                numberOfQuestions = Console.ReadLine();
            }
            return int.Parse(numberOfQuestions);
        }
    }
}
