using CalculatingGame.Helpers;
using static CalculatingGame.Models.GameDetailsModel;

namespace CalculatingGame
{
    internal class GameLogic
    {
        internal void Add()
        {
            var random = new Random();
            int score = 0;
            int a;
            int b;
            int answer;

            for (var i = 0; i < 3; i++)
            {
                a = random.Next(0, 10);
                b = random.Next(0, 10);
                int result = a + b;
                GameHelper.ShowCalculation(a, b, GameType.Addition.ToString());
                answer = GameHelper.GetAnswer();
              
                if (i == 2 && (answer == result))
                {
                    score++;
                    GameHelper.GameOverMessageWon(score);
                }
                else if (i == 2 && (answer != result))
                {
                    score++;
                    GameHelper.GameOverMessageLost(score);
                }
                else if (answer == result)
                {
                    score++;
                    GameHelper.NotifyPlayerWon(score);
                }

                else
                {
                    GameHelper.NotifyPlayerLost(score);
                }
            }
            GameHelper.AddToHistory(score, GameType.Addition);
        }

        internal void Subtract()
        {
            var random = new Random();
            int score = 0;
            int a;
            int b;
            int answer;

            for (var i = 0; i < 3; i++)
            {
                a = random.Next(0, 10);
                b = random.Next(0, 10);
                int result = a - b;
                GameHelper.ShowCalculation(a, b, GameType.Subtraction.ToString());
                answer = GameHelper.GetAnswer();
                if (i == 2 && (answer == result))
                {
                    score++;
                    GameHelper.GameOverMessageWon(score);
                }
                else if (i == 2 && (answer != result))
                {
                    GameHelper.GameOverMessageLost(score);
                }
                else if (answer == result)
                {
                    score++;
                    GameHelper.NotifyPlayerWon(score);
                }
                else
                {
                    GameHelper.NotifyPlayerLost(score);
                }
            }
            GameHelper.AddToHistory(score, GameType.Subtraction);
        }

        internal void Multiply()
        {
            var random = new Random();
            int score = 0;
            int a;
            int b;
            int answer;

            for (var i = 0; i < 3; i++)
            {
                a = random.Next(0, 10);
                b = random.Next(0, 10);
                int result = a * b;
                GameHelper.ShowCalculation(a, b, GameType.Multiplication.ToString());
                answer = GameHelper.GetAnswer();
                if (i == 2 && (answer == result))
                {
                    score++;
                    GameHelper.GameOverMessageWon(score);
                }
                else if (i == 2 && (answer != result))
                {
                    GameHelper.GameOverMessageLost(score);
                }
                else if (answer == result)
                {
                    score++;
                    GameHelper.NotifyPlayerWon(score);
                }
                else
                {
                    GameHelper.NotifyPlayerLost(score);
                }
            }
            GameHelper.AddToHistory(score, GameType.Multiplication);
        }
        internal void Divide()
        {
            var random = new Random();
            int score = 0;
            int a;
            int b;
            int answer;

            for (var i = 0; i < 3; i++)
            {
                a = random.Next(0, 100);
                b = random.Next(0, 100);
                while (a%b != 0)
                {
                    a = random.Next(0, 100);
                    b = random.Next(0, 100);
                }

                int result = a / b;
                GameHelper.ShowCalculation(a, b, GameType.Division.ToString());
                answer = GameHelper.GetAnswer();
                if (i == 2 && (answer == result))
                {
                    score++;
                    GameHelper.GameOverMessageWon(score);
                }
                else if(i == 2 && (answer != result))
                {
                    GameHelper.GameOverMessageLost(score);
                }
                else if (answer == result)
                {
                    score++;
                    GameHelper.NotifyPlayerWon(score);
                }
                else
                {
                    GameHelper.NotifyPlayerLost(score);
                }
            }
            GameHelper.AddToHistory(score, GameType.Division);
        }
    }
}
