using MathGame.Enums;

namespace MathGame.Models;

public class MathQuestion
{
    // Fields:
    public int OperandA { get; }
    public int OperandB { get; }
    public GameType Game { get; }
    public int CorrectAnswer { get; }
    public int? PlayerAnswer { get; private set; } // ? means it can be null; private set means only changable within the class

    public bool isAnswered
    {
        get { return PlayerAnswer.HasValue; }
    }

    public bool isCorrect
    {
        get { return isAnswered && (PlayerAnswer == CorrectAnswer); }
    }
    
    // Constructor:
    public MathQuestion(int operandA, int operandB, GameType game)
    {
        OperandA = operandA;
        OperandB = operandB;
        Game = game;
        CorrectAnswer = ComputeAnswer();
    }

    // Methods
    public void RecordAnswer(int answer)
    {
        this.PlayerAnswer = answer;
    }

    private int ComputeAnswer() {
        switch (Game) {
            case GameType.Addition:
                return OperandA + OperandB;
            case GameType.Subtraction: 
                return OperandA - OperandB;
            case GameType.Multiplication:
                return OperandA * OperandB;
            case GameType.Division:
                return OperandA / OperandB;

            default:
                throw new InvalidOperationException("Unknown Operation.");
        }
    }
}
