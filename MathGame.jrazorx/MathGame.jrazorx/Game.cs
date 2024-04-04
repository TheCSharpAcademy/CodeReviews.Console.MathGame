using System.Diagnostics;

namespace MathGame.jrazorx
{
    internal class Game
    {
        // Game Mode (Addition, Subtraction, Multiplication, Division)
        public string Mode { get; }

        // The random numbers used for the game
        public int FirstNumber { get; }
        public int SecondNumber { get; }

        // The correct answer of the game
        public int CorrectAnswer { get; }

        // Current operation for display
        public string Operation { get; }

        // Player's answer to the game
        public int PlayerAnswer { get; private set; }

        // result of the game : True = WIN, False = LOSE
        public bool IsWin { get; private set; }

        public TimeSpan TimeTakenToAnswer { get; private set; }


        // Constructor, requires game mode letter input (A, S, M, D)
        public Game(char gameLetter)
        {
            Random random = new ();

            switch (gameLetter)
            {
                case 'A':
                    Mode = "Addition";
                    FirstNumber = random.Next(0, 10);
                    SecondNumber = random.Next(0, 10);
                    CorrectAnswer = FirstNumber + SecondNumber;
                    Operation = $"{FirstNumber} + {SecondNumber}";
                    break;

                case 'S':
                    Mode = "Subtraction";
                    FirstNumber = random.Next(0, 10);
                    SecondNumber = random.Next(0, 10);
                    CorrectAnswer = FirstNumber - SecondNumber;
                    Operation = $"{FirstNumber} - {SecondNumber}";
                    break;

                case 'M':
                    Mode = "Multiplication";
                    FirstNumber = random.Next(0, 10);
                    SecondNumber = random.Next(0, 10);
                    CorrectAnswer = FirstNumber * SecondNumber;
                    Operation = $"{FirstNumber} x {SecondNumber}";
                    break;

                case 'D':
                    Mode = "Division";
                    do
                    {
                        FirstNumber = random.Next(0, 101);
                        SecondNumber = random.Next(1, 101);
                    } while (FirstNumber % SecondNumber != 0);
                    CorrectAnswer = FirstNumber / SecondNumber;
                    Operation = $"{FirstNumber} / {SecondNumber}";
                    break;

                default:
                    throw new ArgumentException("Invalid game mode letter input");
            }
        }

        // Play the game
        public void Play()
        {
            Console.Clear();
            Console.WriteLine(@$"{Mode} Game
--------------------");
            Console.WriteLine($"{Operation} = ?");

            PlayerAnswer = GetPlayerAnswerInput();

            WinOrLose(PlayerAnswer);
        }

        // Get the player input for the answer of the game until it is a valid number
        private int GetPlayerAnswerInput()
        {
            string? readResult;

            Stopwatch stopwatch = new ();
            stopwatch.Start();

            while (true)
            {
                readResult = Console.ReadLine();
                if (readResult == null)
                {
                    Console.WriteLine("Please enter a valid number");
                    continue;
                }
                try
                {
                    int playerAnswerInput = int.Parse((readResult ?? "").Trim());

                    stopwatch.Stop();
                    TimeTakenToAnswer = stopwatch.Elapsed;

                    return playerAnswerInput;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Invalid number : too big ! Please enter a valid number");
                }
                catch
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }
        }

        // Win (true) or lose (false) the game and displays a message
        private void WinOrLose(int playerAnswer)
        {
            if (playerAnswer == CorrectAnswer)
            {
                Console.WriteLine("You win !");
                IsWin = true;
            }
            else
            {
                Console.WriteLine("You lose ...");
                Console.WriteLine($"The answer was {CorrectAnswer}");
                IsWin = false;
            }
            PrintTimeTakenToAnswer(TimeTakenToAnswer);
        }

        // Print the time it took the user to answer, in English
        private static void PrintTimeTakenToAnswer(TimeSpan timeTakenToAnswer)
        {
            string result = "Time taken to answer: ";

            if (timeTakenToAnswer.TotalMilliseconds < 1000)
                result += $"{timeTakenToAnswer.Milliseconds} milliseconds";
            else if (timeTakenToAnswer.TotalSeconds < 60)
                result += $"{timeTakenToAnswer.TotalSeconds:N3} seconds";
            else
                result += "more than a minute";

            Console.WriteLine(result);
        }
    }
}