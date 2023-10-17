using System;

namespace MathGame
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Run();
        }
        private static void Run()
        {
            Console.WriteLine("Please enter your name.");
            var name = Console.ReadLine();
            var date = DateTime.Now;

            string input;
            Console.WriteLine($"Hello {name}, welcome to my Math Game!" +
                              "\nYou can enter 'Q' at any time to leave.");
            do
            {
                Console.WriteLine("What type of Math Game would you like?" +
                                  "\nA = Add " + " S = Subtract " +
                                  "\nM = Multiply " + " D = Divide " +
                                  "\nR = Random " + 
                                  "\n\nH = History " + " Q = Quit ");
                input = Console.ReadLine()?.ToUpper();

                GameSelection(input, name, date);
            } while (input != "Q");
        }
        private static void GameSelection(string input, string name, DateTime date)
        {
            int currentStreak;
            int difficulty;
            int questions;
            DateTime startTime;
            switch (input)
            {
                case "A":
                    difficulty = SelectDifficulty();
                    questions = SelectAmountOfQuestions();
                    currentStreak = 0;
                    startTime = DateTime.Now;
                    if (questions > 0)
                    {
                        for (int i = 0; i < questions; i++)
                        {
                            if (!Questions.AddQuestion(difficulty)) break;
                            currentStreak++;
                        }
                    }
                    else
                    {
                        while (Questions.AddQuestion(difficulty))
                        {
                            currentStreak++;
                        }
                    }
                    EndGame(name, date, startTime, currentStreak, difficulty);
                    break;
                case "S":
                    difficulty = SelectDifficulty();
                    questions = SelectAmountOfQuestions();
                    currentStreak = 0;
                    startTime = DateTime.Now;
                    if (questions > 0)
                    {
                        for (int i = 0; i < questions; i++)
                        {
                            if (!Questions.SubtractQuestion(difficulty)) break;
                            currentStreak++;
                        }
                    }
                    else
                    {
                        while (Questions.SubtractQuestion(difficulty))
                        {
                            currentStreak++;
                        }
                    }
                    EndGame(name, date, startTime, currentStreak, difficulty);
                    break;
                case "M":
                    difficulty = SelectDifficulty();
                    questions = SelectAmountOfQuestions();
                    currentStreak = 0;
                    startTime = DateTime.Now;
                    if (questions > 0)
                    {
                        for (int i = 0; i < questions; i++)
                        {
                            if (!Questions.MultiplyQuestion(difficulty)) break;
                            currentStreak++;
                        }
                    }
                    else
                    {
                        while (Questions.MultiplyQuestion(difficulty))
                        {
                            currentStreak++;
                        }
                    }
                    EndGame(name, date, startTime, currentStreak, difficulty);
                    break;
                case "D":
                    difficulty = SelectDifficulty();
                    questions = SelectAmountOfQuestions();
                    currentStreak = 0;
                    startTime = DateTime.Now;
                    if (questions > 0)
                    {
                        for (int i = 0; i < questions; i++)
                        {
                            if (!Questions.DivideQuestion(difficulty)) break;
                            currentStreak++;
                        }
                    }
                    else
                    {
                        while (Questions.DivideQuestion(difficulty))
                        {
                            currentStreak++;
                        }
                    }
                    EndGame(name, date, startTime, currentStreak, difficulty);
                    break;
                case "R":
                    difficulty = SelectDifficulty();
                    questions = SelectAmountOfQuestions();
                    currentStreak = 0;
                    startTime = DateTime.Now;
                    if (questions > 0)
                    {
                        for (int i = 0; i < questions; i++)
                        {
                            if (!Questions.RandomQuestion(difficulty)) break;
                            currentStreak++;
                        }
                    }
                    else
                    {
                        while (Questions.RandomQuestion(difficulty))
                        {
                            currentStreak++;
                        }
                    }
                    EndGame(name, date, startTime, currentStreak, difficulty);
                    break;
                case "H":
                    if (History.GetHistory().Count < 1)
                    {
                        Console.WriteLine("\nNo history found!\n");
                        break;
                    }
                    Console.WriteLine("\n");
                    foreach (var record in History.GetHistory())
                    {
                        Console.WriteLine(record);
                    }
                    Console.WriteLine("\n");
                    break;
                case "Q":
                    Environment.Exit(0);
                    break;
            }
        }
        private static string TimeElapsed(DateTime startTime)
        {
            DateTime endTime = DateTime.Now;
            TimeSpan timeElapsed = endTime - startTime;
            return timeElapsed.ToString("hh\\:mm\\:ss");
        }
        private static int SelectAmountOfQuestions()
        {
            while (true)
            {
                Console.WriteLine("Please select number of questions." +
                                  "\nLeave empty for infinite");
                var numberOfQuestions = Console.ReadLine();
                if (int.TryParse(numberOfQuestions, out int number))
                {
                    if (number > 0)
                    {
                        Console.WriteLine($"You entered {number}.");
                        return number;
                    }
                    Console.WriteLine($"You selected an infinite amount of questions.");
                    return 0;
                }
                else if (numberOfQuestions == String.Empty)
                {
                    Console.WriteLine($"You selected an infinite amount of questions.");
                    return 0;
                }
                else
                {
                    Console.WriteLine("Please enter a number.");
                }
            }
        }
        private static int SelectDifficulty()
        {
            while (true)
            {
                Console.WriteLine("Please select a difficulty:" +
                                  "\n1 = Easy" +
                                  "\n2 = Medium" +
                                  "\n3 = Hard");
                var difficulty = Console.ReadLine();
                switch (difficulty)
                {
                    case "1":
                        Console.WriteLine("You selected Easy.");
                        return 1;
                    case "2":
                        Console.WriteLine("You selected Medium.");
                        return 2;
                    case "3":
                        Console.WriteLine("You selected Hard.");
                        return 3;
                    default:
                        Console.WriteLine("Invalid answer.");
                        continue;
                }
            }
        }
        private static void EndGame(string name, DateTime date, DateTime startTime, int currentStreak, int difficulty)
        {
            var elapsed = TimeElapsed(startTime);
            string dif;
            switch (difficulty)
            {
                case 1:
                    dif = "Easy";
                    break;
                case 2:
                    dif = "Medium";
                    break;
                case 3:
                    dif = "Hard";
                    break;
                default:
                    dif = "Invalid";
                    break;
            }
            Console.WriteLine($"You made it to {currentStreak}. Time: {elapsed} !");
            History.SetHistory($"{date}, {name}, " +
                               $"Mode: Subtract, {currentStreak}, " +
                               $"Difficulty {dif}, " +
                               $"Time: {elapsed}");
        }
    }
}