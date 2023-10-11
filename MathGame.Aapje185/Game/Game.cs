namespace C_Sharp_Academy.Game;

using ArithmeticOperations;
using Enums;

public class Game : IGame
{
    private readonly List<Result> _results;
    private const int RoundsPerGame = 5;

    public Game()
    {
        _results = new List<Result>();
    }

    public void StartGame<T>() where T : IArithmeticOperation, new()
    {
        var operationType = new T();
        var score = 0;
        var difficulty = SelectDifficulty();
        for (var i = 0; i < RoundsPerGame; i++)
        {
            Console.WriteLine(operationType.OperationMessage);

            var ints = GenerateInts(difficulty);

            Console.WriteLine($"{ints.Item1} {operationType.ArithmeticOperator} {ints.Item2} = ?");
            var userAnswer = GetUserInput();

            var result = operationType.PerformOperation(ints.Item1, ints.Item2) == userAnswer;

            GiveFeedback(result, ref score);
        }
        
        var gameResult = new Result(Type.Addition, score);
        _results.Add(gameResult);
    }

    public void QuitGame()
    {
        Console.WriteLine("Thank you for playing!");
    }

    public void StartAdditionGame()
    {
        var score = 0;
        var difficulty = SelectDifficulty();
        for (var i = 0; i < RoundsPerGame; i++)
        {
            Console.WriteLine("Addition game");
            
            var ints = GenerateInts(difficulty);

            Console.WriteLine($"{ints.Item1} + {ints.Item2} = ?");
            var userAnswer = GetUserInput();

            var result = ints.Item1 + ints.Item2 == userAnswer;
            
            GiveFeedback(result, ref score);
        }
        
        var gameResult = new Result(Type.Addition, score);
        _results.Add(gameResult);
    }
    
    public void ShowPreviousResults()
    {
        Console.WriteLine($"{"Date ", -20}{"Type ", -20}{"Score ", -10}");
        foreach (var result in _results)
        {
            Console.WriteLine($"{$"{result.Date.Date.ToShortDateString()} ", -20}{$"{result.Type} ", -20}{$"{result.Score} ", -10}");
        }
    }
    
    public Difficulty SelectDifficulty()
    {
        Console.WriteLine("Please select the difficulty:");
        
        foreach (Difficulty level in Enum.GetValues(typeof(Difficulty)))
        {
            Console.WriteLine($"{(int)level} - {level}");
        }

        var input = GetUserInput();
        return Enum.IsDefined(typeof(Difficulty), input) ? (Difficulty)input : SelectDifficulty();
    }

    private void GiveFeedback(bool isCorrect, ref int score)
    {
        string resultString;
        if (isCorrect)
        {
            resultString = "correct";
            score++;
        }
        else
        {
            resultString = "incorrect";
        }

        Console.WriteLine($"Your answer was {resultString}!");
        Console.WriteLine("Type any key for the next question");
    }

    private int GetUserInput()
    {
        if (int.TryParse(Console.ReadLine(), out var output))
        {
            return output;
        }
        
        Console.WriteLine("Input is not a valid number, please enter a valid number");
        return GetUserInput();
    }

    private (int, int) GenerateInts(Difficulty difficulty)
    {
        var rdm = new Random();

        var max = difficulty == Difficulty.Easy ? 10 : difficulty == Difficulty.Medium ? 50 : 1000;
        var int1 = rdm.Next(0, max);
        var int2 = rdm.Next(0, max);

        return (int1, int2);
    }
}