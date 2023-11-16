using System;
using System.Diagnostics;
using System.Linq;

namespace MathGame
{
    internal class GameEngine
    {
        Helpers scoreSaver = new Helpers();
        Stopwatch timer = new Stopwatch();
        string mathOperator = "";
        string timeString = "";
        internal int[] GetProblem()
        {
            Random random = new Random();
            int numberOne = 0;
            int numberTwo = 0;
            int numberAnswer = 0;

            if (Helpers.gameTypeString == "Random")
                Helpers.gameType = random.Next(1, 5);

            switch (Helpers.gameType)
            {
                case 1:
                    numberOne = random.Next(0, Helpers.addProbLimit);
                    numberTwo = random.Next(0, Helpers.addProbLimit);
                    numberAnswer = numberOne + numberTwo;
                    mathOperator = "+";
                    break;
                case 2:
                    numberTwo = random.Next(0, Helpers.subProbLimit);
                    numberOne = random.Next(numberTwo, Helpers.subProbLimit +1);
                    numberAnswer = numberOne - numberTwo;
                    mathOperator = "-";
                    break;
                case 3:
                    numberOne = random.Next(0, Helpers.multProbLimit);
                    numberTwo = random.Next(0, Helpers.multProbLimit);
                    numberAnswer = numberOne * numberTwo;
                    mathOperator = "x";
                    break;
                case 4:
                    numberTwo = random.Next(1, Helpers.divProbLimit);
                    numberAnswer = random.Next(1, Helpers.divProbLimit);
                    numberOne = numberTwo * numberAnswer;
                    mathOperator = "/";
                    break;
            }

            int[] problem = { numberOne, numberTwo, numberAnswer };
            return problem;
        }

        internal void PlayGame()
        {
            timer.Start();
            int round = 1;
            int score = 0;

            int[] problem = new int[3];

            while (round <= Helpers.totalRounds)
            {
                problem = GetProblem();

                Console.Clear();
                Helpers.DisplayStatusBar(round, score);

                Console.WriteLine("\nEnter the solution to the equation below or type \"Q\" to return to the main menu:");
                Console.Write($"\n\t{problem[0]} {mathOperator} {problem[1]} = ");

                string userAnswerString = Console.ReadLine();
                bool isAnswerNumber = Int32.TryParse(userAnswerString, out int userAnswer);

                if (isAnswerNumber)
                {
                    if (userAnswer == problem[2])
                    {
                        score += 10;
                        Console.Write("\nCorrect! Score increased by 10 point!");
                        Helpers.WaitToContinue("Press any key to continue...");

                    }
                    else
                    {
                        if (score < 5)
                            score = 0;
                        else
                            score -= 5;
                        Console.Write($"\nIncorrect answer. Score decreased by 5 points...");
                        Helpers.WaitToContinue("Press any key to continue...");
                    }
                }
                else if (userAnswerString.ToUpper().Trim() == "Q")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nInvalid entry. Please enter a number.");
                    Helpers.WaitToContinue("Press any key to continue...");
                }

                round++;
            }

            timeString = GetTime();
            Helpers.SaveScore(score, timeString);
        }

        internal string GetTime()
        {
            timer.Stop();
            TimeSpan ts = timer.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            timer.Reset();

            return elapsedTime;
        }

    }
}