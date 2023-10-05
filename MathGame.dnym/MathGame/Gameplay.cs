using MathGame.Models;
using MathGame.Modes;

namespace MathGame;

internal class Gameplay
{
    private readonly Tuple<Tuple<int, int>, Tuple<int, int>, Tuple<int, int>> _difficulty1 = new(new Tuple<int, int>(-10, 11), new Tuple<int, int>(-10, 11), new Tuple<int, int>(-10, 11));
    private readonly Tuple<Tuple<int, int>, Tuple<int, int>, Tuple<int, int>> _difficulty2 = new(new Tuple<int, int>(-25, 26), new Tuple<int, int>(-25, 26), new Tuple<int, int>(-25, 26));
    private readonly Tuple<Tuple<int, int>, Tuple<int, int>, Tuple<int, int>> _difficulty3 = new(new Tuple<int, int>(-50, 51), new Tuple<int, int>(-50, 51), new Tuple<int, int>(-50, 51));
    private readonly Tuple<Tuple<int, int>, Tuple<int, int>, Tuple<int, int>> _difficulty4 = new(new Tuple<int, int>(-75, 76), new Tuple<int, int>(-75, 76), new Tuple<int, int>(-75, 76));
    private readonly Tuple<Tuple<int, int>, Tuple<int, int>, Tuple<int, int>> _difficulty5 = new(new Tuple<int, int>(-100, 101), new Tuple<int, int>(-100, 101), new Tuple<int, int>(-100, 101));
    private readonly IList<Game> _games = new List<Game>();
    private readonly IOperation _addition = new Addition();
    private readonly IOperation _subtraction = new Subtraction();
    private readonly IOperation _multiplication = new Multiplication();
    private readonly IOperation _division = new Division();
    private readonly IOperation _random = new RandomMode();
    private RoundGenerator _roundGenerator;
    private int _roundsPerGame = 5;
    private int _currentDifficulty = 5;

    public Gameplay()
    {
        _roundGenerator = new(_difficulty5.Item1, _difficulty5.Item2, _difficulty5.Item3);
    }

