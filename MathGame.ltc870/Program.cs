namespace MathGame.ltc870
{
    class Program
    {
        static void Main(string[] args)
        {

            Helpers helpers = new Helpers();
            Console.WriteLine("What is your name?");
            string name = helpers.ValidateName();
            DateTime date = DateTime.Now;
            char userOption;
            bool gameIsOn = true;


            Console.WriteLine($"Hello {name}! Today is {date} let's play our Math Game! Press any key to begin...");
            Console.ReadKey();

            do
            {
                Console.WriteLine(@"Which game would you like to play?
      A - Addition
      S - Subtraction
      M - Multiplication
      D - Division
      R - Random
      V - View Score History
      Q - Quit");

                userOption = helpers.ValidateMenuInput();
                Console.Clear();

                switch (char.ToLower(userOption))
                {
                    case 'a':
                        PlayGame('a');
                        break;
                    case 's':
                        PlayGame('s');
                        break;
                    case 'm':
                        PlayGame('m');
                        break;
                    case 'd':
                        PlayGame('d');
                        break;
                    case 'r':
                        PlayGame('r', true);
                        break;
                    case 'v':
                        helpers.ViewScoreHistory();
                        break;
                    case 'q':
                        Console.WriteLine("Thanks for playing! Goodbye!");
                        gameIsOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            } while (gameIsOn);

            void PlayGame(char gameType, bool isRandom = false)
            {
                char[] gameTypes = { 'a', 's', 'm', 'd' };

                Console.Clear();

                int score = 0;

                Console.WriteLine("How many times would you like to play?");

                int numTimes = helpers.ValidateNumToPlay();

                char difficultyLevel = helpers.GetDifficultyLevel();

                var startTime = DateTime.Now;

                for (int i = 0; i < numTimes; i++)
                {
                    if (isRandom)
                    {
                        var random = new Random();
                        var gameIndex = random.Next(0, 4);
                        gameType = gameTypes[gameIndex];
                    }

                    string sign = gameType switch
                    {
                        'a' => "+",
                        's' => "-",
                        'm' => "*",
                        'd' => "/",
                    };

                    Func<int, int, int> operation = gameType switch
                    {
                        'a' => (x, y) => x + y,
                        's' => (x, y) => x - y,
                        'm' => (x, y) => x * y,
                        'd' => (x, y) => x / y,
                    };

                    var operands = helpers.GetOperands(difficultyLevel, gameType);
                    int firstNumber = operands[0];
                    int secondNumber = operands[1];

                    Console.WriteLine($"{firstNumber} {sign} {secondNumber}");
                    int answer = helpers.ValidateAnswerInput();

                    if (answer == operation(firstNumber, secondNumber))
                    {
                        Console.WriteLine("Correct!");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect!");
                    }
                }

                var endTime = DateTime.Now;
                TimeSpan totalTime = endTime - startTime;

                Console.WriteLine($"You got {score} out of {numTimes} correct in {totalTime.TotalSeconds} seconds!");

                helpers.gameHistory.Add($"{gameType} - {score} out of {numTimes} correct in {totalTime.TotalSeconds} seconds!");
            }
        }
    }
}
