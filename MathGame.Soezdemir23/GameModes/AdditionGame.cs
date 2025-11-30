using mathgame.Model;

namespace mathgame.GameModes;

/// <summary>
/// Represents an addition game mode where players solve addition problems.
/// </summary>
public class AdditionGame : GameMode
{
    /// <summary>
    /// Generates a random addition question with two operands and the correct answer.
    /// </summary>
    /// <returns>A tuple containing the left operand, right operand, and the sum as the answer.</returns>
    protected override (int left, int right, int answer) GenerateQuestion()
    {
        int leftSide = _random.Next(1, 100);
        int rightSide = _random.Next(1, 100);
        return (leftSide, rightSide, leftSide + rightSide);
    }

    /// <summary>
    /// Gets the name of the game mode.
    /// </summary>
    /// <returns>The string "Addition".</returns>
    protected override string GetModeName() => "Addition";

    /// <summary>
    /// Gets the operator symbol used in this game mode.
    /// </summary>
    /// <returns>The addition operator symbol "+".</returns>
    protected override string GetOperatorSymbol() => "+";
}
