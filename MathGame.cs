using System.Diagnostics;

namespace MathGame
{
    public class Game
    {
        enum Level
        {
            Easy,
            Medium,
            Hard
        }
        private Level gameDifficulty = Level.Medium;
        private List<string> gameHistory = new();
        private int score;
        private int questionsAnswered;
        private int questionQty = 5;
        private readonly Stopwatch timer = new();
        private int[]? numbers;

        public bool Menu()
        {
            ConsoleKeyInfo selection;
            Console.Clear();
            Console.WriteLine($" score|{score}/{questionsAnswered}".ToUpper() + new string('\t', 1) + $"Time|{timer.Elapsed.Minutes}:{timer.Elapsed.Seconds} (MM:SS)".ToUpper() + new string('\t', 1) + $"DIFF|{gameDifficulty} \t QPG|{questionQty}\n".ToUpper());
            Console.WriteLine("" + new string(' ', 20) + "Welcome to Math Games (Console)".ToUpper() + new string(' ', 29) + "");
            Console.WriteLine("              \n\n".ToUpper() + "\tMenu\n".ToUpper());
            Console.WriteLine("1: Addition (+)");
            Console.WriteLine("2: Subtration (-)");
            Console.WriteLine("3: Multiplication (x)");
            Console.WriteLine("4: Division (÷)");
            Console.WriteLine("5: Challenge (+, -, x, ÷)");
            Console.WriteLine($"6: Difficulty (DIFF)");
            Console.WriteLine($"7: History ({gameHistory.Count})");
            Console.WriteLine($"8: Questions / Game (QPG)");
            Console.WriteLine($"9: Reset (Time & Score)");
            Console.WriteLine("0. Exit (Goodbye)");
            Console.WriteLine();
            Console.Write("Selection (#): ");

            while (Console.KeyAvailable == false)
                Thread.Sleep(500);

            selection = Console.ReadKey();
            switch ((char)selection.Key)
            {
                case '1':
                    return Play('+', questionQty);
                case '2':
                    return Play('-', questionQty);
                case '3':
                    return Play('*', questionQty);
                case '4':
                    return Play('/', questionQty);
                case '5':
                    return PlayChallenge(questionQty);
                case '6':
                    return ConfigSettings('d');
                case '7':
                    return ShowHistory();
                case '8':
                    return ConfigSettings('q');
                case '9':
                    return ConfigSettings('h');
                case '0':
                    return false;
                default:
                    return true;
            }
        }

        private bool ConfigSettings(char setting)
        {
            if (setting == 'd')
            {
                Console.WriteLine("\nWhat difficulty level would you like? (easy, medium, hard)");
                if (Enum.TryParse(Console.ReadLine(), true, out Level diff))
                {
                    gameDifficulty = diff;
                    gameHistory.Add($"|| Game difficulty set to {diff} ||".ToUpper());
                }
                return true;
            }
            if (setting == 'q')
            {
                Console.WriteLine("\nHow many questions do you want per game?");
                string? input = Console.ReadLine();
                bool correctInput = int.TryParse(input, out int result);
                while (!correctInput)
                {
                    Console.WriteLine("\nHow many questions do you want to play?");
                }
                questionQty = result;
                gameHistory.Add($"|| QPG changed to {questionQty} ||".ToUpper());
                return true;
            }
            if (setting == 'h')
            {
                gameHistory.Add($"||Score & Time Reset.  Score: {score}/{gameHistory.Count}, Time: {timer.Elapsed.Minutes}:{timer.Elapsed.Seconds} (MM:SS)||".ToUpper());
                timer.Reset();
                score = 0;
                questionsAnswered = 0;
                return true;
            }
            return false;
        }

        private bool ShowHistory()
        {
            int roundNumber = 0;
            foreach (string logLine in gameHistory)
            {
                roundNumber++;
                Console.WriteLine($"\n{logLine}");
            }
            Console.WriteLine("\nPress enter to continue...");
            Console.ReadLine();
            return true;
        }

