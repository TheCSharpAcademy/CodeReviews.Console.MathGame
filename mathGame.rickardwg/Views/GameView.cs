using MathGame.Enums;
using MathGame.Helpers;
using MathGame.Models;
using MathGame.Services;

namespace MathGame.Views;

internal class GameView(IGameService gameService) : IGameView
{
    private readonly IGameService _gameService = gameService;
    public void DisplayGame(GameMode gameMode, Difficulty difficulty)
    {
        Console.Clear();
        _gameService.StartGame(gameMode, difficulty);

        while (!_gameService.IsFinished)
        {
            var question = _gameService.GetCurrentQuestion();

            DisplayQuestion(question);

            var answer = ReadAnswer();

            var result = _gameService.SubmitAnswer(answer);

            DisplayResult(result, question.CorrectAnswer);
        }
        var entry = _gameService.EndGame();
        DisplaySummary(entry);

        Console.WriteLine();
        ConsoleHelper.WriteLine("Press any key to continue...", ConsoleColor.Yellow);
        Console.ReadKey();
    }

    private void DisplayQuestion(MathQuestion question)
    {
        var operationSymbol = GetOperationSymbol(question.Operation);

        ConsoleHelper.Write("What is ");
        ConsoleHelper.Write($"{question.LeftOperand}", ConsoleColor.Yellow);
        ConsoleHelper.Write($" {operationSymbol} ");
        ConsoleHelper.Write($"{question.RightOperand}", ConsoleColor.Yellow);
        ConsoleHelper.Write(" = ");
        ConsoleHelper.Write("?", ConsoleColor.Yellow);
        Console.WriteLine();
    }

    private int ReadAnswer()
    {
        int.TryParse(Console.ReadLine(), out int result);
        return result;
    }

    private void DisplayResult(bool result, int correctAnswer)
    {
        if (result)
        {
            ConsoleHelper.WriteLine("Correct!", ConsoleColor.Green);
        }
        else
        {
            ConsoleHelper.Write("Incorrect!", ConsoleColor.Red);
            ConsoleHelper.Write(" The answer was ");
            ConsoleHelper.Write($"{correctAnswer}", ConsoleColor.Yellow);
            ConsoleHelper.Write(".");
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    private void DisplaySummary(GameEntry entry)
    {
        ConsoleColor scoreColor = entry.CorrectAnswers == entry.TotalQuestions ? ConsoleColor.Green : ConsoleColor.Red;
        ConsoleHelper.Write("Score: ");
        ConsoleHelper.Write($"{entry.CorrectAnswers}", scoreColor);
        ConsoleHelper.Write(" / ");
        ConsoleHelper.Write($"{entry.TotalQuestions}", scoreColor);
        Console.WriteLine();

        ConsoleHelper.Write("Time: ");
        ConsoleHelper.Write($"{entry.TimeTaken.TotalSeconds:0}", ConsoleColor.Yellow);
        ConsoleHelper.Write(" seconds.");
        Console.WriteLine();
    }

    private string GetOperationSymbol(Operation operation)
    {
        return operation switch
        {
            Operation.Add => "+",
            Operation.Subtract => "-",
            Operation.Multiply => "*",
            Operation.Divide => "/",
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, "Unsupported operation.")
        };
    }
}