    public void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(@"Math Game
=========

1. Play [A]ddition
2. Play [S]ubtraction
3. Play [M]ultiplication
4. Play [D]ivision
5. Play a [R]andom Game
6. Show [H]istory
7. [C]hange Settings
8. [Q]uit

Press a number or letter key to choose.");
            var selection = Console.ReadKey(true);
            switch (selection.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                case ConsoleKey.A:
                    Play(_addition);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                case ConsoleKey.S:
                    Play(_subtraction);
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                case ConsoleKey.M:
                    Play(_multiplication);
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                case ConsoleKey.D:
                    Play(_division);
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                case ConsoleKey.R:
                    Play(_random);
                    break;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                case ConsoleKey.H:
                    ShowHistory();
                    break;
                case ConsoleKey.D7:
                case ConsoleKey.NumPad7:
                case ConsoleKey.C:
                    ShowSettings();
                    break;
                case ConsoleKey.D8:
                case ConsoleKey.NumPad8:
                case ConsoleKey.Q:
                    return;
            }
        }
    }

    private void Play(IOperation operation)
    {
        IOperation[] operations = new[] { _addition, _subtraction, _multiplication, _division };
        Game game = new(DateTime.UtcNow, operation);
        for (int i = 0; i < _roundsPerGame; i++)
        {
            var currentOperation = operation;
            if (operation == _random)
            {
                currentOperation = operations[new Random().Next(0, operations.Length)];
            }
            string header = currentOperation.DisplayName + "\n" + new string('=', currentOperation.DisplayName.Length);
            var (a, b, result) = _roundGenerator.GenerateQuestion(currentOperation);
            string? response = null;
            string warning = "";
            while (response == null)
            {
                Console.Clear();
                var timer = new System.Diagnostics.Stopwatch();
                Console.Write("{0}\n\nRound {1}/{2}: What is {3}? ", header, i + 1, _roundsPerGame, string.Format(currentOperation.DisplayPattern, a, b));
                timer.Start();
                if (warning != "")
                {
                    var currentCursorHorizontalPosition = Console.CursorLeft;
                    var currentCursorVerticalPosition = Console.CursorTop;
                    Console.WriteLine(warning);
                    Console.SetCursorPosition(currentCursorHorizontalPosition, currentCursorVerticalPosition);
                }
                response = Console.ReadLine();
                if (int.TryParse(response, out int responseInt))
                {
                    warning = "";
                    {
                        // This is a hack to clear the the warning.
                        var currentCursorHorizontalPosition = Console.CursorLeft;
                        var currentCursorVerticalPosition = Console.CursorTop;
                        Console.WriteLine(new string(' ', Console.WindowWidth));
                        Console.WriteLine(new string(' ', Console.WindowWidth));
                        Console.WriteLine(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(currentCursorHorizontalPosition, currentCursorVerticalPosition);
                    }
                    timer.Stop();
                    if (responseInt == result)
                    {
                        Console.WriteLine("\nCorrect!");
                    }
                    else
                    {
                        Console.WriteLine($"\nThe correct answer is {result}.");
                    }
                    var round = new Round(currentOperation, a, b, responseInt);
                    round.MillisecondsToAnswer = (int)timer.ElapsedMilliseconds;
                    game.Rounds.Add(round);
                    if (i == _roundsPerGame - 1)
                    {
                        Console.WriteLine("\nGame over! You scored {0} out of {1}.",
                            game.Rounds.Count(r => r.GivenAnswer == r.Operation.Calculate(r.FirstNumber, r.SecondNumber)),
                            game.Rounds.Count);
                        Console.WriteLine("\nPress any key to continue.");
                    }
                    else
                    {
                        Console.WriteLine("\nPress any key to continue\nor q to quit to menu.");
                    }
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Q)
                    {
                        return;
                    }
                }
                else
                {
                    if (string.Equals(response?.Trim(), "q", StringComparison.OrdinalIgnoreCase))
                    {
                        return;
                    }
                    warning = "\n\nPlease enter a number\nor q to quit to menu.";
                    response = null;
                }
            }
        }
        _games.Add(game);
    }

    private void ShowHistory()
    {
        const string header = "History\n=======\n";
        const string footer = "Press any key to continue.";
        var maxLines = Console.WindowHeight - 6;
        var lines = new List<string>();
        string line;
        for (int i = 0; i < _games.Count; i++)
        {
            var game = _games[i];
            var time = game.StartTime.ToString("g");
            int correctRounds = game.Rounds.Count(r => r.GivenAnswer == r.Operation.Calculate(r.FirstNumber, r.SecondNumber));
            int totalRounds = game.Rounds.Count;
            double seconds = game.Rounds.Sum(r => r.MillisecondsToAnswer) / 1000.0;
            line = string.Format("[{0}] {1} ({2}/{3} correct in {4:F1} seconds)", time, game.Operation.DisplayName, correctRounds, totalRounds, seconds);
            lines.Add(line);
            for (int j = 0; j < game.Rounds.Count; j++)
            {
                var round = game.Rounds[j];
                var a = round.FirstNumber;
                var b = round.SecondNumber;
                var expectedAnswer = round.Operation.Calculate(round.FirstNumber, round.SecondNumber);
                var formatted = string.Format(round.Operation.DisplayPattern, a, b);
                if (round.GivenAnswer == expectedAnswer)
                {
                    line = string.Format("  {0}) {1}?\tGot {2}.", j + 1, formatted, round.GivenAnswer);
                    lines.Add(line);
                }
                else
                {
                    line = string.Format("  {0}) {1}?\tGot {2}, expected {3}.", j + 1, formatted, round.GivenAnswer, expectedAnswer);
                    lines.Add(line);
                }
            }
            lines.Add(string.Empty);
        }

        do
        {
            Console.Clear();
            Console.WriteLine(header);
            var linesToPrint = Math.Min(maxLines, lines.Count);
            for (int i = 0; i < linesToPrint; i++)
            {
                Console.WriteLine(lines[i]);
            }
            if (linesToPrint > 1 && !string.IsNullOrWhiteSpace(lines[linesToPrint - 1]))
            {
                // Empty line in front of footer.
                Console.WriteLine();
            }
            lines.RemoveRange(0, linesToPrint);
            if (lines.Count > 0)
            {
                Console.WriteLine("Press enter to view more.");
            }
            else
            {
                Console.WriteLine(footer);
            }
            Console.ReadKey(true);
        } while (lines.Count > 0);
    }

    private void ShowSettings()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(@$"Settings
========

1. Change the Number of [R]ounds per Game (Currently: {_roundsPerGame})
2. Change the [D]ifficulty (Currently: {_currentDifficulty})
3. [Q]uit to Main Menu

Press a number or letter key to choose.");
            var selection = Console.ReadKey(true);
            switch (selection.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                case ConsoleKey.R:
                    ChangeRoundsPerGame();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                case ConsoleKey.D:
                    ChangeDifficulty();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                case ConsoleKey.Q:
                    return;
            }
        }
    }

    private void ChangeRoundsPerGame()
    {
        while (true)
        {
            Console.Clear();
            Console.Write(@$"Rounds per Game
===============

How many rounds per game? (Currently: {_roundsPerGame}) ");
            var response = Console.ReadLine();
            if (int.TryParse(response, out int responseInt) && responseInt > 0)
            {
                _roundsPerGame = responseInt;
                return;
            }
            Console.WriteLine("\nPlease enter a positive number.");
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey(true);
        }
    }

    private void ChangeDifficulty()
    {
        while (true)
        {
            Console.Clear();
            Console.Write(@$"Difficulty
==========

Which difficulty do you want, from 1 (easy) to 5 (hard)? (Currently: {_currentDifficulty}) ");
            var response = Console.ReadLine();
            if (int.TryParse(response, out int responseInt) && responseInt >= 1 && responseInt <= 5)
            {
                _currentDifficulty = responseInt;
                switch (_currentDifficulty)
                {
                    case 1:
                        _roundGenerator = new(_difficulty1.Item1, _difficulty1.Item2, _difficulty1.Item3);
                        return;
                    case 2:
                        _roundGenerator = new(_difficulty2.Item1, _difficulty2.Item2, _difficulty2.Item3);
                        return;
                    case 3:
                        _roundGenerator = new(_difficulty3.Item1, _difficulty3.Item2, _difficulty3.Item3);
                        return;
                    case 4:
                        _roundGenerator = new(_difficulty4.Item1, _difficulty4.Item2, _difficulty4.Item3);
                        return;
                    case 5:
                        _roundGenerator = new(_difficulty5.Item1, _difficulty5.Item2, _difficulty5.Item3);
                        return;
                }
            }
            Console.WriteLine("\nPlease enter a number between 1 and 5.");
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey(true);
        }
    }
}
