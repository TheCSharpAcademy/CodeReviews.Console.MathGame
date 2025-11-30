using mathgame.Model;

namespace mathgame.GameModes;

/// <summary>
/// Represents a multiplication game mode where players solve multiplication problems.
/// </summary>
public class MultiplicationGame : GameMode
{
    /// <summary>
    /// Generates a multiplication question with two random operands between 1 and 12.
    /// </summary>
    /// <returns>A tuple containing the left operand, right operand, and the correct answer (product).</returns>
    protected override (int left, int right, int answer) GenerateQuestion()
    {
        
        int leftSide = _random.Next(1, 13);
        int rightSide = _random.Next(1, 13);
        return (leftSide, rightSide, leftSide * rightSide);
    }

    /// <summary>
    /// Gets the name of this game mode.
    /// </summary>
    /// <returns>The string "Multiplication".</returns>
    protected override string GetModeName() => "Multiplication";

    /// <summary>
    /// Gets the operator symbol used in this game mode.
    /// </summary>
    /// <returns>The multiplication operator symbol "*".</returns>
    protected override string GetOperatorSymbol() => "*";
}
