using System;

namespace MathGame
{
    internal class Helpers
    {
        internal static List<string> gamesHistory = new List<string>();
        internal static string GetName()
        {
            Console.WriteLine("Please type your name");
            string name = Console.ReadLine();
            return name;
        }

        internal static string RandomOperator()
        {
            string mathOperator = "";

            Random random = new Random();
            int randomNumber = random.Next(1, 5);

            switch (randomNumber)
            {
                case 1:
                    mathOperator = "+";
                    break;
                case 2:
                    mathOperator = "-";
                    break;
                case 3:
                    mathOperator = "x";
                    break;
                case 4:
                    mathOperator = "/";
                    break;
            }

            return mathOperator;

        }

        internal static int ParseToInt(string input)
        {
            bool isValid = false;
            int number = 0;

            while (!isValid)
            {
                if (int.TryParse(input, out number))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Enter a valid number! try agin..");
                    input = Console.ReadLine();
                }
            }
            return number;
        }

        internal static void AddToHistory(int correct, int wrong, string gameType, string difficulty, string time)
        {
            gamesHistory.Add($"{DateTime.Now} - {gameType} - {difficulty} - Correct: {correct} Wrong: {wrong} Time: {time}");
        }

        internal static string Difficulty()
        {
            bool isValid = false;
            string difficulty = "";

            Console.WriteLine(@"How difficult you want the game to be? 
    E - Easy, numbers 1 to 25.
    M - Medium, numbers 1 to 50.
    D - Difficult, numbers 1 to 100.");

            string userChoice = Console.ReadLine();

            while (!isValid)
            {
                switch (userChoice.Trim().ToUpper())
                {
                    case "E":
                        difficulty = "Easy";
                        isValid = true;
                        break;
                    case "M":
                        difficulty = "Medium";
                        isValid = true;
                        break;
                    case "D":
                        difficulty = "Difficult";
                        isValid = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input, try again..\n");
                        userChoice = Console.ReadLine();
                        break;
                }
            }

            return difficulty;
        }

        internal static void GameSummery(int correct, int wrong, string time)
        {
            Console.WriteLine("Game over.. your score is:");
            Console.Write("Correct: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(correct);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Wrong: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(wrong);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Time: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(time);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.WriteLine("Press any key to go back to the main menu.");
            Console.ReadLine();
        }

        internal static void CorrectAnswer(int correct)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Correct!\n");
            Console.ForegroundColor = ConsoleColor.White;
            correct++;
        }

        internal static void WrongAnswer(int wrong)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Wrong!\n");
            Console.ForegroundColor = ConsoleColor.White;
            wrong++;
        }
    }
}
