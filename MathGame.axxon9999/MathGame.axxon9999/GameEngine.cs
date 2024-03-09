using MathGame.axxon9999.Models;
using System.Diagnostics;

namespace MathGame.axxon9999
{
    internal class GameEngine
    {
        internal void PlayTheGame(string mainInputMenu, int questionsInput, int[] level)
        {
            int gameScore = 0;
            GameType gameType = GameType.Initiation;

            Stopwatch stopWatch = new();
            stopWatch.Start();

            for (int i = 0; i < questionsInput; i++)
            {
                Console.Clear();
                Console.WriteLine("Question " + (i + 1));
                Console.WriteLine();
                int[] nums = Helpers.SelectTwoRandomNumbers(level[1]);

                if (mainInputMenu == "A")
                {
                    gameScore = Add(nums, gameScore);
                    gameType = GameType.Addition;
                }
                else if (mainInputMenu == "S")
                {
                    gameScore = Subtract(nums, gameScore);
                    gameType = GameType.Subtraction;
                }
                else if (mainInputMenu == "D")
                {
                    gameScore = Divise(nums, gameScore, level);
                    gameType = GameType.Division;
                }
                else if (mainInputMenu == "M")
                {
                    gameScore = Multiply(nums, gameScore);
                    gameType = GameType.Multiplication;
                }
                else if (mainInputMenu == "R")
                {
                    string[] option = { "A", "S", "M", "D" };
                    Random index = new();
                    int indexOps = index.Next(0, 4);
                    gameType = GameType.Random;

                    String operationSelection = option[indexOps];

                    if (operationSelection == "A")
                    {
                        gameScore = Add(nums, gameScore);
                    }
                    else if (operationSelection == "S")
                    {
                        gameScore = Subtract(nums, gameScore);
                    }
                    else if (operationSelection == "M")
                    {
                        gameScore = Multiply(nums, gameScore);
                    }
                    else if (operationSelection == "D")
                    {
                        gameScore = Divise(nums, gameScore, level);
                    }
                }
            }

            stopWatch.Stop();
            string totalTime = Convert.ToInt32(stopWatch.Elapsed.TotalSeconds).ToString();

            Helpers.PrintFinalScore(gameType, level[0], questionsInput, gameScore, totalTime);

            Helpers.AddToDatabase(gameType, level[0], questionsInput, gameScore, totalTime);

            Console.WriteLine();
            Console.WriteLine($"Press any key to continue...");
            Console.ReadKey();
        }

        internal static int Add(int[] nums, int gameScore)
        {
            int calcAnswer = nums[0] + nums[1];

            Console.Write(nums[0] + " + " + nums[1] + " =  ? ");

            string? inputAnswerStr = Console.ReadLine() ?? " ";

            inputAnswerStr = Helpers.ValidateResult(inputAnswerStr);

            int inputAnswer = Convert.ToInt32(inputAnswerStr);

            gameScore = Helpers.TestAnswer(inputAnswer, calcAnswer, gameScore);

            return gameScore;
        }

        internal static int Subtract(int[] nums, int gameScore)
        {
            int calcAnswer = nums[0] - nums[1];

            Console.Write(nums[0] + " - " + nums[1] + " =  ? ");

            string? inputAnswerStr = Console.ReadLine() ?? " ";

            inputAnswerStr = Helpers.ValidateResult(inputAnswerStr);

            int inputAnswer = Convert.ToInt32(inputAnswerStr);

            gameScore = Helpers.TestAnswer(inputAnswer, calcAnswer, gameScore);

            return gameScore;
        }

        internal static int Multiply(int[] nums, int gameScore)
        {
            int calcAnswer = nums[0] * nums[1];

            Console.Write(nums[0] + " X " + nums[1] + " =  ? ");

            string? inputAnswerStr = Console.ReadLine() ?? " ";

            inputAnswerStr = Helpers.ValidateResult(inputAnswerStr);

            int inputAnswer = Convert.ToInt32(inputAnswerStr);

            gameScore = Helpers.TestAnswer(inputAnswer, calcAnswer, gameScore);

            return gameScore;
        }

        internal static int Divise(int[] nums, int gameScore, int[] level)
        {
            while (nums[0] % nums[1] != 0)
            {
                nums = Helpers.SelectTwoRandomNumbers(level[1]);
                if (nums[1] == 0)
                {
                    nums[1] = 1;
                }
            }

            int calcAnswer = nums[0] / nums[1];

            Console.Write(nums[0] + " / " + nums[1] + " =  ? ");

            string? inputAnswerStr = Console.ReadLine() ?? " ";

            inputAnswerStr = Helpers.ValidateResult(inputAnswerStr);

            int inputAnswer = Convert.ToInt32(inputAnswerStr);

            gameScore = Helpers.TestAnswer(inputAnswer, calcAnswer, gameScore);

            return gameScore;
        }
    }
}