        private void GenerateNumbers(int quantity = 2, int maxValue = int.MaxValue)
        {
            Random numberGenerator = new();
            numbers = new int[quantity];
            for (int i = quantity; i != 0; i--)
            {
                numbers[i - 1] = numberGenerator.Next(maxValue);
            }
        }

        private int Calculator(int numberFirst, int numberSecond, char oper)
        {
            switch (oper)
            {
                case '+':
                    int sum = numberFirst + numberSecond;
                    return sum;
                case '-':
                    int difference = numberFirst - numberSecond;
                    return difference;
                case '*':
                    int product = numberFirst * numberSecond;
                    return product;
                case '/':
                    int quotient = numberFirst / numberSecond;
                    return quotient;
                default:
                    return 0;
            }
        }

        private int Simplifier(Level difficulty = Level.Easy)
        {
            switch (difficulty)
            {
                case Level.Easy:
                    return 100;

                case Level.Medium:
                    return 10;

                case Level.Hard:
                    return 1;

                default:
                    return 100;
            }
        }

        private bool Play(char oper, int repeat = 1)
        {

            for (int i = 0; i < repeat; i++)
            {
                switch (oper)
                {
                    case '/':
                        GenerateNumbers(2, 1000 / Simplifier(gameDifficulty));
                        bool goodDivNumber = false;
                        while (!goodDivNumber)
                        {
                            try
                            {
                                if (numbers[0] % numbers[1] == 0)
                                    goodDivNumber = true;
                                else
                                    GenerateNumbers(2, 1000 / Simplifier(gameDifficulty));
                            }
                            catch
                            {
                                GenerateNumbers(2, 1000 / Simplifier(gameDifficulty));
                                continue;
                            }
                        }
                        break;

                    case '*':
                        GenerateNumbers(2, 1200 / Simplifier(gameDifficulty));
                        bool goodMulNumber = false;
                        double checkMulInt;
                        while (!goodMulNumber)
                        {
                            checkMulInt = (double)numbers[0] * (double)numbers[1];
                            if (checkMulInt <= int.MaxValue)
                            {
                                goodMulNumber = true;
                            }
                            else
                            {
                                GenerateNumbers(2, 1200 / Simplifier(gameDifficulty));
                            }
                        }
                        break;

                    case '+':
                        GenerateNumbers(2, 1000 / Simplifier(gameDifficulty));
                        break;

                    case '-':
                        GenerateNumbers(2, 1000 / Simplifier(gameDifficulty));
                        break;
                }

                int calculated = Calculator(numbers[0], numbers[1], oper);

                gameHistory.Add($"{numbers[0]}" + $" {oper} " + $"{numbers[1]} = ");
                Console.WriteLine($"\nWhat is {gameHistory.Last()}?");

                timer.Start();
                bool validUserInput = int.TryParse(Console.ReadLine(), out int submitted);

                if (validUserInput)
                {
                    if (calculated == submitted)
                    {
                        score++;
                        questionsAnswered++;
                        gameHistory.Add($"Correct! | Answer: {calculated}");
                    }
                    else
                    {
                        gameHistory.Add($"Your Answer: {submitted} | Correct Answer: {calculated}");
                        questionsAnswered++;
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("You did not enter a valid number, try again: ");
                    validUserInput = int.TryParse(Console.ReadLine(), out submitted);

                    while (!validUserInput)
                    {
                        Console.WriteLine("You did not enter a valid number, try again: ");
                        validUserInput = int.TryParse(Console.ReadLine(), out submitted);
                    }

                    if (calculated == submitted)
                    {
                        score++;
                        gameHistory.Add($"Correct! | Answer: {calculated}");
                        questionsAnswered++;
                    }
                    else
                    {
                        gameHistory.Add($"Your Answer: {submitted} | Correct Answer: {calculated}");
                        questionsAnswered++;
                        continue;
                    }

                }
            }
            timer.Stop();
            return true;
        }
        private bool PlayChallenge(int repeat = 1)
        {
            char[] games = { '+', '-', '*', '/' };
            Random numberChoice = new();
            for (int j = 0; j < repeat; j++)
            {
                int choice = numberChoice.Next(0, 4);
                Play(games[choice]);
            }
            return true;
        }
    }
}