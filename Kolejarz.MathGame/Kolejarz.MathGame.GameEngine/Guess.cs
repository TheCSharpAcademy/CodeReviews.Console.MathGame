namespace Kolejarz.MathGame.GameEngine;

public record Guess(Puzzle Puzzle, int Answer, TimeSpan TimeTaken)
{
    public bool IsCorrect => Puzzle.Answer == Answer;
}
