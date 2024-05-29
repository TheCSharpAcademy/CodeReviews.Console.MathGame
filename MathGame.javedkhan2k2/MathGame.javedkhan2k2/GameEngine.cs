using MathGame.javedkhan2k2.Models;

namespace MathGame.javedkhan2k2;

internal class GameEngine
{
    public string PlayerName { get; set; } = default!;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int NumberOfQuestions = 5;
    public GameDifficulty Difficulty = GameDifficulty.Easy;
    public GameEngine(string playerName, int numberOfQuestions) : this(playerName)
    {
        NumberOfQuestions = numberOfQuestions;
    }
    public GameEngine(string playerName)
    {
        PlayerName = playerName;
        StartTime = DateTime.UtcNow;
    }

    internal void RandomGame(string message)
    {
        var random = new Random();
        var score = 0;
        var startTime = DateTime.UtcNow;
        int firstNumber;
        int secondNumber;
        char op;
        var difficulty = Convert.ToInt32(Difficulty);

        for (int i = 0; i < NumberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            op = Helpers.GenerateGameType();
            if (op == '/')
            {
                (firstNumber, secondNumber) = Helpers.GetDivisionNumbers(Convert.ToInt32(Difficulty));
            }
            else
            {
                firstNumber = random.Next(1, difficulty);
                secondNumber = random.Next(1, difficulty);
            }
            Console.WriteLine($"{firstNumber} {op} {secondNumber}");
            var result = Console.ReadLine();
            result = Helpers.ValidateResult(result);
            if (int.Parse(result) == Helpers.GetResult(firstNumber, secondNumber, op))
            {
                Console.WriteLine("Your answer was correct! Type any key for the next question");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                Console.ReadLine();
            }
            if (i == NumberOfQuestions - 1)
            {
                Console.WriteLine($"Game over. Your final score is {score}. Press any key to go back to the main menu.");
                Console.ReadLine();
            }
        }
        Helpers.AddToHistory(new Game
        {
            EndTime = DateTime.UtcNow,
            StartTime = startTime,
            NumberOfQuestions = NumberOfQuestions,
            Score = score,
            Type = GameType.Random,
            Difficulty = Difficulty
        });
    }
    internal void DivisionGame(string message)
    {
        var score = 0;
        var startTime = DateTime.UtcNow;

        for (int i = 0; i < NumberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            var (firstNumber, secondNumber) = Helpers.GetDivisionNumbers(Convert.ToInt32(Difficulty));
            

            Console.WriteLine($"{firstNumber} / {secondNumber}");

            var result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber / secondNumber)
            {
                Console.WriteLine("Your answer was correct! Type any key for the next question");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                Console.ReadLine();
            }

            if (i == NumberOfQuestions - 1)
            {
                Console.WriteLine($"Game over. Your final score is {score}. Press any key to go back to the main menu.");
                Console.ReadLine();
            }
        }

        Helpers.AddToHistory(new Game
        {
            EndTime = DateTime.UtcNow,
            StartTime = startTime,
            NumberOfQuestions = NumberOfQuestions,
            Score = score,
            Type = GameType.Division,
            Difficulty = Difficulty
        });
    }

    internal void MultiplicationGame(string message)
    {
        var random = new Random();
        var score = 0;
        var startTime = DateTime.UtcNow;

        int firstNumber;
        int secondNumber;

        for (int i = 0; i < NumberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            var difficulty = Convert.ToInt32(Difficulty);
            firstNumber = random.Next(1, difficulty);
            secondNumber = random.Next(1, difficulty);

            Console.WriteLine($"{firstNumber} * {secondNumber}");

            var result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber * secondNumber)
            {
                Console.WriteLine("Your answer was correct! Type any key for the next question");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                Console.ReadLine();
            }

            if (i == NumberOfQuestions - 1)
            {
                Console.WriteLine($"Game over. Your final score is {score}. Press any key to go back to the main menu.");
                Console.ReadLine();
            }
        }

        Helpers.AddToHistory(new Game
        {
            EndTime = DateTime.UtcNow,
            StartTime = startTime,
            NumberOfQuestions = NumberOfQuestions,
            Score = score,
            Type = GameType.Multiplication,
            Difficulty = Difficulty
        });
    }

    internal void SubtractionGame(string message)
    {
        var random = new Random();
        var score = 0;
        var startTime = DateTime.UtcNow;

        int firstNumber;
        int secondNumber;

        for (int i = 0; i < NumberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            var difficulty = Convert.ToInt32(Difficulty);
            firstNumber = random.Next(1, difficulty);
            secondNumber = random.Next(1, difficulty);

            Console.WriteLine($"{firstNumber} - {secondNumber}");

            var result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber - secondNumber)
            {
                Console.WriteLine("Your answer was correct! Type any key for the next question");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                Console.ReadLine();
            }

            if (i == NumberOfQuestions - 1)
            {
                Console.WriteLine($"Game over. Your final score is {score}. Press any key to go back to the main menu.");
                Console.ReadLine();
            }
        }

        Helpers.AddToHistory(new Game
        {
            EndTime = DateTime.UtcNow,
            StartTime = startTime,
            NumberOfQuestions = NumberOfQuestions,
            Score = score,
            Type = GameType.Subtraction,
            Difficulty = Difficulty
        });
    }

    internal void AdditionGame(string message)
    {
        var random = new Random();
        var score = 0;
        var startTime = DateTime.UtcNow;

        int firstNumber;
        int secondNumber;

        for (int i = 0; i < NumberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            var difficulty = Convert.ToInt32(Difficulty);
            firstNumber = random.Next(1, difficulty);
            secondNumber = random.Next(1, difficulty);

            Console.WriteLine($"{firstNumber} + {secondNumber}");

            var result = Console.ReadLine();
            result = Helpers.ValidateResult(result);


            if (int.Parse(result) == firstNumber + secondNumber)
            {
                Console.WriteLine("Your answer was correct! Type any key for the next question");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                Console.ReadLine();
            }

            if (i == NumberOfQuestions - 1)
            {
                Console.WriteLine($"Game over. Your final score is {score}. Press any key to go back to the main menu.");
                Console.ReadLine();
            }
        }
        Helpers.AddToHistory(new Game
        {
            EndTime = DateTime.UtcNow,
            StartTime = startTime,
            NumberOfQuestions = NumberOfQuestions,
            Score = score,
            Type = GameType.Addition,
            Difficulty = Difficulty
        });
    }

    internal void ChangeQuestions()
    {
        Console.Clear();
        Console.WriteLine("Enter new number of questions");
        var result = Console.ReadLine();
        result = Helpers.ValidateResult(result);
        NumberOfQuestions = int.Parse(result);
        Console.WriteLine("Press any key to return to Main Menu");
        Console.ReadLine();
    }

    internal void ChangeDifficulty()
    {
        Console.Clear();
        Console.WriteLine(@$"
Select the Game Difficulty? Choose from the options below:
E - Easy
N - Normal
H - Hard");
        Console.WriteLine("---------------------------------------------");
        var difficultySelected = Console.ReadLine();

        switch (difficultySelected.Trim().ToLower())
        {
            case "e":
                Difficulty = GameDifficulty.Easy;
                break;
            case "n":
                Difficulty = GameDifficulty.Normal;
                break;
            case "h":
                Difficulty = GameDifficulty.Hard;
                break;
            default:
                Console.WriteLine("Invalid Input");
                break;
        }
    }

}