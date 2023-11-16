using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace MathGame
{
    internal class Helpers
    {
        internal static int addProbLimit = 25 + 1;
        internal static int subProbLimit = 25;
        internal static int multProbLimit = 10 + 1;
        internal static int divProbLimit = 7 + 1;
        internal static string difficultyString = "Normal";
        internal static int totalRounds = 10;
        internal static int gameType = 0;
        internal static string gameTypeString = "";

        static List<string> scores = new List<string>();

        internal static string SelectDifficulty()
        {
            do
            {
                Console.Clear();
                Console.WriteLine(@"Choose game difficulty:
            E: Easy
            N: Normal
            H: Hard
            Q: Quit to Main Menu
        ");

                Console.Write("\nEnter selection: ");
                string difficultySelection = Console.ReadLine().ToUpper().Trim();

                switch (difficultySelection)
                {
                    case "E":
                        difficultyString = "Easy";
                        addProbLimit = 10 + 1;
                        subProbLimit = 10;
                        multProbLimit = 5 + 1;
                        divProbLimit = 5 + 1;
                        break;
                    case "N":
                        difficultyString = "Normal";
                        addProbLimit = 25+ 1;
                        subProbLimit = 25;
                        multProbLimit = 10 + 1;
                        divProbLimit = 7 + 1;
                        break;
                    case "H":
                        difficultyString = "Hard";
                        addProbLimit = 50 + 1;
                        subProbLimit = 50;
                        multProbLimit = 15 + 1;
                        divProbLimit = 10 + 1;
                        break;
                    case "Q":
                        break;
                    default:
                        difficultyString = "";
                        Console.Write("Invalid Input. Please enter an option from the menu.");
                        WaitToContinue("Press any key to try again...");
                        break;
                }
            } while (difficultyString == "");

            Console.WriteLine($"Set difficulty to {difficultyString}!");
            WaitToContinue("Press any key to return to the main menu...");

            return difficultyString;
        }
 
        internal static int SelectRounds()
        {
            bool validRoundNumber = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Math Game Options Menu\n");
                Console.WriteLine(@"Select the number of rounds for each game:
        Minimum: 1
        Maximum: 100
        Default: 10

Press Q to return to main menu");

                Console.Write("\nEnter selection: ");
                string roundsInputString = Console.ReadLine();

                if (roundsInputString.ToUpper().Trim() == "Q")
                    break;

                validRoundNumber = Int32.TryParse(roundsInputString, out totalRounds);

                if (!validRoundNumber)
                {
                    Console.Write("ERROR: Invalid Input. Please enter a number.");
                    WaitToContinue("Press any key to try again...");
                    continue;
                }
                else if (totalRounds > 100)
                {
                    validRoundNumber = false;
                    Console.Write("ERROR: Number too high. Please enter a number less than or equal to 100.");
                    WaitToContinue("Press any key to try again...");
                    continue;
                }
                else if (totalRounds < 1)
                {
                    validRoundNumber = false;
                    Console.Write("ERROR: Number too low. Please enter a number greater than or equal to 1.");
                    WaitToContinue("Press any key to try again...");
                    continue;
                }
                else
                {
                    Console.WriteLine($"Set total number of rounds to {totalRounds}!");
                    WaitToContinue("Press any key to return to the main menu...");
                }

            } while (!validRoundNumber);

            return totalRounds;
        }

        internal static void SaveScore(int score, string time)
        {
            scores.Add(String.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}", gameTypeString, difficultyString, score, totalRounds*10,time));
        }

        internal static void DisplayScores()
        {
            Console.Clear();

            if (scores.Count == 0)
                Console.WriteLine("You haven't played any games yet! Play a game to score points!");
            else
            {
                Console.WriteLine(String.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}", "Game Type", "Difficulty", "Your Score", "Max Score", "Time"));
                foreach (string record in scores)
                    Console.WriteLine(record);
            }
            WaitToContinue("Press any key to return to the main menu...");
        }

        internal static void DisplayStatusBar(int roundCounter, int score)
        {
            Console.WriteLine($"Game Type: {gameTypeString} \t Difficulty: {difficultyString} \t Round: {roundCounter}/{totalRounds} \t Score: {score}");
        }

        internal static void WaitToContinue(string message)
        {
            Console.WriteLine($"\n{message}");
            Console.ReadLine();
        }
    }
}