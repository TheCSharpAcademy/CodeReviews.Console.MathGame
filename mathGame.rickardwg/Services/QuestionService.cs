using MathGame.Enums;
using MathGame.Models;

namespace MathGame.Services;

internal class QuestionService : IQuestionService
{
    private const int EasyMaxValue = 10;
    private const int MediumMaxValue = 50;
    private const int HardMaxValue = 100;

    public MathQuestion GenerateQuestion(GameMode gameMode, Difficulty difficulty)
    {
        var operation = GetOperation(gameMode);
        var maxAnswerValue = GetMaxAnswerValue(difficulty);

        var (leftOperand, rightOperand, correctAnswer) = operation switch 
        {
            Operation.Add => GenerateAddition(maxAnswerValue),
            Operation.Subtract => GenerateSubtraction(maxAnswerValue),
            Operation.Multiply => GenerateMultiplication(maxAnswerValue),
            Operation.Divide => GenerateDivision(maxAnswerValue),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation}")
        };

        return new MathQuestion
        {
            LeftOperand = leftOperand,
            RightOperand = rightOperand,
            Operation = operation,
            CorrectAnswer = correctAnswer,
        };
    }

    private Operation GetOperation(GameMode gameMode)
    {
        if (gameMode == GameMode.Random)
        {
            var values = Enum.GetValues<Operation>();
            return values[Random.Shared.Next(values.Length)];
        }

        return gameMode switch
        {
            GameMode.Addition => Operation.Add,
            GameMode.Subtraction => Operation.Subtract,
            GameMode.Multiplication => Operation.Multiply,
            GameMode.Division => Operation.Divide,
            _ => throw new ArgumentOutOfRangeException(nameof(gameMode), gameMode, "Unsupported game mode.")
        };
    }

    private int GetMaxAnswerValue(Difficulty difficulty)
    {
        return difficulty switch
        {
            Difficulty.Easy => EasyMaxValue,
            Difficulty.Medium => MediumMaxValue,
            Difficulty.Hard => HardMaxValue,
            _ => throw new ArgumentOutOfRangeException(nameof(difficulty), difficulty, "Unsupported difficulty.")
        };
    }

    private (int LeftOperand, int RightOperand, int CorrectAnswer) GenerateAddition(int maxAnswerValue)
    {
        int correctAnswer = Random.Shared.Next(1, maxAnswerValue + 1);
        int leftOperand = Random.Shared.Next(1, correctAnswer);
        int rightOperand = correctAnswer - leftOperand;

        return (leftOperand, rightOperand, correctAnswer);
    }

    private (int LeftOperand, int RightOperand, int CorrectAnswer) GenerateSubtraction(int maxAnswerValue)
    {
        int leftOperand = Random.Shared.Next(1, maxAnswerValue + 1);
        int rightOperand = Random.Shared.Next(1, leftOperand);
        int correctAnswer = leftOperand - rightOperand;

        return (leftOperand, rightOperand, correctAnswer);
    }

    private (int LeftOperand, int RightOperand, int CorrectAnswer) GenerateMultiplication(int maxAnswerValue)
    {
        int leftOperand = Random.Shared.Next(2, maxAnswerValue + 1);
        int maxRightOperand = maxAnswerValue / leftOperand;
        int rightOperand = Random.Shared.Next(1, maxRightOperand + 1);
        int correctAnswer = leftOperand * rightOperand;

        return (leftOperand, rightOperand, correctAnswer);
    }

    private (int LeftOperand, int RightOperand, int CorrectAnswer) GenerateDivision(int maxAnswerValue)
    {
        int rightOperand = Random.Shared.Next(1, maxAnswerValue + 1);
        int maxCorrectAnswer = maxAnswerValue / rightOperand;
        int correctAnswer = Random.Shared.Next(maxCorrectAnswer + 1);
        int leftOperand = rightOperand * correctAnswer;

        return (leftOperand, rightOperand, correctAnswer);
    }
}
