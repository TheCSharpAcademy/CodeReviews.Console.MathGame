using MathGame._4r73m190r0s.Models;
namespace MathGame._4r73m190r0s;

internal class GameEngine
{
    internal static List<Game> games = new List<Game>();

    internal static void AdditionGame()
    {
        Console.Clear();
        Console.WriteLine("Addition Game\n");

        var score = 0;

        var random = new Random();

        int firstNumber;
        int secondNumber;

        for (int i = 0; i < 5; i++)
        {
            firstNumber = random.Next(1, 10);
            secondNumber = random.Next(1, 10);
            Console.WriteLine($"{firstNumber} + {secondNumber} = X");
            Console.Write("X = ");
            var result = Console.ReadLine();

            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber + secondNumber)
            {
                Console.WriteLine("Correct Answer\n");
                score++;
            }
            else
            {
                Console.WriteLine("Incorrect Answer\n");
            }
        }

        Console.WriteLine("Game Over");
        Console.WriteLine($"Your Score in Addition Game Is {score}.\n");
        Console.WriteLine("Press Any Key + ENTER to Return to the Main Menu\n");
        Console.ReadLine();

        games.Add(new Game() 
        { 
            Score = score, 
            Type = GameType.Addition, 
            Date = DateTime.Now 
        });
    }

    internal static void SubtractionGame()
    {
        Console.Clear();
        Console.WriteLine("Subtraction Game\n");

        var score = 0;

        var random = new Random();

        int firstNumber;
        int secondNumber;

        for (int i = 0; i < 5; i++)
        {
            firstNumber = random.Next(1, 10);
            secondNumber = random.Next(1, 10);
            Console.WriteLine($"{firstNumber} - {secondNumber} = X");
            Console.Write("X = ");
            var result = Console.ReadLine();

            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber - secondNumber)
            {
                Console.WriteLine("Correct Answer\n");
                score++;
            }
            else
            {
                Console.WriteLine("Incorrect Answer\n");
            }
        }

        Console.WriteLine("Game Over");
        Console.WriteLine($"Your Finale Score is Subtraction Game Is {score}.\n");
        Console.WriteLine("Press Any Key + ENTER to Return to the Main Menu\n");
        Console.ReadLine();

        games.Add(new Game()
        {
            Score = score,
            Type = GameType.Subtraction,
            Date = DateTime.Now
        });
    }

    internal static void MultiplicationGame()
    {
        Console.Clear();
        Console.WriteLine("Multiplication Game\n");

        var score = 0;

        var random = new Random();

        int firstNumber;
        int secondNumber;

        for (int i = 0; i < 5; i++)
        {
            firstNumber = random.Next(1, 10);
            secondNumber = random.Next(1, 10);
            Console.WriteLine($"{firstNumber} * {secondNumber} = X");
            Console.WriteLine("X = ");
            var result = Console.ReadLine();

            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber * secondNumber)
            {
                Console.WriteLine("Correct Answer\n");
                score++;
            }
            else
            {
                Console.WriteLine("Incorrect Answer\n");
            }            
        }

        Console.WriteLine("Game Over");
        Console.WriteLine($"Your Final Score in Multiplication Game Is {score}.\n");
        Console.Write("Press Any Key + Enter to Return to the Main Menu\n");
        Console.ReadLine();

        games.Add(new Game()
        {
            Score = score,
            Type = GameType.Multiplication,
            Date = DateTime.Now
        });
    }

    internal static void DivisionGame()
    {
        Console.Clear();
        Console.WriteLine("Division Game\n");

        var score = 0;

        for (int i = 0; i < 5; i++)
        {
            var divisionNumbers = Helpers.GetDivisionNumbers();
            var firstNumber = divisionNumbers[0];
            var secondNumber = divisionNumbers[1];

            Console.WriteLine($"{firstNumber} / {secondNumber} = X");
            Console.WriteLine("X = ");
            var result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber / secondNumber)
            {
                Console.WriteLine("Correct Answer\n");
                score++;
            }
            else
            {
                Console.WriteLine("Incorrect Answer\n");
            }
        }

        Console.WriteLine("Game Over");
        Console.WriteLine($"Your Final Score in Division Game Is {score}.\n");
        Console.Write("Press Any Key + Enter to Return to the Main Menu\n");
        Console.ReadLine();

        games.Add(new Game()
        {
            Score = score,
            Type = GameType.Division,
            Date = DateTime.Now
        });
    }
}
