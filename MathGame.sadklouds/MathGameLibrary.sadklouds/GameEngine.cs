using MathGameLibrary.sadklouds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGameLibrary.sadklouds
{
    public class GameEngine
    {
        public static List<GameSessionModel> GameHistory = new List<GameSessionModel>();

        public static int[] GetNumbers()
        {
            Random random = new Random();
            int[] output;
            var firstNumber = random.Next(1, 12);
            var secondNumber = random.Next(1, 12);
            output = new int[] { firstNumber, secondNumber };
            return output;
        }

        public static int[] GetDivisionNumbers()
        {
            Random random = new Random();
            int[] output;
            int firstNumber;
            int secondNumber;
            do
            {
                firstNumber = random.Next(1, 99);
                secondNumber = random.Next(1, 99);

            } while (firstNumber % secondNumber != 0);

            output = new int[] { firstNumber, secondNumber };
            return output;
        }

        public static void AddToGameHistory(int score, string gameType, DateTime startTime)
        {
            TimeSpan timeTaken = startTime - DateTime.Now;
            GameSessionModel gameSession = new()
            {
                Score = score,
                GameType = gameType,
                SessionDate = DateTime.Now,
                TimeTaken = timeTaken
            };

            GameHistory.Add(gameSession);
        }


        public static bool AnwserValidator(int firstNumber, int secondNumber, int userAnwser, char operation)
        {
            bool output = false;
            int anwser = 0;
            if (operation == '+') anwser = firstNumber + secondNumber;
            else if (operation == '-') anwser = firstNumber - secondNumber;
            else if (operation == '*') anwser = firstNumber * secondNumber;
            else if (operation == '/') anwser = firstNumber / secondNumber;

            if (userAnwser == anwser)
            {
                output = true;
            }
            return output;
        }
    }
}
