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


        // Constructor, requires game mode letter input (A, S, M, D)
        public Game(char gameLetter)
        {
            Random random = new Random();

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

        public void Play()
        {
            Console.Clear();
            Console.WriteLine(@$"{Mode} Game
--------------------");
            Console.WriteLine($"{Operation} = ?");

            PlayerAnswer = GetPlayerAnswerInput();

            IsWin = WinOrLose(PlayerAnswer);
        }

        // Get the player input for the answer of the game until it is a valid number
        private int GetPlayerAnswerInput()
        {
            string? readResult;
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
                    return int.Parse((readResult ?? "").Trim());
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
        private bool WinOrLose(int playerAnswer)
        {
            if (playerAnswer == CorrectAnswer)
            {
                Console.WriteLine("You win !");
                return true;
            }
            else
            {
                Console.WriteLine("You lose ...");
                Console.WriteLine($"The answer was {CorrectAnswer}");
                return false;
            }
        }
    }
}
