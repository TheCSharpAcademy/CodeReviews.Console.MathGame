using System.Diagnostics;

namespace MathGame_CSA;

public class Game
{
    private List<GameResult> _results = new();
    private Random _random = new Random();

    public Game()
    {
        WriteGreetings();
    }

    public void Play()
    {
        while (true)
        {
            if (ExitOrNextOperation(out MathOperation operation))
                return;

            if (ExitOrNumberOfGames(out int count))
                return;

            Console.WriteLine($"You have chosen {operation} operation and {count} games.\nGame begins....");


            var timer = Stopwatch.StartNew();
            var correctAnswer = 0;
            for (int i = 0; i < count; i++)
            {
                var puzzle = new Puzzle(_random, operation);
                puzzle.Play();
                if (puzzle.IsCorrect)
                    correctAnswer++;
            }
            timer.Stop();

            var gameResult = new GameResult(correctAnswer, count, DateTime.Now, timer.Elapsed);
            _results.Add(gameResult);

            WriteEnding();
            if (Exit())
                return;
        }
    }

    private void WriteGreetings()
    {
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("Welcome to Math Game!\n");
        Console.WriteLine(new string('-', 30));
    }

    private bool ExitOrNextOperation(out MathOperation op)
    {
        while (true)
        {
            Console.WriteLine("You can choose from four different math operations: - + * /");
            Console.Write("Enter math operator to start the game or 'q' to exit: ");
            var input = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (input.Equals('q'))
            {
                op = MathOperation.Addition;
                return true;
            }
            else if (input.TryParseToMathOperation(out op))
            {
                return false;
            }
        }
    }

    private bool ExitOrNumberOfGames(out int count)
    {
        while (true)
        {
            Console.WriteLine("Enter number of games or 'q' for end game: ");
            var input = Console.ReadLine()!;
            if (input.Equals("q", StringComparison.OrdinalIgnoreCase))
            {
                count = 0;
                return true;
            }
            else if (int.TryParse(input, out count))
            {
                return false;
            }
        }
    }

    private void WriteEnding()
    {
        Console.WriteLine($"Congradulations! You have completed game.\n");
        Console.WriteLine(new string('-', 30));
        Console.WriteLine($"Your score is {_results[^1].CorrectAnswers}");
        Console.WriteLine(new string('-', 30));
        Console.WriteLine();

        Console.WriteLine("Results from prevous games");
        Console.WriteLine(new string('-', 30));

        for (int i = 0; i < _results.Count; i++)
        {
            Console.WriteLine(_results[i]);
        }

        Console.WriteLine(new string('-', 30));
        Console.WriteLine("For playing new game press any key, for exit press 'q'");
    }

    private bool Exit()
    {
        var input = Console.ReadKey().Key;
        if (input.Equals(ConsoleKey.Q))
            return true;

        return false;
    }
}
