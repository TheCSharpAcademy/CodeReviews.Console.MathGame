using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KristianLepka.MathGame;

class MathGame
{
    readonly Random rand = new();
    readonly List<MathProblem> problems = new();
    readonly GameStats stats;
    readonly Stopwatch stopwatch = new();

    public MathGame(Difficulty difficulty, int numberOfQuestions, char pOperator, bool randomOperator,
        GameStats stats)
    {
        Difficulty = difficulty;
        NumberOfQuestions = numberOfQuestions;
        Operator = pOperator;
        RandomOperator = randomOperator;
        this.stats = stats;
    }

    public ReadOnlyCollection<MathProblem> Problems => problems.AsReadOnly();
    public int CorrectAnswers { get; private set; }
    public double PlayTime { get; private set; }
    public int NumberOfQuestions { get; }
    public Difficulty Difficulty { get; }
    public char Operator { get;}
    public bool RandomOperator { get; }

    public void Start()
    {
        stopwatch.Start();
        for (int i = 0; i < NumberOfQuestions; i++)
        {
            char op = Operator;
            if (RandomOperator)
                op = GetRandomOperator();

            var problem = MathProblem.Generate(op, Difficulty);

            Console.WriteLine($"Problem {i + 1}:");
            Console.WriteLine(problem.ToString());
            WriteInputPrompt($"problem_{i + 1}_answer");
            string input = Console.ReadLine() ?? string.Empty;
            if (input == problem.Answer.ToString())
            {
                WriteAnswerResult(true, problem.Answer);
                problem.AnsweredCorrectly = true;
                CorrectAnswers++;
            }
            else
            {
                WriteAnswerResult(false, problem.Answer);
                problem.AnsweredCorrectly = false;
            }

            problems.Add(problem);
        }

        PlayTime = Math.Round(stopwatch.Elapsed.TotalSeconds, 0);
        stopwatch.Reset();

        var original = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("The game is finnished!");
        Console.WriteLine("Your statistics for this game:");
        Console.WriteLine($"\tCorrect answers: {CorrectAnswers}/{NumberOfQuestions}");
        Console.WriteLine($"\tIt took you {PlayTime} seconds to finish this game.");
        Console.WriteLine("Returning to main menu...");
        Console.ForegroundColor = original;
        stats.Add(this);
    }

    void WriteInputPrompt(string text) 
        => ConsoleHelper.WriteInColor($"> {text} >> ", ConsoleColor.Cyan);

    void WriteAnswerResult(bool correct, int answer)
    {
        if (correct)
            ConsoleHelper.WriteLineInColor("Correct answer!\n", ConsoleColor.Green);
        else
            ConsoleHelper.WriteLineInColor($"Incorrect answer :( Correct answer was: {answer}\n", ConsoleColor.Red);
    }

    char GetRandomOperator()
        => rand.Next(0, 4) switch
        {
            0 => '+',
            1 => '-',
            2 => '*',
            3 => '/',
            _ => throw new NotImplementedException()
        };
}
